using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocModule
    {
        public SiocModule()
        {
            SiocArticleModule = new HashSet<SiocArticleModule>();
            SiocCategoryModule = new HashSet<SiocCategoryModule>();
            SiocModuleArticle = new HashSet<SiocModuleArticle>();
            SiocModuleData = new HashSet<SiocModuleData>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
        public ICollection<SiocArticleModule> SiocArticleModule { get; set; }
        public ICollection<SiocCategoryModule> SiocCategoryModule { get; set; }
        public ICollection<SiocModuleArticle> SiocModuleArticle { get; set; }
        public ICollection<SiocModuleData> SiocModuleData { get; set; }
    }
}
