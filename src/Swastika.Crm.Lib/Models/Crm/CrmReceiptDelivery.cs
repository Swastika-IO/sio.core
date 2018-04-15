using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmReceiptDelivery
    {
        public CrmReceiptDelivery()
        {
            CrmReceiptDetails = new HashSet<CrmReceiptDetails>();
        }

        public long ReceiptId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public string ReceiveName { get; set; }
        public string ReceiveAddress { get; set; }
        public string ReceivePhone { get; set; }
        public double? Shipping { get; set; }
        public double TotalReduceAmount { get; set; }
        public double TotalAmount { get; set; }
        public double TotalPaid { get; set; }
        public double TotalPaidBanking { get; set; }
        public double TotalRemain { get; set; }
        public bool IsOrdered { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDeliveried { get; set; }
        public bool IsReceived { get; set; }
        public string Status { get; set; }
        public bool? IsDeleted { get; set; }
        public string FormPayment { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }

        public CrmCustomer Customer { get; set; }
        public CrmEmployee Employee { get; set; }
        public ICollection<CrmReceiptDetails> CrmReceiptDetails { get; set; }
    }
}
