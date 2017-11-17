using Swastika.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.IO.Cms.Lib.ViewModels
{
    public class AccessTokenViewModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public string client_id { get; set; }
        public DateTime issued { get; set; }
        public DateTime expires { get; set; }
        public string deviceId { get; set; }
        public ApplicationUser userData { get; set; }
    }
}
