using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmProvider
    {
        public CrmProvider()
        {
            CrmAddress = new HashSet<CrmAddress>();
            CrmReceiptImport = new HashSet<CrmReceiptImport>();
        }

        public int ProviderId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Avatar { get; set; }

        public ICollection<CrmAddress> CrmAddress { get; set; }
        public ICollection<CrmReceiptImport> CrmReceiptImport { get; set; }
    }
}
