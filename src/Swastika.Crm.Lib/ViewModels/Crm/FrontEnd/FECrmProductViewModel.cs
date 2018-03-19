using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmProductViewModel
        : ViewModelBase<SwastikaCrmContext, CrmProduct, FECrmProductViewModel>
    {
        #region Properties

        [JsonProperty("productId")]
        public long ProductId { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("material")]
        public string Material { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("fullDetails")]
        public string FullDetails { get; set; }
        [JsonProperty("dealPrice")]
        public double? DealPrice { get; set; }
        [JsonProperty("normalPrice")]
        public double NormalPrice { get; set; }
        [JsonProperty("discount")]
        public double Discount { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("totalRemain")]
        public int TotalRemain { get; set; }
        [JsonProperty("totalSaled")]
        public int TotalSaled { get; set; }
        [JsonProperty("totalImported")]
        public int TotalImported { get; set; }
        [JsonProperty("packageCount")]
        public int PackageCount { get; set; }
        [JsonProperty("subImages")]
        public string SubImages { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("infos")]
        public string Infos { get; set; }
        [JsonProperty("views")]
        public int? Views { get; set; }
        [JsonProperty("cateId")]
        public int? CateId { get; set; }
        [JsonProperty("displayOrder")]
        public int? DisplayOrder { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("isVisible")]
        public bool? IsVisible { get; set; }
        [JsonProperty("isDraft")]
        public bool IsDraft { get; set; }
        [JsonProperty("importPrice")]
        public double ImportPrice { get; set; }

        #region Models

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmProductViewModel() : base()
        {
        }

        public FECrmProductViewModel(CrmProduct model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
