using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmEmployee
    {
        public CrmEmployee()
        {
            CrmAddress = new HashSet<CrmAddress>();
            CrmReceiptDelivery = new HashSet<CrmReceiptDelivery>();
            CrmReceiptImport = new HashSet<CrmReceiptImport>();
            CrmReceiptReturn = new HashSet<CrmReceiptReturn>();
        }

        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string IdcardNumber { get; set; }
        public string ProfileFilePath { get; set; }
        public string PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string Position { get; set; }
        public string JobDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Avatar { get; set; }

        public ICollection<CrmAddress> CrmAddress { get; set; }
        public ICollection<CrmReceiptDelivery> CrmReceiptDelivery { get; set; }
        public ICollection<CrmReceiptImport> CrmReceiptImport { get; set; }
        public ICollection<CrmReceiptReturn> CrmReceiptReturn { get; set; }
    }
}
