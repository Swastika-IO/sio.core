using System;
using System.Collections.Generic;

namespace Sio.Cms.Messenger.Models.Data
{
    public partial class SioMessengerTeam
    {
        public SioMessengerTeam()
        {
            SioMessengerMessage = new HashSet<SioMessengerMessage>();
            SioMessengerNavTeamUser = new HashSet<SioMessengerNavTeamUser>();
        }

        public int Id { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public string HostId { get; set; }
        public bool? IsOpen { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public ICollection<SioMessengerMessage> SioMessengerMessage { get; set; }
        public ICollection<SioMessengerNavTeamUser> SioMessengerNavTeamUser { get; set; }
    }
}
