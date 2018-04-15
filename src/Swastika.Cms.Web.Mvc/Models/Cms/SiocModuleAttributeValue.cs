using System;
using System.Collections.Generic;

namespace Swastika.Cms.Web.Mvc.Models.Cms
{
    public partial class SiocModuleAttributeValue
    {
        public Guid Id { get; set; }
        public Guid AttributeSetId { get; set; }
        public string Specificulture { get; set; }
        public int DataType { get; set; }
        public string DefaultValue { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocModuleAttributeSet SiocModuleAttributeSet { get; set; }
    }
}
