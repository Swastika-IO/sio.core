using ChatRoom.Lib.Helpers;
using Microsoft.AspNetCore.SignalR;
using Swastika.IO.Domain.Core.ViewModels;
using Swastika.Messenger.Lib.ViewModels.Hub;
using Swastika.Messenger.Lib.ViewModels.Messenger;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Swastika.IO.UI.Core.SignalR;

namespace ChatRoom.Lib.SignalR.Hubs
{
    public class MessengerHub : BaseSignalRHub
    {
        //private static readonly List<MessengerUserDetailsViewModel> ConnectedUsers = new List<MessengerUserDetailsViewModel>();
        string defaultName = "Anonymous";
        string defaultAvatar = string.Empty;
        string receiveMethod = "receiveMessage";
        public async Task HubConnect(MessengerRequestViewModel request)
        {
            string errorMsg = string.Empty;
            request.ConnectionId = Context.ConnectionId;
            RepositoryResponse<MessengerUserDetailsViewModel> result = new RepositoryResponse<MessengerUserDetailsViewModel>();
            if (string.IsNullOrEmpty(request.UserName))
            {
                var user = GenerateAnonymousUser(request);
                result.Data = user;
                result.IsSucceed = true;
                
            }
            else
            {
                result = await MessengerUserDetailsViewModel.JoinChatAsync(request);
            }

            string action = Enum.GetName(typeof(MessageReponseKey), MessageReponseKey.Connect);
            result.Status = result.IsSucceed ? 1 : 0;
            if (result.IsSucceed)
            {
                result.ResponseKey = action;
                var user = result.Data;
                Users.Add(new Swastika.IO.Domain.Core.Models.SignalRClient()
                {
                    UserId = user.Id,
                    NickName = user.Name,
                    ConnectionId = user.ConnectionId,
                    JoinedDate = DateTime.UtcNow
                }
                    );
                await Clients.Client(Context.ConnectionId).InvokeAsync(receiveMethod, result);
                await UpdateOnlineStatus(user.MyRooms, user.Id, true);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).InvokeAsync(receiveMethod, result);
            }
        }

