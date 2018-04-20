using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmFund
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Payer { get; set; }
        public string Receiver { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
