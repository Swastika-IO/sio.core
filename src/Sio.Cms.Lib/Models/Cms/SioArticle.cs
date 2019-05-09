using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioArticle
    {
        public SioArticle()
        {
            SioArticleMedia = new HashSet<SioArticleMedia>();
            SioArticleModule = new HashSet<SioArticleModule>();
            SioComment = new HashSet<SioComment>();
            SioModuleArticle = new HashSet<SioModuleArticle>();
            SioPageArticle = new HashSet<SioPageArticle>();
            SioRelatedArticleSioArticle = new HashSet<SioRelatedArticle>();
            SioRelatedArticleS = new HashSet<SioRelatedArticle>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public int? SetAttributeId { get; set; }
        public string ExtraFields { get; set; }
        public string SetAttributeData { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Excerpt { get; set; }
        public string ExtraProperties { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
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

        public SioSetAttribute SetAttribute { get; set; }
        public SioCulture SpecificultureNavigation { get; set; }
        public ICollection<SioArticleMedia> SioArticleMedia { get; set; }
        public ICollection<SioArticleModule> SioArticleModule { get; set; }
        public ICollection<SioComment> SioComment { get; set; }
        public ICollection<SioModuleArticle> SioModuleArticle { get; set; }
        public ICollection<SioPageArticle> SioPageArticle { get; set; }
        public ICollection<SioRelatedArticle> SioRelatedArticleSioArticle { get; set; }
        public ICollection<SioRelatedArticle> SioRelatedArticleS { get; set; }
    }
}
