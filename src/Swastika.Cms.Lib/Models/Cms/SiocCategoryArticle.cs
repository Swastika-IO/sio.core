using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocCategoryArticle
    {
        public string ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }

        public SiocArticle SiocArticle { get; set; }
        public SiocCategory SiocCategory { get; set; }
    }
}
