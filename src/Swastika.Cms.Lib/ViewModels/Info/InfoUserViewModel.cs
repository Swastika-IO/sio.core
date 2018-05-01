using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoUserViewModel
        : ViewModelBase<SiocCmsContext, SiocCmsUser, InfoUserViewModel>
    {
        #region Properties
        //[JsonProperty("id")]

        #region Models

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        #endregion

        #region Views

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; } = new List<string>();
        #endregion

        #endregion

        #region Contructors

        public InfoUserViewModel() : base()
        {
        }

        public InfoUserViewModel(SiocCmsUser model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) 
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
