using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocConfiguration
    {
        public string Keyword { get; set; }
        public string Specificulture { get; set; }
        public string Category { get; set; }
        public int DataType { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
    }
}
