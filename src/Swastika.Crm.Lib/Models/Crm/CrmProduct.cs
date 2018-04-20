using System;
using System.Collections.Generic;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class CrmProduct
    {
        public CrmProduct()
        {
            CrmProductProperty = new HashSet<CrmProductProperty>();
            CrmReceiptDetails = new HashSet<CrmReceiptDetails>();
        }

        public long ProductId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Material { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string FullDetails { get; set; }
        public double? DealPrice { get; set; }
        public double NormalPrice { get; set; }
        public double Discount { get; set; }
        public string Size { get; set; }
        public int TotalRemain { get; set; }
        public int TotalSaled { get; set; }
        public int TotalImported { get; set; }
        public int PackageCount { get; set; }
        public string SubImages { get; set; }
        public string Language { get; set; }
        public string Infos { get; set; }
        public int? Views { get; set; }
        public int? CateId { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsDraft { get; set; }
        public double ImportPrice { get; set; }

        public ICollection<CrmProductProperty> CrmProductProperty { get; set; }
        public ICollection<CrmReceiptDetails> CrmReceiptDetails { get; set; }
    }
}
