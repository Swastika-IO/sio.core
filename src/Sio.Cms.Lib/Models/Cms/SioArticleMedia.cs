using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioArticleMedia
    {
        public int MediaId { get; set; }
        public int ArticleId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioArticle SioArticle { get; set; }
        public SioMedia SioMedia { get; set; }
    }
}
