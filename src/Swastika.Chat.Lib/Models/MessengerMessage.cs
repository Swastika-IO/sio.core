using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class MessengerMessage
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid? RoomId { get; set; }
        public int? TeamId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public MessengerHubRoom Room { get; set; }
        public MessengerTeam Team { get; set; }
        public MessengerUser User { get; set; }
    }
}
