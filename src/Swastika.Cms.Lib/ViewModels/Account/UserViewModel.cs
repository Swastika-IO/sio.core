using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Models.Account;
using System.Collections.Generic;
using Swastika.Cms.Lib.ViewModels.Account;
using Swastika.Identity.Models.AccountViewModels;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class UserViewModel
        : ViewModelBase<SiocCmsAccountContext, AspNetUsers, UserViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("emailConfirmed")]
        public bool EmailConfirmed { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string SecurityStamp { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }
        [JsonIgnore]
        public bool TwoFactorEnabled { get; set; }
        [JsonIgnore]
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        [JsonIgnore]
        public bool LockoutEnabled { get; set; }
        [JsonIgnore]
        public int AccessFailedCount { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("fullname")]
        public string Fullname { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        #endregion

        #region Views
        [JsonProperty("roles")]
        public List<UserRoleModel> Roles { get; set; }

        #endregion
        #endregion

        #region Contructors

        public UserViewModel() : base()
        {
        }

        public UserViewModel(AspNetUsers model, SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
