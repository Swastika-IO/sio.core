using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocProductModule
    {
        public int ModuleId { get; set; }
        public string ProductId { get; set; }
        public string Specificulture { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }

        public SiocModule SiocModule { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
