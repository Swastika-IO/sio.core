using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Account;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;

namespace Sio.Cms.Lib.ViewModels.Account
{

    public class RefreshTokenViewModel
        : ViewModelBase<SioCmsAccountContext, RefreshTokens, RefreshTokenViewModel>
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

        #endregion Models

        #endregion Properties

        #region Contructors

        public RefreshTokenViewModel() : base()
        {
        }

        public RefreshTokenViewModel(RefreshTokens model, SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors
    }
}
