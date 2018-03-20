using System;
using System.Collections.Generic;

namespace Swastika.Cms.Web.Mvc.Models.Cms
{
    public partial class SiocCategoryArticle
    {
        public string ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public int? Priority { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public SiocArticle SiocArticle { get; set; }
        public SiocCategory SiocCategory { get; set; }
    }
}
