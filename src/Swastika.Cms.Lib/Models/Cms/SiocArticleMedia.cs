using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocArticleMedia
    {
        public int MediaId { get; set; }
        public string ArticleId { get; set; }
        public string Specificulture { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }

        public SiocArticle SiocArticle { get; set; }
        public SiocMedia SiocMedia { get; set; }
    }
}
