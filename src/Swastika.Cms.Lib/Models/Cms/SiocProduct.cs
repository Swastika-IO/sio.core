using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocProduct
    {
        public SiocProduct()
        {
            SiocCategoryProduct = new HashSet<SiocCategoryProduct>();
            SiocModuleProduct = new HashSet<SiocModuleProduct>();
            SiocProductMedia = new HashSet<SiocProductMedia>();
            SiocProductModule = new HashSet<SiocProductModule>();
        }

        public string Id { get; set; }
        public string Specificulture { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Excerpt { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string ExtraProperties { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public double Price { get; set; }
        public string PriceUnit { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string Source { get; set; }
        public string Tags { get; set; }
        public string Template { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int? Views { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
        public ICollection<SiocCategoryProduct> SiocCategoryProduct { get; set; }
        public ICollection<SiocModuleProduct> SiocModuleProduct { get; set; }
        public ICollection<SiocProductMedia> SiocProductMedia { get; set; }
        public ICollection<SiocProductModule> SiocProductModule { get; set; }
    }
}
