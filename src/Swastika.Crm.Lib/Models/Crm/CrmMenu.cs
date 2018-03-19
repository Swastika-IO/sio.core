using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmMenu
    {
        public CrmMenu()
        {
            CrmRoleMenu = new HashSet<CrmRoleMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public short Level { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }

        public ICollection<CrmRoleMenu> CrmRoleMenu { get; set; }
    }
}
