using System;
using System.Collections.Generic;

namespace Swastika.Cms.Web.Mvc.Models.Cms
{
    public partial class SiocParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
    }
}
