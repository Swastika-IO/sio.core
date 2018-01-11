using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Cms.Lib.Models.Account
{
    public partial class AspNetUserLogins
    {
        [Key]
        public string Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ApplicationUserId { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public AspNetUsers ApplicationUser { get; set; }
        public AspNetUsers User { get; set; }
    }
}
