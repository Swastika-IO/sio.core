using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioProduct
    {
        public SioProduct()
        {
            SioComment = new HashSet<SioComment>();
            SioModuleProduct = new HashSet<SioModuleProduct>();
            SioOrderItem = new HashSet<SioOrderItem>();
            SioPageProduct = new HashSet<SioPageProduct>();
            SioProductMedia = new HashSet<SioProductMedia>();
            SioProductModule = new HashSet<SioProductModule>();
            SioRelatedProductSioProduct = new HashSet<SioRelatedProduct>();
            SioRelatedProductS = new HashSet<SioRelatedProduct>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public int? SetAttributeId { get; set; }
        public string SetAttributeData { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Excerpt { get; set; }
        public string ExtraProperties { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public double Price { get; set; }
        public string PrivacyId { get; set; }
        public int Priority { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string Source { get; set; }
        public int Status { get; set; }
        public string Tags { get; set; }
        public string Template { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int? Views { get; set; }
        public string Code { get; set; }
        public double? DealPrice { get; set; }
        public double Discount { get; set; }
        public double ImportPrice { get; set; }
        public string Material { get; set; }
        public double NormalPrice { get; set; }
        public int PackageCount { get; set; }
        public int TotalSaled { get; set; }

        public SioSetAttribute SetAttribute { get; set; }
        public SioCulture SpecificultureNavigation { get; set; }
        public ICollection<SioComment> SioComment { get; set; }
        public ICollection<SioModuleProduct> SioModuleProduct { get; set; }
        public ICollection<SioOrderItem> SioOrderItem { get; set; }
        public ICollection<SioPageProduct> SioPageProduct { get; set; }
        public ICollection<SioProductMedia> SioProductMedia { get; set; }
        public ICollection<SioProductModule> SioProductModule { get; set; }
        public ICollection<SioRelatedProduct> SioRelatedProductSioProduct { get; set; }
        public ICollection<SioRelatedProduct> SioRelatedProductS { get; set; }
    }
}
