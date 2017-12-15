using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class SiocChatTeam
    {
        public SiocChatTeam()
        {
            SiocChatTeamMember = new HashSet<SiocChatTeamMember>();
            SiocChatTeamMessage = new HashSet<SiocChatTeamMessage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Type { get; set; }
        public string HostId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsOpen { get; set; }
        public int CountryId { get; set; }

        public ICollection<SiocChatTeamMember> SiocChatTeamMember { get; set; }
        public ICollection<SiocChatTeamMessage> SiocChatTeamMessage { get; set; }
    }
}
