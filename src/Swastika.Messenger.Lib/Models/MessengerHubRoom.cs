using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class MessengerHubRoom
    {
        public MessengerHubRoom()
        {
            MessengerMessage = new HashSet<MessengerMessage>();
            MessengerNavRoomUser = new HashSet<MessengerNavRoomUser>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HostId { get; set; }
        public int? TeamId { get; set; }
        public string Avatar { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

        public ICollection<MessengerMessage> MessengerMessage { get; set; }
        public ICollection<MessengerNavRoomUser> MessengerNavRoomUser { get; set; }
    }
}
