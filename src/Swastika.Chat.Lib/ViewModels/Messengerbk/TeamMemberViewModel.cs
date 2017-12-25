using Newtonsoft.Json;
using ChatRoom.Lib.Helpers;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Linq;
using Swastika.Messenger.Lib.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Swastika.IO.Common.Helper;
using Swastika.Identity.Models;
namespace ChatRoom.Lib.ViewModels.Chat
{
    public class TeamMemberViewModel : ViewModelBase<MessengerContext, SiocChatTeamMember, TeamMemberViewModel>
    {
        #region Properties

        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonProperty("memberId")]
        public string MemberId { get; set; }
        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
        [JsonProperty("isNew")]
        public bool IsNew { get; set; }
        [JsonProperty("status")]
        public MemberStatus Status { get; set; }
        [JsonIgnore]
        public Nullable<System.DateTime> JoinedDate { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("seenMessageDate")]
        public DateTime? SeenMessageDate { get; set; }
        [JsonProperty("seenRequestDate")]
        public DateTime? SeenRequestDate { get; set; }
        [JsonProperty("seenInviteDate")]
        public DateTime? SeenInviteDate { get; set; }
        ////View
        //[JsonProperty("info")]
        //public AccountViewModel Info { get; set; }
        [JsonProperty("chatInfo")]
        public ChatHubUserViewModel ChatInfo { get; set; }
        [JsonProperty("isOnline")]
        public bool IsOnline { get; set; }

        #endregion
        public TeamMemberViewModel()
            : base()
        {
        }

