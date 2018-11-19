using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioModuleData
    {
        public string Id { get; set; }
        public int ModuleId { get; set; }
        public string Specificulture { get; set; }
        public int? ArticleId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Fields { get; set; }
        public int Priority { get; set; }
        public int? ProductId { get; set; }
        public int Status { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string Value { get; set; }

        public SioArticleModule SioArticleModule { get; set; }
        public SioModule SioModule { get; set; }
        public SioPageModule SioPageModule { get; set; }
    }
}
