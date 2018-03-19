using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmCustomer
    {
        public CrmCustomer()
        {
            CrmAddress = new HashSet<CrmAddress>();
            CrmReceiptDelivery = new HashSet<CrmReceiptDelivery>();
            CrmReceiptReturn = new HashSet<CrmReceiptReturn>();
        }

        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Avatar { get; set; }

        public ICollection<CrmAddress> CrmAddress { get; set; }
        public ICollection<CrmReceiptDelivery> CrmReceiptDelivery { get; set; }
        public ICollection<CrmReceiptReturn> CrmReceiptReturn { get; set; }
    }
}
