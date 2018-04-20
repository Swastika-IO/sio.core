using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmReceiptImport
    {
        public CrmReceiptImport()
        {
            CrmReceiptDetails = new HashSet<CrmReceiptDetails>();
        }

        public long ReceiptId { get; set; }
        public DateTime CreatedDate { get; set; }
        public double? TotalReduceAmount { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalPaid { get; set; }
        public double? TotalRemain { get; set; }
        public bool IsPaid { get; set; }
        public bool IsReceived { get; set; }
        public string Status { get; set; }
        public bool? IsDeleted { get; set; }
        public string FormPayment { get; set; }
        public string UserId { get; set; }
        public int? ProviderId { get; set; }
        public int? EmployeeId { get; set; }

        public CrmEmployee Employee { get; set; }
        public CrmProvider Provider { get; set; }
        public ICollection<CrmReceiptDetails> CrmReceiptDetails { get; set; }
    }
}
