using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocCategoryCategory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Specificulture { get; set; }

        public SiocCategory SiocCategory { get; set; }
        public SiocCategory SiocCategoryNavigation { get; set; }
    }
}
