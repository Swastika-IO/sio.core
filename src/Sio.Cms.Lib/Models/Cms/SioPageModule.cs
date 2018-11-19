using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPageModule
    {
        public SioPageModule()
        {
            SioModuleAttributeSet = new HashSet<SioModuleAttributeSet>();
            SioModuleData = new HashSet<SioModuleData>();
        }

        public int ModuleId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioModule SioModule { get; set; }
        public SioPage SioPage { get; set; }
        public ICollection<SioModuleAttributeSet> SioModuleAttributeSet { get; set; }
        public ICollection<SioModuleData> SioModuleData { get; set; }
    }
}
