using Swastika.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.IO.Cms.Lib.ViewModels
{
    public class AccessTokenViewModel
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public string Refresh_token { get; set; }
        public int Expires_in { get; set; }
        public string Client_id { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }
        public string DeviceId { get; set; }
        public ApplicationUser UserData { get; set; }
    }
}
