using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmReceiptDeliveryViewModel
        : ViewModelBase<SwastikaCrmContext, CrmReceiptDelivery, FECrmReceiptDeliveryViewModel>
    {
        #region Properties

        [JsonProperty("receiptId")]
        public long ReceiptId { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("orderName")]
        public string OrderName { get; set; }
        [JsonProperty("orderAddress")]
        public string OrderAddress { get; set; }
        [JsonProperty("orderPhone")]
        public string OrderPhone { get; set; }
        [JsonProperty("receiveName")]
        public string ReceiveName { get; set; }
        [JsonProperty("receiveAddress")]
        public string ReceiveAddress { get; set; }
        [JsonProperty("receivePhone")]
        public string ReceivePhone { get; set; }
        [JsonProperty("shipping")]
        public double? Shipping { get; set; }
        [JsonProperty("totalReduceAmount")]
        public double TotalReduceAmount { get; set; }
        [JsonProperty("totalAmount")]
        public double TotalAmount { get; set; }
        [JsonProperty("totalPaid")]
        public double TotalPaid { get; set; }
        [JsonProperty("totalPaidBanking")]
        public double TotalPaidBanking { get; set; }
        [JsonProperty("totalRemain")]
        public double TotalRemain { get; set; }
        [JsonProperty("isOrdered")]
        public bool IsOrdered { get; set; }
        [JsonProperty("isPaid")]
        public bool IsPaid { get; set; }
        [JsonProperty("isDeliveried")]
        public bool IsDeliveried { get; set; }
        [JsonProperty("isReceived")]
        public bool IsReceived { get; set; }
        [JsonProperty("status")]
        public new string Status { get; set; }
        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }
        [JsonProperty("formPayment")]
        public string FormPayment { get; set; }
        [JsonProperty("employeeId")]
        public int? EmployeeId { get; set; }
        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }

        #region Models

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmReceiptDeliveryViewModel() : base()
        {
        }

        public FECrmReceiptDeliveryViewModel(CrmReceiptDelivery model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
