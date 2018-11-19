using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPagePage
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioPage SioPage { get; set; }
        public SioPage SioPageNavigation { get; set; }
    }
}
