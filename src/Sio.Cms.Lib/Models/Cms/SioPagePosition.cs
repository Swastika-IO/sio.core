using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPagePosition
    {
        public int PositionId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioPage SioPage { get; set; }
        public SioPosition Position { get; set; }
    }
}
