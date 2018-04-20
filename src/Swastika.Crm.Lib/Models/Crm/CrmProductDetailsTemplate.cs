using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmProductDetailsTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public int? CateId { get; set; }
    }
}
