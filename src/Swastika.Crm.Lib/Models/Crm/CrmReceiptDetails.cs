using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmReceiptDetails
    {
        public long ReceiptDetailsId { get; set; }
        public long? ReceiptDeliveryId { get; set; }
        public long? ReceiptReturnId { get; set; }
        public long? ReceiptImportId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public int QuantityPackage { get; set; }
        public double UnitPrice { get; set; }
        public double ReducePrice { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeliveried { get; set; }
        public double FinalPrice { get; set; }

        public CrmProduct Product { get; set; }
        public CrmReceiptDelivery ReceiptDelivery { get; set; }
        public CrmReceiptImport ReceiptImport { get; set; }
        public CrmReceiptReturn ReceiptReturn { get; set; }
    }
}
