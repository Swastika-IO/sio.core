using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPortalPagePosition
    {
        public int PositionId { get; set; }
        public int PortalPageId { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioPortalPage PortalPage { get; set; }
        public SioPosition Position { get; set; }
    }
}
