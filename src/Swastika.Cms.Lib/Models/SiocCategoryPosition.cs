using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocCategoryPosition
    {
        public int PositionId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }

        public SiocPosition Position { get; set; }
        public SiocCategory SiocCategory { get; set; }
    }
}
