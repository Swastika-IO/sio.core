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
    public class MessengerMessageViewModel 
        : ViewModelBase<MessengerContext, MessengerMessage, MessengerMessageViewModel>
    {
        #region Properties


        #region Models
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("userAvatar")]
        public string UserAvatar { get; set; }

        [JsonProperty("roomId")]
        public Guid? RoomId { get; set; }
        [JsonProperty("teamId")]
        public int? TeamId { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public MessengerMessageViewModel() : base()
        {
        }

        public MessengerMessageViewModel(MessengerMessage model, MessengerContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override MessengerMessage ParseModel()
        {
            if (Id== default(Guid))
            {
                Id = Guid.NewGuid();
                CreatedDate = DateTime.UtcNow;
            }
            return base.ParseModel();
        }

        #endregion

        #region Expands

        #endregion

    }
}
