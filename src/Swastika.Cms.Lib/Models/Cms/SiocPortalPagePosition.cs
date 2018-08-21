using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocPortalPagePosition
    {
        public int PositionId { get; set; }
        public int PortalPageId { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocPosition Position { get; set; }
        public SiocPortalPage SiocPortalPage { get; set; }
    }
}
