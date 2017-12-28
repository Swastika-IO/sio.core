using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocModuleAttributeSet
    {
        public SiocModuleAttributeSet()
        {
            SiocModuleAttributeValue = new HashSet<SiocModuleAttributeValue>();
        }

        public Guid Id { get; set; }
        public int ModuleId { get; set; }
        public string Specificulture { get; set; }
        public string Fields { get; set; }
        public string Value { get; set; }
        public string ArticleId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int Priority { get; set; }

        public SiocArticleModule SiocArticleModule { get; set; }
        public SiocCategoryModule SiocCategoryModule { get; set; }
        public SiocModule SiocModule { get; set; }
        public ICollection<SiocModuleAttributeValue> SiocModuleAttributeValue { get; set; }
    }
}
