using Newtonsoft.Json;
using ChatRoom.Lib.Helpers;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Messenger.Lib.Models;
using Swastika.IO.Common.Helper;

namespace ChatRoom.Lib.ViewModels.Chat
{
    public class TeamMessageViewModel : ViewModelBase<MessengerContext, SiocChatTeamMessage, TeamMessageViewModel>
    {
        public TeamMessageViewModel()
        {
        }

        public TeamMessageViewModel(SiocChatTeamMessage model
            , MessengerContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("username")]
        public string Nickname { get; set; }
        [JsonIgnore]
        public string UserAvatar { get; set; }
        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(UserAvatar) && UserAvatar.IndexOf("http") == -1)
                {
                    return CommonHelper.GetFullPath(new string[] {
                    ChatConstants.Domain,  UserAvatar
                });
                }
                else
                {
                    return !string.IsNullOrEmpty(UserAvatar) ? UserAvatar : ChatConstants.DefaultAvatar;
                }

            }
            set
            {
                UserAvatar = value;
            }
        }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }
        [JsonProperty("notificationType")]
        public NotificationType NotificationType { get; set; }
        [JsonProperty("createdDate")]
        public System.DateTime CreatedDate { get; set; }

        public override void ExpandView(MessengerContext _context = null, IDbContextTransaction _transaction = null)
        {
            //var user = _context?.AspNetUsers.FirstOrDefault(m => m.Id == UserId);
            //UserAvatar = user?.Avatar;
        }

        public override SiocChatTeamMessage ParseModel()
        {
            if (string.IsNullOrEmpty(Id))
            {
                CreatedDate = DateTime.UtcNow;
                Id = Guid.NewGuid().ToString();
            }

            return base.ParseModel();
        }

        #region Expands


        #endregion
    }
}
