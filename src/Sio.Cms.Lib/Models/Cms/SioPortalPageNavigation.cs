using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPortalPageNavigation
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioPortalPage IdNavigation { get; set; }
        public SioPortalPage Parent { get; set; }
    }
}
