using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Models.Account;

namespace Swastika.Cms.Lib.ViewModels.Account
{
    public class RefreshTokenViewModel
        : ViewModelBase<SiocCmsAccountContext, RefreshTokens, RefreshTokenViewModel>
    {
        #region Properties


        #region Models
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("expiresUtc")]
        public DateTime ExpiresUtc { get; set; }
        [JsonProperty("issuedUtc")]
        public DateTime IssuedUtc { get; set; }
        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public RefreshTokenViewModel() : base()
        {
        }

        public RefreshTokenViewModel(RefreshTokens model, SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
