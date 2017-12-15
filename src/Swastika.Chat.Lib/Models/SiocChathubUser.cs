using System;
using System.Collections.Generic;

namespace Swastika.Messenger.Lib.Models
{
    public partial class SiocChathubUser
    {
        public SiocChathubUser()
        {
            SiocChathubRoom = new HashSet<SiocChathubRoom>();
        }

        public string UserId { get; set; }
        public string NickName { get; set; }
        public string ConnectionId { get; set; }
        public DateTime JoinedDate { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<SiocChathubRoom> SiocChathubRoom { get; set; }
    }
}
