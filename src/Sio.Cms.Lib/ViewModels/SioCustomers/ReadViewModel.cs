using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;

namespace Sio.Cms.Lib.ViewModels.SioCustomers
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioCustomer, ReadViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }
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
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("birthday")]
        public DateTime? BirthDay { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion

        #region Views

        #endregion

        #endregion

        public ReadViewModel(SioCustomer model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
        {
        }

    }
}
