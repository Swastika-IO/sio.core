using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocOrder
    {
        public SiocOrder()
        {
            SiocComment = new HashSet<SiocComment>();
            SiocOrderItem = new HashSet<SiocOrderItem>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public int StoreId { get; set; }
        public string Specificulture { get; set; }
        public int Status { get; set; }

        public SiocCustomer SiocCustomer { get; set; }
        public ICollection<SiocComment> SiocComment { get; set; }
        public ICollection<SiocOrderItem> SiocOrderItem { get; set; }
    }
}
