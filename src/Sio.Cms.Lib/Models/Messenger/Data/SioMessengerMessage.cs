using System;
using System.Collections.Generic;

namespace Sio.Cms.Messenger.Models.Data
{
    public partial class SioMessengerMessage
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? RoomId { get; set; }
        public int? TeamId { get; set; }
        public string UserId { get; set; }

        public SioMessengerHubRoom Room { get; set; }
        public SioMessengerTeam Team { get; set; }
        public SioMessengerUser User { get; set; }
    }
}
