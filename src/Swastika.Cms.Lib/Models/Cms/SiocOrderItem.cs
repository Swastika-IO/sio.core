using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocOrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string PriceUnit { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public SiocOrder SiocOrder { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
