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
    public class ApiOrderViewModel
        : ViewModelBase<SiocCmsContext, SiocOrder, ApiOrderViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        [JsonProperty("storeId")]
        public int StoreId { get; set; }

        #endregion

        #region View
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("items")]
        public List<ApiOrderItemViewModel> Items { get; set; }

        [JsonProperty("customer")]
        public ApiCustomerViewModel Customer { get; set; }

        [JsonProperty("status")]
        public new int Status { get; set; }

        [JsonProperty("comments")]
        public List<ApiCommentViewModel> Comments { get; private set; }

        #endregion

        #endregion

        #region Contructors

        public ApiOrderViewModel() : base()
        {
        }

        public ApiOrderViewModel(SiocOrder model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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
                var getCustomer = ApiCustomerViewModel.Repository.GetSingleModel(c => c.PhoneNumber == PhoneNumber || c.Id== CustomerId, _context, _transaction);
                IsValid = getCustomer.IsSucceed;
                if (!IsValid)
                {
                    Errors.Add("Invalid Customer");
                }
                else
                {
                    CustomerId = getCustomer.Data.Id;
                }
            }
        }

        public override SiocOrder ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCustomer = ApiCustomerViewModel.Repository.GetSingleModel(c => c.Id == CustomerId);
            Customer = getCustomer.Data;
            PhoneNumber = Customer.PhoneNumber;
            var getItems = ApiOrderItemViewModel.Repository.GetModelListBy(i => i.OrderId == Id && i.Specificulture == Specificulture, _context, _transaction);
            Items = getItems.Data;
            var getComments = ApiCommentViewModel.Repository.GetModelListBy(i => i.OrderId == Id && i.Specificulture == Specificulture, _context, _transaction);
            Comments = getComments.Data;
        }
        #endregion Overrides
    }

}