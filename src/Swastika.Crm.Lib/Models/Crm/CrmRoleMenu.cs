using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmRoleMenu
    {
        public string Role { get; set; }
        public int MenuId { get; set; }

        public CrmMenu Menu { get; set; }
    }
}
