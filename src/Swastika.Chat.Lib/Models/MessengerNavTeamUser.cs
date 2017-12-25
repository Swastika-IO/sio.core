using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class MessengerNavTeamUser
    {
        public int TeamId { get; set; }
        public string UserId { get; set; }
        public DateTime JoinedDate { get; set; }
        public int Status { get; set; }
        public DateTime? LastModified { get; set; }

        public MessengerTeam Team { get; set; }
        public MessengerUser User { get; set; }
    }
}