        public TeamMemberViewModel(SiocChatTeamMember model, MessengerContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #region Overrides

        public override SiocChatTeamMember ParseModel()
        {
            if (CreatedDate == default(DateTime))
            {
                CreatedDate = DateTime.UtcNow;
            }
            return base.ParseModel();
        }

        public override TeamMemberViewModel ParseView(bool isExpand = true, MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(isExpand, _context, _transaction);
            //vm.Info = AccountViewModel.Repository.GetSingleModel(
            //    m => m.Id == MemberId).Data;
            vm.ChatInfo = ChatHubUserViewModel.Repository.GetSingleModel(
                m => m.UserId == MemberId, _context, _transaction).Data;
            vm.IsOnline = vm.ChatInfo != null;
            vm.ChatInfo = vm.ChatInfo ?? new ChatHubUserViewModel()
            {
                UserId = vm.MemberId,
                //AvatarUrl = vm.Info?.AvatarUrl
            };
            
            return vm;
        }

        public override void Validate(MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            base.Validate(_context, _transaction);
            int maxMember = 50;
            if (CreatedDate == default(DateTime))
            {
                CreatedDate = DateTime.UtcNow;
            }
            var teamModel = _context.SiocChatTeam.Include(t => t.SiocChatTeamMember)
                .FirstOrDefault(t => t.Id == TeamId);
            if (teamModel != null)
            {
                if (Status == MemberStatus.Requested && (!teamModel.IsOpen.HasValue || teamModel.IsOpen.Value))
                {
                    Status = MemberStatus.Membered;
                }

                switch (Status)
                {
                    //Set User to be Team Member
                    case MemberStatus.Membered:
                        if (teamModel != null && teamModel.HostId != MemberId
                            && (!teamModel.IsOpen.HasValue || teamModel.IsOpen.Value))
                        {
                            Status = MemberStatus.Requested;
                        }
                        if (teamModel.SiocChatTeamMember.Count(m => m.Status == (int)MemberStatus.Membered && m.TeamId == TeamId) >= maxMember)
                        {
                            Errors.Add("Team Fulled");
                            IsValid = false;
                        }
                        else
                        {
                            JoinedDate = DateTime.UtcNow;
                        }
                        break;

                    case MemberStatus.MemberAccepted:
                        Status = MemberStatus.Membered;

                        break;

                    case MemberStatus.AdminRejected:
                    case MemberStatus.Banned:
                        if (teamModel != null && teamModel.HostId != MemberId)
                        {
                            Errors.Add("Banned");
                            IsValid = false;
                        }
                        break;

                    case MemberStatus.Requested:
                    case MemberStatus.Invited:
                    case MemberStatus.MemberRejected:
                    case MemberStatus.MemberCanceled:
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Expands



        //public static void InvokeMemberStatusChanged(ChatRequest teamMember)
        //{
        //    Microsoft.AspNetCore.SignalR.HubContext<ChatHub> hubContext = new HubContext<ChatHub>( new);
        //    var getChatUser = ChatHubUserViewModel.Repository.GetSingleModel(
        //        u => u.UserId == teamMember.UserId);
        //    var getTeam = TeamViewModel.Repository.GetSingleModel(
        //        t => t.Id == teamMember.TeamId);
        //    var getMember = TeamMemberViewModel.Repository.GetSingleModel(
        //        m => m.TeamId == teamMember.TeamId && m.MemberId == teamMember.UserId);
        //    if (getTeam.IsSucceed && getMember.IsSucceed)
        //    {
        //        var team = getTeam.Data;
        //        var member = getMember.Data;

        //        TeamMessageViewModel msg = new TeamMessageViewModel()
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            TeamId = team.Id,
        //            MessageType = MessageType.Notification,
        //            Message = string.Empty,
        //            Nickname = string.Format("{0} {1}", member.Info.FirstName, member.Info.LastName),
        //            UserAvatar = member.Info.Avatar,
        //            UserId = teamMember.UserId,
        //            CreatedDate = DateTime.UtcNow
        //        };


        //        var teamResponse = new ApiResult<TeamViewModel>()
        //        {
        //            Status = 1,
        //            Data = team,
        //            Errors = null
        //        };

        //        var memberResponse = new ApiResult<TeamMemberViewModel>()
        //        {
        //            Status = 1,
        //            Data = member,
        //            Errors = null
        //        };


        //        var msgResponse = new ApiResult<TeamMessageViewModel>()
        //        {
        //            Status = 1,
        //            ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.SendMessage),
        //            Data = msg,
        //            Errors = null
        //        };

        //        string roomName = string.Format("Team_{0}", teamMember.TeamId);
        //        var getAdmin = ChatHubUserViewModel.Repository.GetSingleModel(
        //            u => u.UserId == team.HostId);
        //        var admin = getAdmin.Data;
        //        var chatUser = getChatUser.Data;
        //        switch (teamMember.MemberStatus)
        //        {
        //            case MemberStatus.Requested:

        //                if (getAdmin.IsSucceed)
        //                {
        //                    //Send message to admin
        //                    //msg.Message = "Requested";
        //                    //msg.NotificationType = NotificationType.NewRequest;
        //                    //hubContext.Clients.Client(admin.ConnectionId).InvokeAsync("receiveMessage", msgResponse);

        //                    //invoke notification new request to admin
        //                    memberResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.NewRequest);
        //                    hubContext.Clients.Client(admin.ConnectionId).InvokeAsync("receiveMessage", memberResponse);

        //                }
        //                break;
        //            case MemberStatus.Invited:
        //                if (chatUser != null)
        //                {
        //                    // Send message to member invited
        //                    //msg.Message = "Invited";
        //                    //hubContext.Clients.Client(chatUser.ConnectionId).InvokeAsync("receiveMessage", msgResponse);

        //                    // Invoke notification to member invited
        //                    teamResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.NewInvite);
        //                    hubContext.Clients.Client(chatUser.ConnectionId).InvokeAsync("receiveMessage", teamResponse);

        //                }
        //                //NotificationHelper.PushNotification(teamMember.MemberId, JsonConvert.SerializeObject(teamResponse, Formatting.None), "InAppNotification");
        //                break;
        //            case MemberStatus.AdminRemoved:
        //                if (chatUser != null)
        //                {
        //                    // Invoke in-app notification to Team Users that member removed
        //                    teamResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.RemovedTeam);
        //                    hubContext.Groups.RemoveAsync(chatUser.ConnectionId, roomName);
        //                    hubContext.Clients.Client(chatUser.ConnectionId).InvokeAsync("receiveMessage", teamResponse);
        //                }

        //                // Send message to team that member removed
        //                //msg.Message = "Removed";
        //                //msg.NotificationType = NotificationType.RemovedTeam;
        //                //hubContext.Clients.Group(roomName).InvokeAsync("receiveMessage", msgResponse);

        //                // Invoke in-app notification to team that member removed
        //                memberResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.RemovedMember);
        //                hubContext.Clients.Group(roomName).InvokeAsync("receiveMessage", memberResponse);

        //                break;
        //            case MemberStatus.AdminRejected:
        //                if (chatUser != null)
        //                {
        //                    // Invoke in-app notification to Team Users that member removed
        //                    teamResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.RemovedTeam);
        //                    hubContext.Clients.Client(chatUser.ConnectionId).InvokeAsync("receiveMessage", teamResponse);
        //                }
        //                break;
        //            case MemberStatus.MemberRejected:
        //                break;
        //            case MemberStatus.MemberCanceled:

        //                if (admin != null)
        //                {
        //                    //Send message to admin
        //                    //msg.Message = "Requested";
        //                    //msg.NotificationType = NotificationType.NewRequest;
        //                    //hubContext.Clients.Client(admin.ConnectionId).InvokeAsync("receiveMessage", msgResponse);

        //                    //invoke notification new request to admin
        //                    memberResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.CancelRequest);
        //                    hubContext.Clients.Client(admin.ConnectionId).InvokeAsync("receiveMessage", memberResponse);

        //                }
        //                break;
        //            case MemberStatus.Banned:
        //                break;
        //            case MemberStatus.MemberLeft:
        //                if (chatUser != null)
        //                {
        //                    // Invoke in-app notification to Team Users that member removed
        //                    teamResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.RemovedTeam);
        //                    hubContext.Clients.Client(chatUser.ConnectionId).InvokeAsync("receiveMessage", teamResponse);
        //                }
        //                //msg.Message = "Left";
        //                //msg.NotificationType = NotificationType.RemovedMember;
        //                memberResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.RemovedMember);
        //                hubContext.Clients.Group(string.Format("Team_{0}", teamMember.TeamId)).InvokeAsync("receiveMessage", memberResponse);
        //                hubContext.Groups.RemoveAsync(chatUser.ConnectionId, roomName);
        //                //hubContext.Clients.Group(string.Format("Team_{0}", teamMember.TeamId)).InvokeAsync("receiveMessage", msgResponse);
        //                break;
        //            case MemberStatus.Membered:
        //                teamResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.NewTeam);
        //                if (chatUser != null)
        //                {
        //                    hubContext.Clients.Client(chatUser.ConnectionId).InvokeAsync("receiveMessage", teamResponse);
        //                }
        //                //NotificationHelper.PushNotification(teamMember.MemberId, JsonConvert.SerializeObject(teamResponse, Formatting.None), "InAppNotification");

        //                msg.Message = "Joined";
        //                msg.NotificationType = NotificationType.Join;
        //                memberResponse.ResponseKey = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.NewMember);
        //                hubContext.Clients.Group(string.Format("Team_{0}", teamMember.TeamId)).InvokeAsync("receiveMessage", memberResponse);
        //                hubContext.Groups.AddAsync(chatUser.ConnectionId, roomName);
        //                hubContext.Clients.Group(string.Format("Team_{0}", teamMember.TeamId)).InvokeAsync("receiveMessage", msgResponse);

        //                break;
        //            default:
        //                break;
        //        }
        //        if (!string.IsNullOrEmpty(msg.Message))
        //        {
        //            msg.SaveModel();
        //        }
        //    }

        //}

        #endregion
    }

    public class InvitationViewModel : ViewModelBase<MessengerContext, SiocChatTeamMember, InvitationViewModel>
    {
        [JsonIgnore]
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonIgnore]
        public Nullable<System.DateTime> JoinedDate { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        //View
        [JsonProperty("isNew")]
        public bool IsNew { get; set; }

        [JsonProperty("team")]
        public TeamViewModel Team { get; set; }

        public override void ExpandView(MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            Team = TeamViewModel.Repository.GetSingleModel(t => t.Id == TeamId, _context, _transaction).Data;
        }
    }


    public class TeamMemberInfo
    {
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        [JsonProperty("nickname")]
        public string NickName { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("rankStatus")]
        public int RankStatus { get; set; }
        [JsonProperty("elo")]
        public double ELO { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Avatar) && Avatar.IndexOf("http") == -1)
                {
                    return CommonHelper.GetFullPath(new string[] {
                    ChatConstants.Domain,  Avatar
                });
                }
                else
                {
                    return !string.IsNullOrEmpty(Avatar) ? Avatar : ChatConstants.DefaultAvatar;
                }

            }
            set
            {
                Avatar = value;
            }
        }
        [JsonProperty("totalMatch")]
        public int TotalMatch { get; set; }
        [JsonProperty("totalWin")]
        public int TotalWin { get; set; }
        public TeamMemberInfo(ApplicationUser info, int rank, string cate, string activeId)
        {
            NickName = info.FirstName;
            if (!string.IsNullOrEmpty(info.Avatar))
            {
                //Avatar = CommonHelper.GetFullFilePath(info.Avatar);
            }

            Rank = rank;
            IsActive = info.Id == activeId;

        }
    }
}
