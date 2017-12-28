using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class MessengerNavRoomUser
    {
        public Guid RoomId { get; set; }
        public string UserId { get; set; }
        public DateTime JoinedDate { get; set; }

        public MessengerHubRoom Room { get; set; }
        public MessengerUser User { get; set; }
    }
}
