using System;
using Swastika.Infrastructure.Data.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Messenger.Lib.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChatRoom.Lib.ViewModels.Chat
{
    public class ChatHubRoomViewModel : ViewModelBase<ChatContext, SiocChathubRoom, ChatHubRoomViewModel>
    {
        #region Properties
        [Required]
        [JsonProperty("roomName")]
        public string RoomName { get; set; }
        [Required]
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("roomTitle")]
        public string RoomTitle { get; set; }

        [JsonProperty("joinedDate")]
        public DateTime JoinedDate { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        #endregion
        public ChatHubRoomViewModel(SiocChathubRoom model, ChatContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }

        public ChatHubRoomViewModel()
        {
        }
    }
}
