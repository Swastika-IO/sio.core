using Newtonsoft.Json;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using Swastika.Domain.Core.Models;
using System.Threading.Tasks;
using ChatRoom.Lib.Models.SignalR;
using System.Linq;
using Microsoft.Data.OData.Query;
using ChatRoom.Lib.Helpers;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.IO.Common.Helper;
using Swastika.Messenger.Lib.Models;
using Swastika.IO.Domain.Core.ViewModels;

namespace ChatRoom.Lib.ViewModels.Chat
{
    public class ChatHubUserViewModel : ViewModelBase<MessengerContext, SiocChathubUser, ChatHubUserViewModel>
    {
        #region Properties
        [Required]
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [Required]
        [JsonProperty("username")]
        public string NickName { get; set; }
        [JsonIgnore]
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
        [Required]
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }
        [JsonProperty("joinedDate")]
        public System.DateTime JoinedDate { get; set; }

        //View
        public List<ChatHubRoomViewModel> Rooms { get; set; } = new List<ChatHubRoomViewModel>();
        public bool InCall;

        #endregion
        public ChatHubUserViewModel(SiocChathubUser model
            , MessengerContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ChatHubUserViewModel()
        {
        }

        #region Overrides
        public override void ExpandView(MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            Rooms = ChatHubRoomViewModel.Repository.GetModelListBy(r => r.UserId == UserId
            , _context, _transaction: _transaction).Data;
        }

        public override SiocChathubUser ParseModel()
        {
            if (JoinedDate == default(DateTime))
            {
                JoinedDate = DateTime.UtcNow;
            }

            return base.ParseModel();
        }

        public override RepositoryResponse<bool> SaveSubModels(SiocChathubUser parent, MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };

            foreach (var room in Rooms)
            {
                var saveResult = room.SaveModel(false, _context, _transaction);
                result.IsSucceed = saveResult.IsSucceed;
                if (!saveResult.IsSucceed)
                {
                    Errors.AddRange(saveResult.Errors);
                    Ex = saveResult.Ex;
                    break;
                }
            }

            return result;
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocChathubUser parent, MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };

            foreach (var room in Rooms)
            {
                var saveResult = await room.SaveModelAsync(false, _context, _transaction);
                result.IsSucceed = saveResult.IsSucceed;
                result.Data = result.IsSucceed;
                if (!saveResult.IsSucceed)
                {
                    Errors.AddRange(saveResult.Errors);
                    Ex = saveResult.Ex;
                    break;
                }
            }

            return result;
        }


        #endregion

        #region Expands

        public async Task<ApiResult<TeamChatConnectedData>> JoinChatAsync()
        {
            var context = new MessengerContext();
            var transaction = context.Database.BeginTransaction();

            var result = new ApiResult<TeamChatConnectedData>();
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.Connect);
            try
            {
                var getTeams = await TeamInfoViewModel.Repository.GetModelListByAsync(
                            t => t.SiocChatTeamMember.Count(
                                m => m.MemberId == UserId && m.Status == (int)MemberStatus.Membered) > 0
                            , "CreatedDate", OrderByDirection.Descending
                            , PageSize, PageIndex
                            , _context: context, _transaction: transaction);
                var teams = getTeams.Data ?? new PaginationModel<TeamInfoViewModel>();

                foreach (var team in teams.Items)
                {
                    string roomName = string.Format("Team_{0}", team.Id);
                    team.CurrentMember = (await TeamMemberViewModel.Repository.GetSingleModelAsync(
                        m => m.MemberId == UserId, _context: context, _transaction: transaction)).Data;
                    team.CurrentMember.IsOnline = true;
                    team.IsNewMessage = TeamMessageViewModel.Repository.Count(
                                    m =>
                                    m.TeamId == team.Id
                                    && m.CreatedDate > team.CurrentMember.SeenMessageDate).Data > 0;
                    Rooms.Add(new ChatHubRoomViewModel()
                    {
                        UserId = UserId,
                        RoomName = roomName,
                        RoomTitle = team.Name,
                        TeamId = team.Id,
                        JoinedDate = DateTime.UtcNow
                    });
                }
                var saveResult = await SaveModelAsync(true, _context: context, _transaction: transaction);
                if (saveResult.IsSucceed)
                {

                    var getOtherTeams = await TeamInfoViewModel.Repository.GetModelListByAsync(
                        t => t.SiocChatTeamMember.Count(
                            m => m.MemberId == UserId && m.Status == (int)MemberStatus.Membered) == 0
                        , "CreatedDate", OrderByDirection.Descending
                        , PageSize, PageIndex
                        , _context: context, _transaction: transaction);
                    var otherTeams = getOtherTeams.Data ?? new PaginationModel<TeamInfoViewModel>();

                    result = new ApiResult<TeamChatConnectedData>()
                    {
                        Status = saveResult.IsSucceed ? 1 : 0,
                        ResponseKey = string.Format("{0}", action),
                        Data = new TeamChatConnectedData()
                        {
                            //Invitations = null,                            
                            TotalInvitation = TeamMemberViewModel.Repository.Count(
                                m => m.MemberId == UserId && m.Status == (int)MemberStatus.Invited).Data,
                            IsCreatedTeam = TeamViewModel.Repository.Count(t => t.HostId == UserId).Data > 0,
                            Teams = teams,
                            OtherTeams = otherTeams
                        },
                        Errors = saveResult.Errors
                    };
                    transaction.Commit();
                    return result;
                }
                else
                {
                    transaction.Rollback();
                    result.Errors.AddRange(saveResult.Errors);
                    return result;
                }
            }
            catch
            {
                transaction.Rollback();
                return result;
            }
            finally
            {
                transaction.Dispose();
                context.Dispose();

            }
        }

        #endregion

    }
    public class UserCall
    {
        public List<ChatHubUserViewModel> Users;
    }

    public class CallOffer
    {
        public ChatHubUserViewModel Caller;
        public ChatHubUserViewModel Callee;
    }
}
