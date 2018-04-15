using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmReceiptDetailsViewModel
        : ViewModelBase<SwastikaCrmContext, CrmReceiptDetails, FECrmReceiptDetailsViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("receiptDetailsId")]
        public long ReceiptDetailsId { get; set; }
        [JsonProperty("receiptDeliveryId")]
        public long? ReceiptDeliveryId { get; set; }
        [JsonProperty("receiptReturnId")]
        public long? ReceiptReturnId { get; set; }
        [JsonProperty("receiptImportId")]
        public long? ReceiptImportId { get; set; }
        [JsonProperty("productId")]
        public long ProductId { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("quantityPackage")]
        public int QuantityPackage { get; set; }
        [JsonProperty("unitPrice")]
        public double UnitPrice { get; set; }
        [JsonProperty("reducePrice")]
        public double ReducePrice { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("isDeliveried")]
        public bool IsDeliveried { get; set; }
        [JsonProperty("finalPrice")]
        public double FinalPrice { get; set; }

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmReceiptDetailsViewModel() : base()
        {
        }

        public FECrmReceiptDetailsViewModel(CrmReceiptDetails model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
