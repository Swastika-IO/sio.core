using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocCategoryModule
    {
        public SiocCategoryModule()
        {
            SiocModuleData = new HashSet<SiocModuleData>();
        }

        public int ModuleId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }

        public SiocCategory SiocCategory { get; set; }
        public SiocModule SiocModule { get; set; }
        public ICollection<SiocModuleData> SiocModuleData { get; set; }
    }
}
