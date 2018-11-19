using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPortalPageRole
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int PageId { get; set; }
        public int Priority { get; set; }
        public string RoleId { get; set; }
        public int Status { get; set; }

        public SioPortalPage Page { get; set; }
    }
}
