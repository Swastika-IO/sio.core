using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmAddress
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public int? CustomerId { get; set; }
        public int? ProviderId { get; set; }
        public int? EmployeeId { get; set; }

        public CrmCustomer Customer { get; set; }
        public CrmEmployee Employee { get; set; }
        public CrmProvider Provider { get; set; }
    }
}
