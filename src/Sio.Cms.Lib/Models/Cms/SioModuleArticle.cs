using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioModuleArticle
    {
        public int ArticleId { get; set; }
        public int ModuleId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioArticle SioArticle { get; set; }
        public SioModule SioModule { get; set; }
    }
}
