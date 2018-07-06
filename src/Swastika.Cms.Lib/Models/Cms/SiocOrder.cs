using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocOrder
    {
        public SiocOrder()
        {
            SiocOrderItem = new HashSet<SiocOrderItem>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public int StoreId { get; set; }
        public int Status { get; set; }

        public SiocCmsCustomer Customer { get; set; }
        public SiocCmsUser User { get; set; }
        public ICollection<SiocOrderItem> SiocOrderItem { get; set; }
    }
}
