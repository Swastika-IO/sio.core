using Newtonsoft.Json;
using Swastika.Infrastructure.Data.ViewModels;
using System.Linq;
using Swastika.Domain.Core.Models;
using ChatRoom.Lib.Helpers;
using Microsoft.Data.OData.Query;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Swastika.Messenger.Lib.Models;
using Swastika.IO.Common.Helper;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.IO.Domain.Core.ViewModels;

namespace ChatRoom.Lib.ViewModels.Chat
{
    public class TeamInfoViewModel : ViewModelBase<ChatContext, SiocChatTeam, TeamInfoViewModel>
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public string Avatar { get; set; }

        [JsonProperty("hostId")]
        public string HostId { get; set; }
        [JsonProperty("createdDate")]
        public System.DateTime CreatedDate { get; set; }
        [JsonProperty("isNewMessage")]
        public bool IsNewMessage { get; set; }
        [JsonProperty("totalMember")]
        public int TotalMember { get; set; }
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }
        [JsonProperty("maxTeamMember")]
        public int MaxTeamMember { get; set; }

        //View
        //public PaginationModel<FETeamMemberViewModel> Members { get; set; }
        [JsonProperty("currentMember")]
        public TeamMemberViewModel CurrentMember { get; set; }
        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (Avatar != null && Avatar.IndexOf("http") == -1)
                {
                    return CommonHelper.GetFullPath(new string[] {
                    ChatConstants.Domain,  Avatar
                });
                }
                else
                {
                    return Avatar;
                }
            }
            set
            {
                Avatar = value;
            }
        }

        #endregion

        #region Contructors

        public TeamInfoViewModel()
        {
        }

        public TeamInfoViewModel(SiocChatTeam model, ChatContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

    }

    public class TeamViewModel : ViewModelBase<ChatContext, SiocChatTeam, TeamViewModel>
    {
        public TeamViewModel()
        {
        }

        public TeamViewModel(SiocChatTeam model, ChatContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }

        public TeamViewModel(SiocChatTeam model, bool isLazyLoad, ChatContext _context = null, IDbContextTransaction _transaction = null) : base(model, isLazyLoad, _context, _transaction)
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public string Avatar { get; set; }

        [JsonProperty("hostId")]
        public string HostId { get; set; }
        [JsonProperty("createdDate")]
        public System.DateTime CreatedDate { get; set; }
        [JsonProperty("isNewMessage")]
        public bool IsNewMessage { get; set; }
        [JsonProperty("totalMember")]
        public int TotalMember { get; set; }
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }
        [JsonProperty("maxTeamMember")]
        public int MaxTeamMember { get; set; }
        //View
        //public PaginationModel<FETeamMemberViewModel> Members { get; set; }
        [JsonProperty("avatarUrl")]
        public string AvatarUrl {
            get
            {
                if (Avatar != null && Avatar.IndexOf("http") == -1)
                {
                    return CommonHelper.GetFullPath(new string[] {
                    ChatConstants.Domain,  Avatar
                });
                }
                else
                {
                    return Avatar;
                }
            }
            set
            {
                Avatar = value;
            }
        }
        public FileStreamViewModel AvatarFileStream { get; set; }

        public override void ExpandView(ChatContext _context = null, IDbContextTransaction _transaction = null)
        {
            var members = _context.SiocChatTeamMember.Where(m => m.TeamId == Id);
            MaxTeamMember = 50;
            TotalMember = members.Count();
        }

        public override SiocChatTeam ParseModel()
        {
            CreatedDate = CreatedDate == default(DateTime) ? DateTime.UtcNow : CreatedDate;
            if (!string.IsNullOrEmpty(AvatarFileStream?.Base64))
            {
               

                string folder = CommonHelper.GetFullPath(new string[]
                {
                    "Uploads", "Avatars", DateTime.UtcNow.ToString("dd-MM-yyyy")
                });

                
                string filename = CommonHelper.GetRandomName(AvatarFileStream?.Name);
                bool saveThumbnail = CommonHelper.SaveFileBase64(folder, filename, AvatarFileStream.Base64);
                if (saveThumbnail)
                {
                    Avatar = CommonHelper.GetFullPath(new string[] { folder, filename });
                }
            }
            return base.ParseModel();
        }

        public override RepositoryResponse<bool> SaveSubModels(SiocChatTeam parent, ChatContext _context = null, IDbContextTransaction _transaction = null)
        {
            var host = new TeamMemberViewModel()
            {
                TeamId = parent.Id,
                MemberId = parent.HostId,
                CreatedDate = DateTime.UtcNow,
                Status = MemberStatus.Membered
            };
            var saveResult = host.SaveModel(false, _context, _transaction);

            return new RepositoryResponse<bool>()
            {
                IsSucceed = saveResult.IsSucceed,
                Data = saveResult.IsSucceed,
                Ex = saveResult.Ex,
                Errors = saveResult.Errors
            };
            
        }


        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocChatTeam parent, ChatContext _context = null, IDbContextTransaction _transaction = null)
        {
            var host = new TeamMemberViewModel()
            {
                TeamId = parent.Id,
                MemberId = parent.HostId,
                CreatedDate = DateTime.UtcNow,
                Status = MemberStatus.Membered
            };
            var saveResult = await host.SaveModelAsync(false, _context, _transaction);

            return new RepositoryResponse<bool>()
            {
                IsSucceed = saveResult.IsSucceed,
                Data = saveResult.IsSucceed,
                Ex = saveResult.Ex,
                Errors = saveResult.Errors
            };

        }
    }

    public class TeamChatViewModel : ViewModelBase<ChatContext, SiocChatTeam, TeamChatViewModel>
    {
        public TeamChatViewModel()
        {
        }

        public TeamChatViewModel(SiocChatTeam model, ChatContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        public TeamChatViewModel(SiocChatTeam model, bool isLazyLoad, ChatContext _context = null, IDbContextTransaction _transaction = null) : base(model, isLazyLoad, _context, _transaction)
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("hostId")]
        public string HostId { get; set; }
        [JsonProperty("createdDate")]
        public System.DateTime CreatedDate { get; set; }
        [JsonProperty("isNewMessage")]
        public bool IsNewMessage { get; set; }
        [JsonProperty("totalMember")]
        public int TotalMember { get; set; }
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }
        [JsonProperty("maxTeamMember")]
        public int MaxTeamMember { get; set; }

        //View
        [JsonProperty("members")]
        public PaginationModel<TeamMemberViewModel> Members { get; set; }

        [JsonProperty("totalRequest")]
        public int TotalRequest { get; set; }
        //[JsonProperty("requests")]
        //public List<FETeamMemberViewModel> Requests { get; set; }
        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
        [JsonProperty("messages")]
        public PaginationModel<TeamMessageViewModel> Messages { get; set; }


        public override void ExpandView(
            ChatContext _context = null, IDbContextTransaction _transaction = null)
        {

            TotalMember = TeamMemberViewModel.Repository.Count(m => m.TeamId == Id, _context, _transaction).Data;
            MaxTeamMember = 50;
            PageSize = 50;
            var getMembers = TeamMemberViewModel.Repository.GetModelListBy(
                m => m.TeamId == Id && m.Status == (int)MemberStatus.Membered
               , "Id", OrderByDirection.Descending
               , PageSize, 0
               , _context, _transaction
               );
            Members = getMembers.Data;
            var getMessages = TeamMessageViewModel.Repository.GetModelListBy(
                m => m.TeamId == Id
                , "CreatedDate", OrderByDirection.Descending
                , PageSize, 0, _context, _transaction);
            Messages = getMessages.Data ?? new PaginationModel<TeamMessageViewModel>();
            Messages.Items.Reverse();
        }

        #region Expands

        public static async Task<ApiResult<TeamChatViewModel>> GetByUserIdAsync(ChatRequest request,
            ChatContext _context = null, IDbContextTransaction _transaction = null)
        {
            string action = Enum.GetName(typeof(TeamMessageReponseKey), TeamMessageReponseKey.GetTeam);
            ApiResult<TeamChatViewModel> result = null;
            bool isRoot = _context == null;
            var context = _context ?? new ChatContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                if (TeamMemberViewModel.Repository.CheckIsExists(
                    m => m.TeamId == request.TeamId && m.MemberId == request.UserId && m.Status == (int)MemberStatus.Membered
                    , _context: context, _transaction: transaction
                    ))
                {
                    var getTeam = await Repository.GetSingleModelAsync(
                        t => t.Id == request.TeamId);

                    if (getTeam.IsSucceed)
                    {
                        var team = getTeam.Data;
                        //team.IsNewMessage = TeamMessageViewModel.Repository.Count(
                        //    //team.Id, request.MemberId
                        //    m =>
                        //    m.SiocChatTeam.SiocChatTeamMember.FirstOrDefault(
                        //        mem => mem.MemberId == request.UserId) != null &&
                        //    m.CreatedDate > m.SiocChatTeam.SiocChatTeamMember.FirstOrDefault(
                        //        msg => msg.MemberId == request.UserId && msg.TeamId == team.Id).SeenDate
                        //    , _context: context, _transaction: transaction
                        //        ).Data > 0;
                        team.IsAdmin = request.UserId == team.HostId;
                        if (team.IsAdmin)
                        {

                            team.TotalRequest = TeamMemberViewModel.Repository.Count(
                                m => m.TeamId == request.TeamId && m.Status == (int)MemberStatus.Requested
                                , _context: context, _transaction: transaction
                                ).Data;
                        }

                        result = new ApiResult<TeamChatViewModel>()
                        {
                            Status = 1,
                            ResponseKey = string.Format("{0}", action),
                            Data = team
                        };
                    }
                    else
                    {
                        result = new ApiResult<TeamChatViewModel>()
                        {
                            Status = 0,
                            ResponseKey = TeamMessageReponseKey.NotMembered.ToString(),
                            Data = null,
                            Errors = null
                        };
                    }
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
                }

                if (result.Status==0)
                {
                    if (isRoot)
                    {
                        transaction.Rollback();
                    }
                    
                }
                else
                {
                    if (isRoot)
                    {
                        transaction.Commit();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                if (isRoot)
                {
                    transaction.Rollback();
                }
                return result;
            }
            finally
            {
                if (isRoot)
                {
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion
    }
}
