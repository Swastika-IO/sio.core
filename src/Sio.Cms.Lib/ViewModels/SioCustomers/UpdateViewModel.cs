using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sio.Cms.Lib.ViewModels.SioCustomers
{
    public class UpdateViewModel
        : ViewModelBase<SioCmsContext, SioCustomer, UpdateViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("isAgreeNotified")]
        public string IsAgreeNotified { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [Required]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("birthday")]
        public DateTime? BirthDay { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion

        #region Views

        public List<SioOrders.ReadListItemViewModel> Orders { get; set; }

        #endregion

        #endregion

        #region Contructors

        public UpdateViewModel() : base()
        {
        }

        public UpdateViewModel(SioCustomer model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
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
                IsValid = !UpdateViewModel.Repository.CheckIsExists(c => c.PhoneNumber == PhoneNumber, _context, _transaction);
                if (!IsValid)
                {
                    Errors.Add("This phone number already existed");
                }
            }
        }
        public override SioCustomer ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            //Orders = InfoOrderViewModel.Repository.GetModelListBy(o => o.CustomerId == Id, _context, _transaction).Data;
        }
        #endregion Overrides
    }
}
