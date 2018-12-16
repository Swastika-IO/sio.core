using System;
using System.Collections.Generic;

namespace Sio.Cms.Messenger.Models.Data
{
    public partial class SioMessengerHubRoom
    {
        public SioMessengerHubRoom()
        {
            SioMessengerMessage = new HashSet<SioMessengerMessage>();
            SioMessengerNavRoomUser = new HashSet<SioMessengerNavRoomUser>();
        }

        public Guid Id { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string HostId { get; set; }
        public bool IsOpen { get; set; }
        public DateTime? LastModified { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public string Title { get; set; }

        public ICollection<SioMessengerMessage> SioMessengerMessage { get; set; }
        public ICollection<SioMessengerNavRoomUser> SioMessengerNavRoomUser { get; set; }
    }
}
