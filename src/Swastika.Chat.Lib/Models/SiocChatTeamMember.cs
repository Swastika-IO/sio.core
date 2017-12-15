using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class SiocChatTeamMember
    {
        public int TeamId { get; set; }
        public string MemberId { get; set; }
        public bool IsAdmin { get; set; }
        public int Status { get; set; }
        public int? BanDays { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? BannedDate { get; set; }
        public DateTime? SeenDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SeenMessageDate { get; set; }
        public DateTime? SeenRequestDate { get; set; }
        public DateTime? SeenInviteDate { get; set; }

        public AspNetUsers Member { get; set; }
        public SiocChatTeam Team { get; set; }
    }
}
