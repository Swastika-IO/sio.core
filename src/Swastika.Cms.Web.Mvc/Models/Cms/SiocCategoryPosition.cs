using System;
using System.Collections.Generic;

namespace Swastika.Cms.Web.Mvc.Models.Cms
{
    public partial class SiocCategoryPosition
    {
        public int PositionId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocPosition Position { get; set; }
        public SiocCategory SiocCategory { get; set; }
    }
}
