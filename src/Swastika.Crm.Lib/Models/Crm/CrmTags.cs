using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmTags
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public string Content { get; set; }
        public bool? IsView { get; set; }
        public string SeokeyWords { get; set; }
    }
}
