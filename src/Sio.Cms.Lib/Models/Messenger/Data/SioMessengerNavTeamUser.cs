using System;
using System.Collections.Generic;

namespace Sio.Cms.Messenger.Models.Data
{
    public partial class SioMessengerNavTeamUser
    {
        public int TeamId { get; set; }
        public string UserId { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int Status { get; set; }

        public SioMessengerTeam Team { get; set; }
        public SioMessengerUser User { get; set; }
    }
}
