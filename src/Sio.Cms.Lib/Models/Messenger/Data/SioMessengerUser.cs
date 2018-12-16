using System;
using System.Collections.Generic;

namespace Sio.Cms.Messenger.Models.Data
{
    public partial class SioMessengerUser
    {
        public SioMessengerUser()
        {
            SioMessengerMessage = new HashSet<SioMessengerMessage>();
            SioMessengerNavRoomUser = new HashSet<SioMessengerNavRoomUser>();
            SioMessengerNavTeamUser = new HashSet<SioMessengerNavTeamUser>();
        }

        public string Id { get; set; }
        public string FacebookId { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public ICollection<SioMessengerMessage> SioMessengerMessage { get; set; }
        public ICollection<SioMessengerNavRoomUser> SioMessengerNavRoomUser { get; set; }
        public ICollection<SioMessengerNavTeamUser> SioMessengerNavTeamUser { get; set; }
    }
}
