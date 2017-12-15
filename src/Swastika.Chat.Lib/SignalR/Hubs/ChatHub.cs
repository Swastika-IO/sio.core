using Microsoft.Data.OData.Query;
using ChatRoom.Lib.Helpers;
using ChatRoom.Lib.Models.SignalR;
using ChatRoom.Lib.ViewModels.Chat;
using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Swastika.IO.Domain.Core.ViewModels;

namespace ChatRoom.Lib.SignalR.Hubs
{
    public class MessengerHub : Hub
    {
        #region Video Call

        private static readonly List<ChatHubUserViewModel> Users = new List<ChatHubUserViewModel>();
        private static readonly List<UserCall> UserCalls = new List<UserCall>();
        private static readonly List<CallOffer> CallOffers = new List<CallOffer>();

        public void Join(string username)
        {
            // Add the new user
            var currentUser = Users.FirstOrDefault(u => u.NickName == username);
            if (currentUser==null)
            {
                currentUser = ChatHubUserViewModel.Repository.GetSingleModel(u => u.NickName == username).Data;
                currentUser.ConnectionId = Context.ConnectionId;
                Users.Add(currentUser);
            }
            else
            {
                currentUser.ConnectionId = Context.ConnectionId;
            }
            

            // Send down the new list to all clients
            SendUserListUpdate();
        }


        
        public void CallUser(string targetConnectionId)
        {

            var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
            var targetUser = Users.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

            // Make sure the person we are trying to call is still here
            if (targetUser == null)
            {
                // If not, let the Client(Context.ConnectionId) know
                Clients.Client(Context.ConnectionId).InvokeAsync("callDeclined", targetConnectionId, "The user you called has left.");
                return;
            }

            // And that they aren't already in a call
            if (GetUserCall(targetUser.ConnectionId) != null)
            {
                Clients.Client(Context.ConnectionId).InvokeAsync("callDeclined", targetConnectionId, string.Format("{ 0} is already in a call.", targetUser.NickName));
                return;
            }

            // They are here, so tell them someone wants to talk
            Clients.Client(targetConnectionId).InvokeAsync("incomingCall", callingUser);

            // Create an offer
            CallOffers.Add(new CallOffer
            {
                Caller = callingUser,
                Callee = targetUser
            });
        }

        public void AnswerCall(bool acceptCall, string targetConnectionId)
        {
            try
            {
                var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
                var targetUser = Users.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

                // This can only happen if the server-side came down and clients were cleared, while the user
                // still held their browser session.
                if (callingUser == null)
                {
                    return;
                }

                // Make sure the original Client(Context.ConnectionId) has not left the page yet
                if (targetUser == null)
                {
                    Clients.Client(Context.ConnectionId).InvokeAsync("callEnded", targetConnectionId, "The other user in your call has left.");
                    return;
                }

                // Send a decline message if the callee said no
                if (acceptCall == false)
                {
                    Clients.Client(targetConnectionId).InvokeAsync("callDeclined", callingUser, string.Format("{ 0} did not accept your call.", callingUser.NickName));
                    return;
                }

                // Make sure there is still an active offer.  If there isn't, then the other use hung up before the Callee answered.
                var offerCount = CallOffers.RemoveAll(c => c.Callee.ConnectionId == callingUser.ConnectionId
                                                      && c.Caller.ConnectionId == targetUser.ConnectionId);
                if (offerCount < 1)
                {
                    Clients.Client(Context.ConnectionId).InvokeAsync("callEnded", targetConnectionId, string.Format("{ 0} has already hung up.", targetUser.NickName));
                    return;
                }

                // And finally... make sure the user hasn't accepted another call already
                if (GetUserCall(targetUser.ConnectionId) != null)
                {
                    // And that they aren't already in a call
                    Clients.Client(Context.ConnectionId).InvokeAsync("callDeclined", targetConnectionId, string.Format("{ 0} chose to accept someone elses call instead of yours :(", targetUser.NickName));
                    return;
                }

                // Remove all the other offers for the call initiator, in case they have multiple calls out
                CallOffers.RemoveAll(c => c.Caller.ConnectionId == targetUser.ConnectionId);

                // Create a new call to match these folks up
                UserCalls.Add(new UserCall
                {
                    Users = new List<ChatHubUserViewModel> { callingUser, targetUser }
                });

                // Tell the original Client(Context.ConnectionId) that the call was accepted
                Clients.Client(targetConnectionId).InvokeAsync("callAccepted", callingUser);

                // Update the user list, since thes two are now in a call
                SendUserListUpdate();
            }
            catch (Exception ex)
            {
                Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", ex);
            }
        }

