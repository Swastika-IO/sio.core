using System;
using System.Collections.Generic;

namespace Swastika.Cms.Web.Mvc.Models.Cms
{
    public partial class SiocPosition
    {
        public SiocPosition()
        {
            SiocCategoryPosition = new HashSet<SiocCategoryPosition>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public ICollection<SiocCategoryPosition> SiocCategoryPosition { get; set; }
    }
}
