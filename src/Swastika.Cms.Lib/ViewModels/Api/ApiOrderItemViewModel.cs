// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiOrderItemViewModel
        : ViewModelBase<SiocCmsContext, SiocOrderItem, ApiOrderItemViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("productId")]
        public string ProductId { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("priceUnit")]
        public string PriceUnit { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonIgnore]
        [JsonProperty("storeId")]
        public int StoreId { get; set; }

        #endregion

        #region Views

        public InfoProductViewModel Product { get; set; }

        #endregion

        #endregion

        #region Contructors

        public ApiOrderItemViewModel() : base()
        {
        }

        public ApiOrderItemViewModel(SiocOrderItem model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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
                if (!ApiOrderViewModel.Repository.CheckIsExists(o => o.Id == OrderId, _context, _transaction))
                {
                    Errors.Add("Invalid Order");
                    IsValid = false;
                }
                if (!InfoProductViewModel.Repository.CheckIsExists(p => p.Id == ProductId && p.Specificulture == Specificulture, _context, _transaction))
                {
                    Errors.Add("Invalid Product");
                    IsValid = false;
                }
            }
        }

        public override SiocOrderItem ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var product = InfoProductViewModel.Repository.GetSingleModel(p => p.Id == ProductId && p.Specificulture == Specificulture).Data;
            Price = product?.Price ?? 0;
            Quantity = 1;
            PriceUnit = product?.PriceUnit;
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Product = InfoProductViewModel.Repository.GetSingleModel(p => p.Id == ProductId && p.Specificulture == Specificulture, _context, _transaction).Data;
        }
        #endregion Overrides
    }

}