        public void HangUp()
        {
            var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);

            if (callingUser == null)
            {
                return;
            }

            var currentCall = GetUserCall(callingUser.ConnectionId);

            // Send a hang up message to each user in the call, if there is one
            if (currentCall != null)
            {
                foreach (var user in currentCall.Users.Where(u => u.ConnectionId != callingUser.ConnectionId))
                {
                    Clients.Client(user.ConnectionId).InvokeAsync("callEnded", callingUser.ConnectionId, string.Format("{ 0} has hung up.", callingUser.NickName));
                }

                // Remove the call from the list if there is only one (or none) person left.  This should
                // always trigger now, but will be useful when we implement conferencing.
                currentCall.Users.RemoveAll(u => u.ConnectionId == callingUser.ConnectionId);
                if (currentCall.Users.Count < 2)
                {
                    UserCalls.Remove(currentCall);
                }
            }

            // Remove all offers initiating from the Client(Context.ConnectionId)
            CallOffers.RemoveAll(c => c.Caller.ConnectionId == callingUser.ConnectionId);

            SendUserListUpdate();
        }

        // WebRTC Signal Handler
        public void SendSignal(string signal, string targetConnectionId)
        {
            var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
            var targetUser = Users.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

            // Make sure both users are valid
            if (callingUser == null || targetUser == null)
            {
                return;
            }

            // Make sure that the person sending the signal is in a call
            var userCall = GetUserCall(callingUser.ConnectionId);

            // ...and that the target is the one they are in a call with
            if (userCall != null && userCall.Users.Exists(u => u.ConnectionId == targetUser.ConnectionId))
            {
                // These folks are in a call together, let's let em talk WebRTC
                Clients.Client(targetConnectionId).InvokeAsync("receiveSignal", callingUser, signal);
            }
        }

        #region Private Helpers

        private void SendUserListUpdate()
        {
            Users.ForEach(u => u.InCall = (GetUserCall(u.ConnectionId) != null));
            Clients.All.InvokeAsync("updateUserList", Users);
        }

        private UserCall GetUserCall(string connectionId)
        {
            var matchingCall =
                UserCalls.SingleOrDefault(uc => uc.Users.SingleOrDefault(u => u.ConnectionId == connectionId) != null);
            return matchingCall;
        }

        #endregion

        #endregion

