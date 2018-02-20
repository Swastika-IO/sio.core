using System;
using System.Collections.Generic;
using System.Text;
using Swastika.Messenger.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Common.Helper;
using Messenger.Lib.Helpers;
using System.Linq;
using Swastika.Domain.Core.ViewModels;
using System.Threading.Tasks;
using Swastika.Messenger.Lib.ViewModels.Hub;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Messenger.Lib.ViewModels.Messenger
{
    public class MessengerUserViewModel : ViewModelBase<MessengerContext, MessengerUser, MessengerUserViewModel>
    {
        #region Properties
        #region Models
        [Required]
        [JsonProperty("id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        #endregion

        #region Views

        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (Avatar != null && Avatar.IndexOf("http") == -1)
                {
                    return CommonHelper.GetFullPath(new string[] {
                    MessengerConstants.Domain,  Avatar
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


        [JsonProperty("isOnline")]
        public bool IsOnline
        {
            get
            {
                return !string.IsNullOrEmpty(ConnectionId);
            }
        }
        #endregion

        #endregion

        #region Contructors
        public MessengerUserViewModel() : base()
        {
        }

        public MessengerUserViewModel(MessengerUser model, MessengerContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
        #endregion

        #region Overrides


        #endregion

        #region Expands

        #endregion

    }

    public class MessengerUserDetailsViewModel : ViewModelBase<MessengerContext, MessengerUser, MessengerUserDetailsViewModel>
    {
        #region Properties
        [Required]
        [JsonProperty("id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }


        #region Views

        [JsonProperty("myTeams")]
        public List<MessengerTeamViewModel> MyTeams { get; set; }

        [JsonProperty("myRooms")]
        public List<MessengerRoomViewModel> MyRooms { get; set; }
        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (Avatar != null && Avatar.IndexOf("http") == -1)
                {
                    return CommonHelper.GetFullPath(new string[] {
                    MessengerConstants.Domain,  Avatar
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


        #endregion

        #region Contructors
        public MessengerUserDetailsViewModel() : base()
        {
        }

        public MessengerUserDetailsViewModel(MessengerUser model, MessengerContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }
        #endregion

        #region Overrides

        public override void ExpandView(MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMyTeams = MessengerTeamViewModel.Repository.GetModelListBy(
                t => t.MessengerNavTeamUser.Count(nav => nav.UserId == Id) > 0, _context, _transaction);
            MyTeams = getMyTeams.Data ?? new List<MessengerTeamViewModel>();

            var getMyRooms = MessengerRoomViewModel.Repository.GetModelListBy(
                t => t.MessengerNavRoomUser.Count(nav => nav.UserId == Id) > 0, _context, _transaction);
            MyRooms = getMyRooms.Data ?? new List<MessengerRoomViewModel>();
        }

        #endregion

        #region Expands

        public static async Task<RepositoryResponse<MessengerUserDetailsViewModel>> JoinChatAsync(MessengerRequestViewModel request)
        {
            var context = new MessengerContext();
            var transaction = context.Database.BeginTransaction();

            RepositoryResponse<MessengerUserDetailsViewModel> result = new RepositoryResponse<MessengerUserDetailsViewModel>();
            string action = Enum.GetName(typeof(MessageReponseKey), MessageReponseKey.Connect);
            try
            {
                var getUser = await Repository.GetSingleModelAsync(
                     u => u.Name == request.UserName
                     , context, transaction
                     );

                if (getUser.IsSucceed)
                {
                    var user = getUser.Data;
                    //Update ConnectionId if changed
                    user.Avatar = request.UserAvatar ?? user.Avatar;
                    user.ConnectionId = request.ConnectionId;
                    result = await user.SaveModelAsync(false, context, transaction);

                }
                else
                {
                    var user = new MessengerUserDetailsViewModel()
                    {
                        Id = request.UserId ?? Guid.NewGuid().ToString(),
                        Name = request.UserName,
                        Avatar = request.UserAvatar,
                        ConnectionId = request.ConnectionId,
                        CreatedDate = DateTime.UtcNow,
                        MyRooms = new List<MessengerRoomViewModel>(),
                        MyTeams = new List<MessengerTeamViewModel>()
                    };
                    result = await user.SaveModelAsync(false, context, transaction);
                }

                if (result.IsSucceed)
                {
                    transaction.Commit();
                    return result;
                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                transaction.Rollback();
                result.Exception = ex;
                result.IsSucceed = false;
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


}
