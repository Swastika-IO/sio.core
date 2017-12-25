using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Messenger.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Common.Helper;
using ChatRoom.Lib.Helpers;

namespace Swastika.Messenger.Lib.ViewModels.Messenger
{
    public class MessengerTeamViewModel : ViewModelBase<MessengerContext, MessengerTeam, MessengerTeamViewModel>
    {
        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("hostId")]
        public string HostId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("isOpen")]
        public bool? IsOpen { get; set; }

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

        #region Contructors

        public MessengerTeamViewModel() : base()
        {
        }

        public MessengerTeamViewModel(MessengerTeam model, MessengerContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }

    public class MessengerTeamDetailsViewModel: ViewModelBase<MessengerContext, MessengerTeam, MessengerTeamDetailsViewModel>
    {

        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("hostId")]
        public string HostId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("isOpen")]
        public bool? IsOpen { get; set; }

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

        public MessengerTeamDetailsViewModel() : base()
        {
        }

        public MessengerTeamDetailsViewModel(MessengerTeam model, MessengerContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getUsers = MessengerUserViewModel.Repository.GetModelListBy(
                r => r.MessengerNavTeamUser.Count(nav => nav.TeamId == Id) > 0,
                _context, _transaction);
            Users = getUsers.Data ?? new List<MessengerUserViewModel>();
        }

        #endregion

        #region Expands



        #endregion

    }
}
