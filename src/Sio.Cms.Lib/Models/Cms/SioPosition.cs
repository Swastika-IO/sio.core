using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPosition
    {
        public SioPosition()
        {
            SioPagePosition = new HashSet<SioPagePosition>();
            SioPortalPagePosition = new HashSet<SioPortalPagePosition>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public ICollection<SioPagePosition> SioPagePosition { get; set; }
        public ICollection<SioPortalPagePosition> SioPortalPagePosition { get; set; }
    }
}
