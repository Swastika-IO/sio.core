using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocRelatedProduct
    {
        public string SourceId { get; set; }
        public string DestinationId { get; set; }
        public string Specificulture { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocProduct S { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
