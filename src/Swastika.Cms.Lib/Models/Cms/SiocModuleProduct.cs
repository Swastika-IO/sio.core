using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocModuleProduct
    {
        public string ProductId { get; set; }
        public int ModuleId { get; set; }
        public string Specificulture { get; set; }

        public SiocProduct SiocProduct { get; set; }
        public SiocModule SiocModule { get; set; }
    }
}
