using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPage
    {
        public SioPage()
        {
            SioPageArticle = new HashSet<SioPageArticle>();
            SioPageModule = new HashSet<SioPageModule>();
            SioPagePageSioPage = new HashSet<SioPagePage>();
            SioPagePageSioPageNavigation = new HashSet<SioPagePage>();
            SioPagePosition = new HashSet<SioPagePosition>();
            SioPageProduct = new HashSet<SioPageProduct>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public int? SetAttributeId { get; set; }
        public string SetAttributeData { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CssClass { get; set; }
        public string Excerpt { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public DateTime? LastModified { get; set; }
        public string Layout { get; set; }
        public int? Level { get; set; }
        public string ModifiedBy { get; set; }
        public int Priority { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string StaticUrl { get; set; }
        public int Status { get; set; }
        public string Tags { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int? Views { get; set; }
        public int? PageSize { get; set; }

        public SioSetAttribute SetAttribute { get; set; }
        public SioCulture SpecificultureNavigation { get; set; }
        public ICollection<SioPageArticle> SioPageArticle { get; set; }
        public ICollection<SioPageModule> SioPageModule { get; set; }
        public ICollection<SioPagePage> SioPagePageSioPage { get; set; }
        public ICollection<SioPagePage> SioPagePageSioPageNavigation { get; set; }
        public ICollection<SioPagePosition> SioPagePosition { get; set; }
        public ICollection<SioPageProduct> SioPageProduct { get; set; }
    }
}
