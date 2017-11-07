using System;
using System.Collections.Generic;

namespace Swastika.IO.Cms.Lib.Models
{
    public partial class SiocCategory
    {
        public SiocCategory()
        {
            SiocCategoryArticle = new HashSet<SiocCategoryArticle>();
            SiocCategoryCategorySiocCategory = new HashSet<SiocCategoryCategory>();
            SiocCategoryCategorySiocCategoryNavigation = new HashSet<SiocCategoryCategory>();
            SiocCategoryModule = new HashSet<SiocCategoryModule>();
            SiocCategoryPosition = new HashSet<SiocCategoryPosition>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Template { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string StaticUrl { get; set; }
        public string Excerpt { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public int? Views { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public int? Level { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public int Priority { get; set; }
        public string Tags { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
        public ICollection<SiocCategoryArticle> SiocCategoryArticle { get; set; }
        public ICollection<SiocCategoryCategory> SiocCategoryCategorySiocCategory { get; set; }
        public ICollection<SiocCategoryCategory> SiocCategoryCategorySiocCategoryNavigation { get; set; }
        public ICollection<SiocCategoryModule> SiocCategoryModule { get; set; }
        public ICollection<SiocCategoryPosition> SiocCategoryPosition { get; set; }
    }
}