        public async Task SendMessage(MessengerMessageViewModel message)
        {
            var result = await message.SaveModelAsync();
            if (result.IsSucceed)
            {
                result.Status = 1;
                result.ResponseKey = GetResponseKey(MessageReponseKey.SendMessage); //Enum.GetName(typeof(MessageReponseKey), MessageReponseKey.SendMessage);
                await Clients.All.InvokeAsync(receiveMethod, result);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).InvokeAsync(receiveMethod, result);
            }
        }

        private MessengerUserDetailsViewModel GenerateAnonymousUser(MessengerRequestViewModel request)
        {
            defaultName = Context.ConnectionId;

            var user = new MessengerUserDetailsViewModel()
            {
                Name = request.UserName ?? defaultName,
                Avatar = request.UserAvatar ?? defaultAvatar,
                ConnectionId = Context.ConnectionId,
                CreatedDate = DateTime.UtcNow,
                MyRooms = new List<MessengerRoomViewModel>(),
                MyTeams = new List<MessengerTeamViewModel>()
            };

            return user;
        }
        public async Task UpdateOnlineStatus(List<MessengerRoomViewModel> rooms, string userId, bool isOnline)
        {
            foreach (var room in rooms)
            {
                var teamMessage = new ApiResult<MessengerRequestViewModel>()
                {
                    Status = 1,
                    ResponseKey = MessageReponseKey.UpdateOnlineStatus.ToString(),
                    Data = new MessengerRequestViewModel()
                    {
                        UserId = userId,
                        TeamId = room.TeamId,
                        ConnectionId = Context.ConnectionId,
                        IsOnline = isOnline
                    }
                };

                await Clients.Group(room.Name).InvokeAsync(receiveMethod, teamMessage);
                if (isOnline)
                {
                    await Groups.AddAsync(Context.ConnectionId, room.Name);
                }
            }
        }
        private string GetResponseKey<T>(T e)
        {
            return Enum.GetName(typeof(T), e);
        }
        #region Overrides
        public override async Task OnDisconnectedAsync(Exception exception)
        {

            var getUser = await MessengerUserDetailsViewModel.Repository.GetSingleModelAsync(
                u => u.ConnectionId == Context.ConnectionId);
            if (getUser.IsSucceed)
            {
                var user = getUser.Data;
                user.ConnectionId = null;
                await user.SaveModelAsync();
                await UpdateOnlineStatus(user.MyRooms, user.Id, false);
            }
            await base.OnDisconnectedAsync(exception);
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        #endregion

        //public async System.Threading.Tasks.Task GetTeam(MessengerRequest request)
        //{
        //    string errorMsg = string.Empty;

        //    string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeam);
        //    ApiResult<TeamChatViewModel> result = await TeamChatViewModel.GetByUserIdAsync(request);
        //    await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //    UpdatePlayerConnectionIdAsync(request.UserId);
        //    //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
        //    //try
        //    //{
        //    //    if (TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
        //    //    {
        //    //        var getTeam = await TeamChatViewModel.Repository.GetSingleModelAsync(
        //    //            t => t.Id == request.TeamId);



        //    //        if (getTeam.IsSucceed)
        //    //        {
        //    //            var team = getTeam.Data;
        //    //            team.IsNewMessage = TeamMessageViewModel.Repository.Count(
        //    //                //team.Id, request.MemberId
        //    //                m =>
        //    //                m.sioc_chat_team.sioc_chat_team_member.FirstOrDefault(
        //    //                    mem => mem.MemberId == request.UserId) != null &&
        //    //                m.CreatedDate > m.sioc_chat_team.sioc_chat_team_member.FirstOrDefault(
        //    //                    msg => msg.MemberId == request.UserId && msg.TeamId == team.Id).SeenDate
        //    //                ).Data > 0;
        //    //            team.IsAdmin = request.UserId == team.HostId;
        //    //            if (team.IsAdmin)
        //    //            {

        //    //                team.TotalRequest = TeamMemberViewModel.Repository.Count(
        //    //                    m => m.TeamId == request.TeamId && m.Status == (int)MemberStatus.Requested).Data;
        //    //            }

        //    //            result = new ApiResult<TeamChatViewModel>()
        //    //            {
        //    //                Status = 1,
        //    //                ResponseKey = string.Format("{0}", action),
        //    //                Data = team,
        //    //                Errors = null
        //    //            };
        //    //        }
        //    //        else
        //    //        {
        //    //            result = new ApiResult<TeamChatViewModel>()
        //    //            {
        //    //                Status = 0,
        //    //                ResponseKey = TeamMessageReponseKey.NotMembered.ToString(),
        //    //                Data = null,
        //    //                Errors = null
        //    //            };
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        result = new ApiResult<TeamChatViewModel>()
        //    //        {
        //    //            Status = 0,
        //    //            ResponseKey = GameResponseKey.NotAuthorized.ToString(),
        //    //            Data = null,
        //    //            Errors = new List<string>() { "You are not membered of this team" }
        //    //        };
        //    //        Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //    //    }

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    result = new ApiResult<TeamChatViewModel>()
        //    //    {
        //    //        Status = 0,
        //    //        ResponseKey = string.Format("{0}", action),
        //    //        Data = null
        //    //    };
        //    //}
        //    //finally
        //    //{
        //    //    Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //    //    UpdatePlayerConnectionIdAsync(request.UserId);
        //    //}
        //}

        //public async System.Threading.Tasks.Task GetTeamMessages(MessengerRequest request)
        //{
        //    string errorMsg = string.Empty;
        //    ApiResult<TeamChatViewModel> result = null;
        //    string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeamMessages);
        //    //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
        //    try
        //    {
        //        if (TeamMemberViewModel.Repository.CheckIsExists(
        //            m =>
        //            m.TeamId == request.TeamId
        //            && m.MemberId == request.UserId
        //            && m.Status == (int)MemberStatus.Membered))
        //        {
        //            //var messages = await OgilvyTeamRepository<TeamChatViewModel>.Instance.GetModelListByAsync(m => m.Id == request.TeamId, m => m.CreatedDate, "desc", 0, 10);
        //            TeamChatViewModel team = (await TeamChatViewModel.Repository.GetSingleModelAsync
        //                (t => t.Id == request.TeamId)).Data;
        //            //TeamMemberViewModel.Repository.UpdateLastSeenMessages(request.UserId, request.TeamId);

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
        //                ResponseKey = GameResponseKey.NotAuthorized.ToString(),
        //                Data = null,
        //                Errors = new List<string>() { "You are not membered of this team" }
        //            };
        //            await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ApiResult<TeamChatViewModel>()
        //        {
        //            Status = 0,
        //            ResponseKey = string.Format("{0}", action),
        //            Data = null,
        //            Exception = ex
        //        };
        //    }
        //    finally
        //    {
        //        await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //        UpdatePlayerConnectionIdAsync(request.UserId);
        //    }
        //}

        //public async Task SeenTeamMessagesAsync(MessengerRequest request)
        //{
        //    if (TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
        //    {
        //        var getTeamMember = await TeamMemberViewModel.Repository.GetSingleModelAsync(
        //            m => m.MemberId == request.UserId && m.TeamId == request.TeamId);
        //        if (getTeamMember.IsSucceed)
        //        {
        //            getTeamMember.Data.SeenMessageDate = DateTime.UtcNow;
        //            await getTeamMember.Data.SaveModelAsync();
        //        }
        //        ApiResult<MessengerRequest> result = new ApiResult<MessengerRequest>()
        //        {
        //            Status = 1,
        //            ResponseKey = Enum.GetName(typeof(ApiResponseKey), ApiResponseKey.Succeed),
        //            Data = request
        //        };
        //        //Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //    }
        //    UpdatePlayerConnectionIdAsync(request.UserId);
        //}

        //public async System.Threading.Tasks.Task GetTeamNotifications(MessengerRequest request)
        //{
        //    string errorMsg = string.Empty;
        //    string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeamNotifications);
        //    try
        //    {
        //        var getCurrentMember = await TeamMemberViewModel.Repository.GetSingleModelAsync(
        //                       m => m.MemberId == request.UserId && m.TeamId == request.TeamId);
        //        if (getCurrentMember.IsSucceed)
        //        {
        //            var currentMember = getCurrentMember.Data;
        //            switch (request.MemberStatus)
        //            {
        //                case MemberStatus.Requested:
        //                    var requests = await TeamMemberViewModel.Repository.GetModelListByAsync(
        //                        m => m.Team.HostId == request.UserId
        //                        && m.TeamId == request.TeamId
        //                        && m.Status == (int)MemberStatus.Requested);
        //                    if (requests.Data.Count > 0)
        //                    {
        //                        requests.Data.ForEach(i => i.IsNew = !currentMember.SeenRequestDate.HasValue || currentMember.SeenRequestDate.Value < i.CreatedDate);
        //                        currentMember.SeenRequestDate = DateTime.UtcNow;

        //                    }

        //                    ApiResult<List<TeamMemberViewModel>> result = new ApiResult<List<TeamMemberViewModel>>()
        //                    {
        //                        Status = 1,
        //                        ResponseKey = string.Format("{0}", action),
        //                        Data = requests.Data.OrderByDescending(r => r.CreatedDate).ToList(),
        //                        Errors = null
        //                    };

        //                    await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);

        //                    break;
        //                case MemberStatus.Invited:
        //                    var invitations = await InvitationViewModel.Repository.GetModelListByAsync(
        //                        m => m.MemberId == request.UserId
        //                        && m.Status == (int)MemberStatus.Invited);
        //                    invitations.Data.ForEach(i => i.IsNew = !currentMember.SeenInviteDate.HasValue || currentMember.SeenInviteDate.Value < i.CreatedDate);
        //                    currentMember.SeenInviteDate = DateTime.UtcNow;

        //                    ApiResult<List<InvitationViewModel>> inviteResult = new ApiResult<List<InvitationViewModel>>()
        //                    {
        //                        Status = 1,
        //                        ResponseKey = string.Format("{0}", action),
        //                        Data = invitations.Data.OrderByDescending(r => r.CreatedDate).ToList(),
        //                        Errors = null
        //                    };

        //                    await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", inviteResult);

        //                    break;
        //                case MemberStatus.AdminRejected:
        //                    break;
        //                case MemberStatus.MemberRejected:
        //                    break;
        //                case MemberStatus.Banned:
        //                    break;
        //                case MemberStatus.Membered:
        //                    break;
        //                case MemberStatus.AdminRemoved:
        //                    break;
        //                case MemberStatus.MemberCanceled:
        //                    break;
        //                case MemberStatus.Guest:
        //                    break;
        //                default:
        //                    break;
        //            }
        //            await currentMember.SaveModelAsync();

        //        }

        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        UpdatePlayerConnectionIdAsync(request.UserId);
        //    }
        //}

        //public async System.Threading.Tasks.Task GetMyTeams(RequestPaging request)
        //{

        //    string errorMsg = string.Empty;
        //    ApiResult<PaginationModel<TeamChatViewModel>> result = null;
        //    string action = "GetMyTeams";
        //    //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
        //    try
        //    {

        //        PaginationModel<TeamChatViewModel> teams = (await TeamChatViewModel.Repository.GetModelListByAsync(
        //            t => t.SiocChatTeamMember.Count(m => m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered) > 0,
        //            "CreatedDate", OrderByDirection.Descending
        //            , request.PageSize, request.PageIndex
        //                )).Data;
        //        result = new ApiResult<PaginationModel<TeamChatViewModel>>()
        //        {
        //            Status = 1,
        //            ResponseKey = string.Format("{0}", action),
        //            Data = teams,
        //            Errors = null
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ApiResult<PaginationModel<TeamChatViewModel>>()
        //        {
        //            Status = 0,
        //            ResponseKey = action,
        //            Data = null,
        //            Exception = ex
        //        };
        //    }
        //    finally
        //    {
        //        await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //        UpdatePlayerConnectionIdAsync(request.UserId);
        //    }
        //}

        //public async System.Threading.Tasks.Task JoinTeam(MessengerRequest request)
        //{
        //    string errorMsg = string.Empty;
        //    ApiResult<TeamMemberViewModel> result = null;
        //    string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeam);
        //    //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
        //    try
        //    {
        //        if (!TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
        //        {
        //            var teamMember = new TeamMemberViewModel()
        //            {
        //                MemberId = request.UserId,
        //                TeamId = request.TeamId,
        //                Status = request.MemberStatus
        //            };
        //            var saveResult = await teamMember.SaveModelAsync();
        //            if (saveResult.IsSucceed)
        //            {
        //                //TeamMemberViewModel.InvokeMemberStatusChanged(request);
        //                result = new ApiResult<TeamMemberViewModel>()
        //                {
        //                    Status = 1
        //                    ,
        //                    ResponseKey = Enum.GetName(typeof(TeamResponseKey), TeamResponseKey.SetMemberStatusSucceed)
        //                    ,
        //                    Data = saveResult.Data
        //                };
        //            }
        //            else
        //            {
        //                result = new ApiResult<TeamMemberViewModel>()
        //                {
        //                    Status = 0
        //                    ,
        //                    ResponseKey = Enum.GetName(typeof(TeamResponseKey)
        //                    , TeamResponseKey.SetMemberStatusFailed)
        //                    ,
        //                    Data = saveResult.Data
        //                    ,
        //                    Errors = saveResult.Errors
        //                };
        //            }

        //        }
        //        else
        //        {
        //            result = new ApiResult<TeamMemberViewModel>()
        //            {
        //                Status = 0
        //                    ,
        //                ResponseKey = Enum.GetName(typeof(TeamResponseKey)
        //                    , TeamResponseKey.SetMemberStatusFailed)
        //            };
        //        }

        //    }
        //    catch 
        //    {
        //        result = new ApiResult<TeamMemberViewModel>()
        //        {
        //            Status = 0
        //                   ,
        //            ResponseKey = Enum.GetName(typeof(TeamResponseKey)
        //                   , TeamResponseKey.SetMemberStatusFailed)
        //        };
        //    }
        //    finally
        //    {
        //        await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //        UpdatePlayerConnectionIdAsync(request.UserId);
        //    }
        //}

        //public async System.Threading.Tasks.Task RemoveTeam(MessengerRequest request)
        //{
        //    string errorMsg = string.Empty;            
        //    ApiResult<bool> result = null;
        //    string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.RemovedTeam);
        //    //PaginationModel<TeamChatViewModel> currentMessages = new PaginationModel<TeamChatViewModel>();
        //    try
        //    {
        //        if (TeamMemberViewModel.Repository.CheckIsExists(m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered))
        //        {
        //            var removeResult = await TeamChatViewModel.Repository.RemoveModelAsync(
        //                t => t.Id == request.TeamId);

        //            if (removeResult.IsSucceed)
        //            {

        //                result = new ApiResult<bool>()
        //                {
        //                    Status = 1,
        //                    ResponseKey = string.Format("{0}", action),
        //                    Data = removeResult.IsSucceed,
        //                    Errors = null
        //                };
        //            }
        //            else
        //            {
        //                result = new ApiResult<bool>()
        //                {
        //                    Status = 0,
        //                    ResponseKey = TeamMessageReponseKey.NotMembered.ToString(),
        //                    Data = false,
        //                    Errors = null
        //                };
        //            }
        //        }
        //        else
        //        {
        //            result = new ApiResult<bool>()
        //            {
        //                Status = 0,
        //                ResponseKey = GameResponseKey.NotAuthorized.ToString(),
        //                Data = false,
        //                Errors = new List<string>() { "You are not membered of this team" }
        //            };
        //            await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ApiResult<bool>()
        //        {
        //            Status = 0,
        //            ResponseKey = string.Format("{0}", action),
        //            Data = false,
        //            Exception = ex
        //        };
        //    }
        //    finally
        //    {
        //        await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //        UpdatePlayerConnectionIdAsync(request.UserId);
        //    }
        //}

        ///// <summary>
        ///// Sends the message.
        ///// </summary>
        ///// <param name="message">The message.</param>
        ///// <param name="roomName">Name of the room.</param>
        //public async System.Threading.Tasks.Task SendMessage(TeamMessageViewModel vmMessage)
        //{
        //    string roomName = string.Format("Team_{0}", vmMessage.TeamId);
        //    string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.SendMessage);
        //    ApiResult<TeamMessageViewModel> result = null;
        //    try
        //    {
        //        if (vmMessage.TeamId > 0)
        //        {
        //            if (TeamMemberViewModel.Repository.CheckIsExists(
        //                m => m.TeamId == vmMessage.TeamId
        //                && m.MemberId == vmMessage.UserId
        //                && m.Status == (int)MemberStatus.Membered))
        //            {
        //                var saveResult = await vmMessage.SaveModelAsync();
        //                result = new ApiResult<TeamMessageViewModel>()
        //                {
        //                    Status = saveResult.IsSucceed ? 1 : 0,
        //                    ResponseKey = string.Format("{0}", action),
        //                    Data = saveResult.Data,
        //                    Errors = saveResult.Errors
        //                };
        //                await Clients.Group(roomName).InvokeAsync("receiveMessage", result);
        //            }
        //            else
        //            {
        //                result = new ApiResult<TeamMessageViewModel>()
        //                {
        //                    Status = 0,
        //                    ResponseKey = GameResponseKey.NotAuthorized.ToString(),
        //                    Data = null,
        //                    Errors = new List<string>() { "You are not membered of this team" }
        //                };
        //                await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", result);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ApiResult<TeamMessageViewModel>()
        //        {
        //            Status = 0,
        //            ResponseKey = string.Format("{0}", action),
        //            Data = null,
        //            Exception = ex
        //        };
        //    }
        //    finally
        //    {
        //        UpdatePlayerConnectionIdAsync(vmMessage.UserId);
        //    }
        //}

        //public async Task SaveTeam(TeamViewModel team)
        //{
        //    var saveResult = await team.SaveModelAsync(true);
        //    await Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", saveResult);
        //}


    }
}
