using System;
using System.Collections.Generic;

namespace Swastika.Cms.Web.Mvc.Models.Cms
{
    public partial class SiocCopy
    {
        public string Culture { get; set; }
        public string Keyword { get; set; }
        public string Note { get; set; }
        public string Value { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
    }
}
