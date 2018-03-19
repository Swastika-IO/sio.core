using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmAddressViewModel
        : ViewModelBase<SwastikaCrmContext, CrmAddress, FECrmAddressViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("addressId")]
        public int AddressId { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("zip")]
        public string Zip { get; set; }
        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty("providerId")]
        public int? ProviderId { get; set; }
        [JsonProperty("employeeId")]
        public int? EmployeeId { get; set; }
        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmAddressViewModel() : base()
        {
        }

        public FECrmAddressViewModel(CrmAddress model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
