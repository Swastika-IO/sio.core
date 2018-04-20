using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocRelatedProduct
    {
        public string SourceProductId { get; set; }
        public string RelatedProductId { get; set; }
        public string Specificulture { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocProduct S { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