        public async System.Threading.Tasks.Task HubConnect(ChatHubUserViewModel request)
        {

            string errorMsg = string.Empty;
            request.ConnectionId = Context.ConnectionId;
            ApiResult<TeamChatConnectedData> result = await request.JoinChatAsync();
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.Connect);
            if (result.Status==1)
            {                
                foreach (var room in request.Rooms)
                {
                    var teamMessage = new ApiResult<ChatRequest>()
                    {
                        Status = 1,
                        ResponseKey = TeamMessageReponseKey.UpdateOnlineStatus.ToString(),
                        Data = new ChatRequest()
                        {
                            UserId = request.UserId,
                            TeamId = room.TeamId,
                            ConnectionId = Context.ConnectionId,
                            IsOnline = true
                        }
                    };

                    await Clients.Group(room.RoomName).InvokeAsync("receiveMessage", teamMessage);
                    await Groups.AddAsync(request.ConnectionId, room.RoomName);
                    
                }
                await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
            }
        }
        
        public async System.Threading.Tasks.Task GetTeam(ChatRequest request)
        {
            string errorMsg = string.Empty;
            
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeam);
            ApiResult<TeamChatViewModel> result = await TeamChatViewModel.GetByUserIdAsync(request);
            await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
            UpdatePlayerConnectionIdAsync(request.UserId);
            //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
            //try
            //{
            //    if (TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
            //    {
            //        var getTeam = await TeamChatViewModel.Repository.GetSingleModelAsync(
            //            t => t.Id == request.TeamId);



            //        if (getTeam.IsSucceed)
            //        {
            //            var team = getTeam.Data;
            //            team.IsNewMessage = TeamMessageViewModel.Repository.Count(
            //                //team.Id, request.MemberId
            //                m =>
            //                m.sioc_chat_team.sioc_chat_team_member.FirstOrDefault(
            //                    mem => mem.MemberId == request.UserId) != null &&
            //                m.CreatedDate > m.sioc_chat_team.sioc_chat_team_member.FirstOrDefault(
            //                    msg => msg.MemberId == request.UserId && msg.TeamId == team.Id).SeenDate
            //                ).Data > 0;
            //            team.IsAdmin = request.UserId == team.HostId;
            //            if (team.IsAdmin)
            //            {

            //                team.TotalRequest = TeamMemberViewModel.Repository.Count(
            //                    m => m.TeamId == request.TeamId && m.Status == (int)MemberStatus.Requested).Data;
            //            }

            //            result = new ApiResult<TeamChatViewModel>()
            //            {
            //                Status = 1,
            //                ResponseKey = string.Format("{0}", action),
            //                Data = team,
            //                Errors = null
            //            };
            //        }
            //        else
            //        {
            //            result = new ApiResult<TeamChatViewModel>()
            //            {
            //                Status = 0,
            //                ResponseKey = TeamMessageReponseKey.NotMembered.ToString(),
            //                Data = null,
            //                Errors = null
            //            };
            //        }
            //    }
            //    else
            //    {
            //        result = new ApiResult<TeamChatViewModel>()
            //        {
            //            Status = 0,
            //            ResponseKey = GameResponseKey.NotAuthorized.ToString(),
            //            Data = null,
            //            Errors = new List<string>() { "You are not membered of this team" }
            //        };
            //        Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    result = new ApiResult<TeamChatViewModel>()
            //    {
            //        Status = 0,
            //        ResponseKey = string.Format("{0}", action),
            //        Data = null
            //    };
            //}
            //finally
            //{
            //    Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
            //    UpdatePlayerConnectionIdAsync(request.UserId);
            //}
        }
        
        public async System.Threading.Tasks.Task GetTeamMessages(ChatRequest request)
        {
            string errorMsg = string.Empty;
            ApiResult<TeamChatViewModel> result = null;
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeamMessages);
            //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
            try
            {
                if (TeamMemberViewModel.Repository.CheckIsExists(
                    m =>
                    m.TeamId == request.TeamId
                    && m.MemberId == request.UserId
                    && m.Status == (int)MemberStatus.Membered))
                {
                    //var messages = await OgilvyTeamRepository<TeamChatViewModel>.Instance.GetModelListByAsync(m => m.Id == request.TeamId, m => m.CreatedDate, "desc", 0, 10);
                    TeamChatViewModel team = (await TeamChatViewModel.Repository.GetSingleModelAsync
                        (t => t.Id == request.TeamId)).Data;
                    //TeamMemberViewModel.Repository.UpdateLastSeenMessages(request.UserId, request.TeamId);

                    result = new ApiResult<TeamChatViewModel>()
                    {
                        Status = 1,
                        ResponseKey = string.Format("{0}", action),
                        Data = team,
                        Errors = null
                    };
                }
                else
                {
                    result = new ApiResult<TeamChatViewModel>()
                    {
                        Status = 0,
                        ResponseKey = GameResponseKey.NotAuthorized.ToString(),
                        Data = null,
                        Errors = new List<string>() { "You are not membered of this team" }
                    };
                    await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
                }

            }
            catch (Exception ex)
            {
                result = new ApiResult<TeamChatViewModel>()
                {
                    Status = 0,
                    ResponseKey = string.Format("{0}", action),
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
                UpdatePlayerConnectionIdAsync(request.UserId);
            }
        }
        
        public async Task SeenTeamMessagesAsync(ChatRequest request)
        {
            if (TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
            {
                var getTeamMember = await TeamMemberViewModel.Repository.GetSingleModelAsync(
                    m => m.MemberId == request.UserId && m.TeamId == request.TeamId);
                if (getTeamMember.IsSucceed)
                {
                    getTeamMember.Data.SeenMessageDate = DateTime.UtcNow;
                    await getTeamMember.Data.SaveModelAsync();
                }
                ApiResult<ChatRequest> result = new ApiResult<ChatRequest>()
                {
                    Status = 1,
                    ResponseKey = Enum.GetName(typeof(ApiResponseKey), ApiResponseKey.Succeed),
                    Data = request
                };
                //Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
            }
            UpdatePlayerConnectionIdAsync(request.UserId);
        }

        public async System.Threading.Tasks.Task GetTeamNotifications(ChatRequest request)
        {
            string errorMsg = string.Empty;
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeamNotifications);
            try
            {
                var getCurrentMember = await TeamMemberViewModel.Repository.GetSingleModelAsync(
                               m => m.MemberId == request.UserId && m.TeamId == request.TeamId);
                if (getCurrentMember.IsSucceed)
                {
                    var currentMember = getCurrentMember.Data;
                    switch (request.MemberStatus)
                    {
                        case MemberStatus.Requested:
                            var requests = await TeamMemberViewModel.Repository.GetModelListByAsync(
                                m => m.Team.HostId == request.UserId
                                && m.TeamId == request.TeamId
                                && m.Status == (int)MemberStatus.Requested);
                            if (requests.Data.Count > 0)
                            {
                                requests.Data.ForEach(i => i.IsNew = !currentMember.SeenRequestDate.HasValue || currentMember.SeenRequestDate.Value < i.CreatedDate);
                                currentMember.SeenRequestDate = DateTime.UtcNow;

                            }

                            ApiResult<List<TeamMemberViewModel>> result = new ApiResult<List<TeamMemberViewModel>>()
                            {
                                Status = 1,
                                ResponseKey = string.Format("{0}", action),
                                Data = requests.Data.OrderByDescending(r => r.CreatedDate).ToList(),
                                Errors = null
                            };

                            await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);

                            break;
                        case MemberStatus.Invited:
                            var invitations = await InvitationViewModel.Repository.GetModelListByAsync(
                                m => m.MemberId == request.UserId
                                && m.Status == (int)MemberStatus.Invited);
                            invitations.Data.ForEach(i => i.IsNew = !currentMember.SeenInviteDate.HasValue || currentMember.SeenInviteDate.Value < i.CreatedDate);
                            currentMember.SeenInviteDate = DateTime.UtcNow;

                            ApiResult<List<InvitationViewModel>> inviteResult = new ApiResult<List<InvitationViewModel>>()
                            {
                                Status = 1,
                                ResponseKey = string.Format("{0}", action),
                                Data = invitations.Data.OrderByDescending(r => r.CreatedDate).ToList(),
                                Errors = null
                            };

                            await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", inviteResult);

                            break;
                        case MemberStatus.AdminRejected:
                            break;
                        case MemberStatus.MemberRejected:
                            break;
                        case MemberStatus.Banned:
                            break;
                        case MemberStatus.Membered:
                            break;
                        case MemberStatus.AdminRemoved:
                            break;
                        case MemberStatus.MemberCanceled:
                            break;
                        case MemberStatus.Guest:
                            break;
                        default:
                            break;
                    }
                    await currentMember.SaveModelAsync();

                }

            }
            catch
            {

            }
            finally
            {
                UpdatePlayerConnectionIdAsync(request.UserId);
            }
        }

        public async System.Threading.Tasks.Task GetMyTeams(RequestPaging request)
        {

            string errorMsg = string.Empty;
            ApiResult<PaginationModel<TeamChatViewModel>> result = null;
            string action = "GetMyTeams";
            //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
            try
            {

                PaginationModel<TeamChatViewModel> teams = (await TeamChatViewModel.Repository.GetModelListByAsync(
                    t => t.SiocChatTeamMember.Count(m => m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered) > 0,
                    "CreatedDate", OrderByDirection.Descending
                    , request.PageSize, request.PageIndex
                        )).Data;
                result = new ApiResult<PaginationModel<TeamChatViewModel>>()
                {
                    Status = 1,
                    ResponseKey = string.Format("{0}", action),
                    Data = teams,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                result = new ApiResult<PaginationModel<TeamChatViewModel>>()
                {
                    Status = 0,
                    ResponseKey = action,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
                UpdatePlayerConnectionIdAsync(request.UserId);
            }
        }

        public async System.Threading.Tasks.Task JoinTeam(ChatRequest request)
        {
            string errorMsg = string.Empty;
            ApiResult<TeamMemberViewModel> result = null;
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeam);
            //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
            try
            {
                if (!TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
                {
                    var teamMember = new TeamMemberViewModel()
                    {
                        MemberId = request.UserId,
                        TeamId = request.TeamId,
                        Status = request.MemberStatus
                    };
                    var saveResult = await teamMember.SaveModelAsync();
                    if (saveResult.IsSucceed)
                    {
                        //TeamMemberViewModel.InvokeMemberStatusChanged(request);
                        result = new ApiResult<TeamMemberViewModel>()
                        {
                            Status = 1
                            ,
                            ResponseKey = Enum.GetName(typeof(TeamResponseKey), TeamResponseKey.SetMemberStatusSucceed)
                            ,
                            Data = saveResult.Data
                        };
                    }
                    else
                    {
                        result = new ApiResult<TeamMemberViewModel>()
                        {
                            Status = 0
                            ,
                            ResponseKey = Enum.GetName(typeof(TeamResponseKey)
                            , TeamResponseKey.SetMemberStatusFailed)
                            ,
                            Data = saveResult.Data
                            ,
                            Errors = saveResult.Errors
                        };
                    }

                }
                else
                {
                    result = new ApiResult<TeamMemberViewModel>()
                    {
                        Status = 0
                            ,
                        ResponseKey = Enum.GetName(typeof(TeamResponseKey)
                            , TeamResponseKey.SetMemberStatusFailed)
                    };
                }

            }
            catch 
            {
                result = new ApiResult<TeamMemberViewModel>()
                {
                    Status = 0
                           ,
                    ResponseKey = Enum.GetName(typeof(TeamResponseKey)
                           , TeamResponseKey.SetMemberStatusFailed)
                };
            }
            finally
            {
                await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
                UpdatePlayerConnectionIdAsync(request.UserId);
            }
        }

        public async System.Threading.Tasks.Task RemoveTeam(ChatRequest request)
        {
            string errorMsg = string.Empty;            
            ApiResult<bool> result = null;
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.RemovedTeam);
            //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
            try
            {
                if (TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
                {
                    var removeResult = await TeamChatViewModel.Repository.RemoveModelAsync(
                        t => t.Id == request.TeamId);

                    if (removeResult.IsSucceed)
                    {

                        result = new ApiResult<bool>()
                        {
                            Status = 1,
                            ResponseKey = string.Format("{0}", action),
                            Data = removeResult.IsSucceed,
                            Errors = null
                        };
                    }
                    else
                    {
                        result = new ApiResult<bool>()
                        {
                            Status = 0,
                            ResponseKey = TeamMessageReponseKey.NotMembered.ToString(),
                            Data = false,
                            Errors = null
                        };
                    }
                }
                else
                {
                    result = new ApiResult<bool>()
                    {
                        Status = 0,
                        ResponseKey = GameResponseKey.NotAuthorized.ToString(),
                        Data = false,
                        Errors = new List<string>() { "You are not membered of this team" }
                    };
                    await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
                }

            }
            catch (Exception ex)
            {
                result = new ApiResult<bool>()
                {
                    Status = 0,
                    ResponseKey = string.Format("{0}", action),
                    Data = false,
                    Exception = ex
                };
            }
            finally
            {
                await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
                UpdatePlayerConnectionIdAsync(request.UserId);
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="roomName">Name of the room.</param>
        public async System.Threading.Tasks.Task SendMessage(TeamMessageViewModel vmMessage)
        {
            string roomName = string.Format("Team_{0}", vmMessage.TeamId);
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.SendMessage);
            ApiResult<TeamMessageViewModel> result = null;
            try
            {
                if (vmMessage.TeamId > 0)
                {
                    if (TeamMemberViewModel.Repository.CheckIsExists(
                        m => m.TeamId == vmMessage.TeamId
                        && m.MemberId == vmMessage.UserId
                        && m.Status == (int)MemberStatus.Membered))
                    {
                        var saveResult = await vmMessage.SaveModelAsync();
                        result = new ApiResult<TeamMessageViewModel>()
                        {
                            Status = saveResult.IsSucceed ? 1 : 0,
                            ResponseKey = string.Format("{0}", action),
                            Data = saveResult.Data,
                            Errors = saveResult.Errors
                        };
                        await Clients.Group(roomName).InvokeAsync("receiveMessage", result);
                    }
                    else
                    {
                        result = new ApiResult<TeamMessageViewModel>()
                        {
                            Status = 0,
                            ResponseKey = GameResponseKey.NotAuthorized.ToString(),
                            Data = null,
                            Errors = new List<string>() { "You are not membered of this team" }
                        };
                        await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new ApiResult<TeamMessageViewModel>()
                {
                    Status = 0,
                    ResponseKey = string.Format("{0}", action),
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                UpdatePlayerConnectionIdAsync(vmMessage.UserId);
            }
        }

        public async Task SaveTeam(TeamViewModel team)
        {
            var saveResult = await team.SaveModelAsync(true);
            await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", saveResult);
        }

        /// <summary>
        /// Fails the result.
        /// </summary>
        /// <param name="objData">The object data.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="errorMsg">The error MSG.</param>
        void FailResult(dynamic objData, string errorMsg)//AccessTokenViewModel accessToken
        {
            string responseKey = "Failed";
            int status = 0;
            ApiResult<dynamic> result = new ApiResult<dynamic>()
            {
                ResponseKey = responseKey,
                Status = status,
                Data = objData,
                //authData = accessToken,
            };
            Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        }

        async void UpdatePlayerConnectionIdAsync(string playerId)
        {
            var getPlayer = ChatHubUserViewModel.Repository.GetSingleModel(p => p.UserId == playerId);
            var player = getPlayer.Data;
            if (player != null && player.ConnectionId != Context.ConnectionId)
            {
                var getTeams = TeamViewModel.Repository.GetModelListBy(
                        t => t.SiocChatTeamMember.Count(m => m.MemberId == playerId && m.Status == (int)MemberStatus.Membered) > 0
                        //, t => t.CreatedDate, "desc", 0, null
                            );
                foreach (var team in getTeams.Data)
                {
                    await Groups.AddAsync(Context.ConnectionId, string.Format("Team_{0}", team.Id));
                }
                player.ConnectionId = Context.ConnectionId;
                player.SaveModel();
            }
        }

        async void UpdateGroupConnectionAsync()
        {
            var getPlayer = ChatHubUserViewModel.Repository.GetSingleModel(p => p.ConnectionId == Context.ConnectionId);
            if (getPlayer.IsSucceed)
            {
                var player = getPlayer.Data;
                var getTeams = TeamViewModel.Repository.GetModelListBy(
                        t => t.SiocChatTeamMember.Count(
                            m => m.MemberId == player.UserId && m.Status == (int)MemberStatus.Membered) > 0
                            //"CreatedDate", OrderByDirection.Descending , 0, null
                            );
                if (getTeams.IsSucceed)
                {

                    foreach (var team in getTeams.Data)
                    {
                        await Groups.AddAsync(player.ConnectionId, string.Format("Team_{0}", team.Id));
                    }
                }
                player.ConnectionId = Context.ConnectionId;
            }
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {

            var getChatUser = ChatHubUserViewModel.Repository.GetSingleModel(
                u => u.ConnectionId == Context.ConnectionId);
            if (getChatUser.IsSucceed)
            {
                var user = getChatUser.Data;
                foreach (var room in user.Rooms)
                {
                    var teamMessage = new ApiResult<ChatRequest>()
                    {
                        Status = 1,
                        ResponseKey = TeamMessageReponseKey.UpdateOnlineStatus.ToString(),
                        Data = new ChatRequest()
                        {
                            UserId = user.UserId,
                            TeamId = room.TeamId,
                            IsOnline = false
                        }
                    };

                    Clients.Group(room.RoomName).InvokeAsync("receiveMessage", teamMessage);
                }
                user.RemoveModel();
                //ChatHubUserViewModel.Repository.RemoveModel(user.Model);
            }

            //Video Call
            // Hang up any calls the user is in
            HangUp(); // Gets the user from "Context" which is available in the whole hub

            // Remove the user
            Users.RemoveAll(u => u.ConnectionId == Context.ConnectionId);

            // Send down the new user list to all clients
            SendUserListUpdate();
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            UpdateGroupConnectionAsync();
            return base.OnConnectedAsync();
        }
    }
}
