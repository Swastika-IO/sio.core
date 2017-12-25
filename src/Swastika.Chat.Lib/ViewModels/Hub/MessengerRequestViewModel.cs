using ChatRoom.Lib.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swastika.Messenger.Lib.ViewModels.Hub
{
    public class MessengerRequestViewModel
    {
        [Required]
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [Required]
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonProperty("memberStatus")]
        public MemberStatus MemberStatus { get; set; }
        [JsonProperty("isOnline")]
        public bool IsOnline { get; set; }
        [JsonProperty("userAlvatar")]
        public string UserAvatar { get; set; }
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }
        [JsonProperty("keyword")]
        public string Keyword { get; set; }
    }
}
