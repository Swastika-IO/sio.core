using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class SiocChatTeamMessage
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Nickname { get; set; }
        public string UserAvatar { get; set; }
        public int TeamId { get; set; }
        public string Message { get; set; }
        public int NotificationType { get; set; }
        public int MessageType { get; set; }
        public DateTime CreatedDate { get; set; }

        public SiocChatTeam Team { get; set; }
        public AspNetUsers User { get; set; }
    }
}
