using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Messenger.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Common.Helper;
using Messenger.Lib.Helpers;

namespace Swastika.Messenger.Lib.ViewModels.Messenger
{
    public class MessengerRoomViewModel : ViewModelBase<MessengerContext, MessengerHubRoom, MessengerRoomViewModel>
    {
        #region Properties
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("hostId")]
        public string HostId { get; set; }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonIgnore]
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

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

        #endregion

        #endregion
        public MessengerRoomViewModel()
        {
        }

        public MessengerRoomViewModel(MessengerHubRoom model
            , MessengerContext _context = null, IDbContextTransaction _transaction = null) : 
            base(model, _context, _transaction)
        {
        }


    }

    public class MessengerRoomDetailsViewModel 
        : ViewModelBase<MessengerContext, MessengerHubRoom, MessengerRoomDetailsViewModel>
    {
        #region Properties

        #region Models


        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("hostId")]
        public string HostId { get; set; }
        [JsonIgnore]
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }
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

        [JsonProperty("users")]
        public List<MessengerUserViewModel> Users { get; set; }
        #endregion

        #endregion

        #region Contructors

        public MessengerRoomDetailsViewModel()
        {
        }

        public MessengerRoomDetailsViewModel(MessengerHubRoom model
            , MessengerContext _context = null, IDbContextTransaction _transaction = null) :
            base(model, _context, _transaction)
        {
        }


        #endregion

        #region Overrides

        public override void ExpandView(MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getUsers = MessengerUserViewModel.Repository.GetModelListBy(
                r => r.MessengerNavRoomUser.Count(nav => nav.RoomId == Id) > 0,
                _context, _transaction);
            Users = getUsers.Data ?? new List<MessengerUserViewModel>();
        }

        #endregion

        #region Expands



        #endregion
    }
}
