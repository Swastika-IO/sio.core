using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmProductProperty
    {
        public long PropertyId { get; set; }
        public long ProductId { get; set; }
        public string Roles { get; set; }
        public string Key { get; set; }
        public string StringValue { get; set; }
        public double? DoubleValue { get; set; }
        public int? IntValue { get; set; }

        public CrmProduct Product { get; set; }
    }
}
