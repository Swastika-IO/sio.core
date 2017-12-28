using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocBanner
    {
        public string Id { get; set; }
        public string Specificulture { get; set; }
        public string Url { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public string ModifiedBy { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
    }
}
