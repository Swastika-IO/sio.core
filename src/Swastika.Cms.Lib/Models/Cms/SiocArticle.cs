using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocArticle
    {
        public SiocArticle()
        {
            SiocArticleMedia = new HashSet<SiocArticleMedia>();
            SiocArticleModule = new HashSet<SiocArticleModule>();
            SiocCategoryArticle = new HashSet<SiocCategoryArticle>();
            SiocModuleArticle = new HashSet<SiocModuleArticle>();
        }

        public string Id { get; set; }
        public string Specificulture { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Excerpt { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
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
        public int Priority { get; set; }
        public string ExtraProperties { get; set; }
        public int Status { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
        public ICollection<SiocArticleMedia> SiocArticleMedia { get; set; }
        public ICollection<SiocArticleModule> SiocArticleModule { get; set; }
        public ICollection<SiocCategoryArticle> SiocCategoryArticle { get; set; }
        public ICollection<SiocModuleArticle> SiocModuleArticle { get; set; }
    }
}
