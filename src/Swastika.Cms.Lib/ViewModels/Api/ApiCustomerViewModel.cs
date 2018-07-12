// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiCustomerViewModel
        : ViewModelBase<SiocCmsContext, SiocCustomer, ApiCustomerViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("isAgreeNotified")]
        public string IsAgreeNotified { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [Required]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("birthday")]
        public DateTime? BirthDay { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion

        #region Views

        public List<ApiOrderViewModel> Orders { get; set; }

        #endregion

        #endregion

        #region Contructors

        public ApiCustomerViewModel() : base()
        {
        }

        public ApiCustomerViewModel(SiocCustomer model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void Validate(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            base.Validate(_context, _transaction);
            if (IsValid)
            {
                IsValid = ApiCustomerViewModel.Repository.CheckIsExists(c => c.PhoneNumber == PhoneNumber, _context, _transaction);
                if (!IsValid)
                {
                    Errors.Add("This phone number already existed");
                }
            }
        }
        public override SiocCustomer ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Orders = ApiOrderViewModel.Repository.GetModelListBy(o => o.CustomerId == Id && o.Specificulture == Specificulture).Data;
        }
        #endregion Overrides
    }
    
}