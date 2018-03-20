using System;
using System.Collections.Generic;

namespace Swastika.Cms.Web.Mvc.Models.Cms
{
    public partial class SiocRelatedProduct
    {
        public string SourceProductId { get; set; }
        public string RelatedProductId { get; set; }
        public string Specificulture { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }

        public SiocProduct S { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
