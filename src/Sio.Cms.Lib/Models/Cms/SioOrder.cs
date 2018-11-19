using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioOrder
    {
        public SioOrder()
        {
            SioComment = new HashSet<SioComment>();
            SioOrderItem = new HashSet<SioOrderItem>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public int StoreId { get; set; }
        public string Specificulture { get; set; }
        public int Status { get; set; }

        public SioCustomer Customer { get; set; }
        public ICollection<SioComment> SioComment { get; set; }
        public ICollection<SioOrderItem> SioOrderItem { get; set; }
    }
}
