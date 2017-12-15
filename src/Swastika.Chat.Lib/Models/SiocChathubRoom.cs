using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class SiocChathubRoom
    {
        public string RoomName { get; set; }
        public string UserId { get; set; }
        public string RoomTitle { get; set; }
        public DateTime JoinedDate { get; set; }
        public int TeamId { get; set; }

        public SiocChathubUser User { get; set; }
    }
}
