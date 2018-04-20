using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmFundViewModel
        : ViewModelBase<SwastikaCrmContext, CrmFund, FECrmFundViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("payer")]
        public string Payer { get; set; }
        [JsonProperty("receiver")]
        public string Receiver { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmFundViewModel() : base()
        {
        }

        public FECrmFundViewModel(CrmFund model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
