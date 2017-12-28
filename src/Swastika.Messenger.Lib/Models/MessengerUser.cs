using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class MessengerUser
    {
        public MessengerUser()
        {
            MessengerMessage = new HashSet<MessengerMessage>();
            MessengerNavRoomUser = new HashSet<MessengerNavRoomUser>();
            MessengerNavTeamUser = new HashSet<MessengerNavTeamUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string ConnectionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

        public ICollection<MessengerMessage> MessengerMessage { get; set; }
        public ICollection<MessengerNavRoomUser> MessengerNavRoomUser { get; set; }
        public ICollection<MessengerNavTeamUser> MessengerNavTeamUser { get; set; }
    }
}
