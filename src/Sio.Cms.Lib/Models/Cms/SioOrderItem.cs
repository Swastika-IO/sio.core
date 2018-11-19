using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioOrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string PriceUnit { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public SioOrder SioOrder { get; set; }
        public SioProduct SioProduct { get; set; }
    }
}
