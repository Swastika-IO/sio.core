using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocArticleModule
    {
        public SiocArticleModule()
        {
            SiocModuleData = new HashSet<SiocModuleData>();
        }

        public int Id { get; set; }
        public string ArticleId { get; set; }
        public string Specificulture { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }

        public SiocArticle SiocArticle { get; set; }
        public SiocModule SiocModule { get; set; }
        public ICollection<SiocModuleData> SiocModuleData { get; set; }
    }
}
