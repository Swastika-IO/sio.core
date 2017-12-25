using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class MessengerTeam
    {
        public MessengerTeam()
        {
            MessengerMessage = new HashSet<MessengerMessage>();
            MessengerNavTeamUser = new HashSet<MessengerNavTeamUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Type { get; set; }
        public string HostId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsOpen { get; set; }

        public ICollection<MessengerMessage> MessengerMessage { get; set; }
        public ICollection<MessengerNavTeamUser> MessengerNavTeamUser { get; set; }
    }
}
