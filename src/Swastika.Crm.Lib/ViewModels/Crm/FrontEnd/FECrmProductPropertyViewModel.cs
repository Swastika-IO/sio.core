using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmProductPropertyViewModel
        : ViewModelBase<SwastikaCrmContext, CrmProductProperty, FECrmProductPropertyViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("propertyId")]
        public long PropertyId { get; set; }
        [JsonProperty("productId")]
        public long ProductId { get; set; }
        [JsonProperty("roles")]
        public string propertyId { get; set; }
        [JsonProperty("sey")]
        public string Key { get; set; }
        [JsonProperty("stringValue")]
        public string StringValue { get; set; }
        [JsonProperty("doubleValue")]
        public double? DoubleValue { get; set; }
        [JsonProperty("intValue")]
        public int? IntValue { get; set; }

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmProductPropertyViewModel() : base()
        {
        }

        public FECrmProductPropertyViewModel(CrmProductProperty model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
