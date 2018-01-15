using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocModule, InfoModuleViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("template")]
        public string Template { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("fields")]
        public string Fields { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }
        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public InfoModuleViewModel() : base()
        {
        }

        public InfoModuleViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

    }
}
