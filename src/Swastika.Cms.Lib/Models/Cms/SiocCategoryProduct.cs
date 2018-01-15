using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocCategoryProduct
    {
        public string ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }

        public SiocCategory SiocCategory { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
