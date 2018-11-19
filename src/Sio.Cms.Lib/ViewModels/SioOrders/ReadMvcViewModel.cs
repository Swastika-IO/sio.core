using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sio.Cms.Lib.ViewModels.SioOrders
{
    public class ApiOrderViewModel
        : ViewModelBase<SioCmsContext, SioOrder, ApiOrderViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

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
        public List<SioOrderItems.UpdateViewModel> Items { get; set; }

        [JsonProperty("customer")]
        public SioCustomers.ReadViewModel Customer { get; set; }

        [JsonProperty("status")]
        public SioEnums.SioOrderStatus Status { get; set; }

        [JsonProperty("comments")]
        public List<SioComments.ReadViewModel> Comments { get; private set; }

        [JsonProperty("totalSpent")]
        public double TotalSpent { get; set; }
        #endregion

        #endregion

        #region Contructors

        public ApiOrderViewModel() : base()
        {
        }

        public ApiOrderViewModel(SioOrder model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override void Validate(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            base.Validate(_context, _transaction);
            if (IsValid)
            {
                var getCustomer = SioCustomers.ReadViewModel.Repository.GetSingleModel(c => c.PhoneNumber == PhoneNumber || c.Id == CustomerId, _context, _transaction);
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

        public override SioOrder ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }
        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCustomer = SioCustomers.ReadViewModel.Repository.GetSingleModel(c => c.Id == CustomerId);
            Customer = getCustomer.Data;
            PhoneNumber = Customer.PhoneNumber;
            var getItems = SioOrderItems.UpdateViewModel.Repository.GetModelListBy(i => i.OrderId == Id && i.Specificulture == Specificulture, _context, _transaction);
            Items = getItems.Data;
            var getComments = SioComments.ReadViewModel.Repository.GetModelListBy(i => i.OrderId == Id && i.Specificulture == Specificulture, _context, _transaction);
            Comments = getComments.Data;
            TotalSpent = _context.SioOrderItem.Where(i => i.OrderId == Id && i.Specificulture == Specificulture).Sum(i => i.Price);
        }
        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(ApiOrderViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            foreach (var item in Items)
            {
                var removeItem = await item.RemoveModelAsync(false, _context, _transaction);
                result.IsSucceed = removeItem.IsSucceed;
                result.Errors.AddRange(removeItem.Errors);
                result.Exception = removeItem.Exception;
            }

            foreach (var item in Comments)
            {
                var removeItem = await item.RemoveModelAsync(false, _context, _transaction);
                result.IsSucceed = removeItem.IsSucceed;
                result.Errors.AddRange(removeItem.Errors);
                result.Exception = removeItem.Exception;
            }
            return result;
        }
        #endregion Overrides
    }
}
