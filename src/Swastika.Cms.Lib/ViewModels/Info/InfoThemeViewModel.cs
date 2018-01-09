using System;
using System.Collections.Generic;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Services;
using Swastika.IO.Domain.Core.ViewModels;
using System.Threading.Tasks;
using Swastika.IO.Common.Helper;
using Swastika.Cms.Lib.Repositories;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoThemeViewModel
       : ViewModelBase<SiocCmsContext, SiocTheme, InfoThemeViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        #endregion

        #region Views
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("asset")]
        public IFormFile Asset { get; set; }// = new FileViewModel();
        [JsonProperty("assetFolder")]
        public string AssetFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesAssetFolder, Name });
            }
        }
        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesFolder, Name });
            }
        }
        #endregion

        #endregion

        #region Contructors

        public InfoThemeViewModel()
            : base()
        {
        }

        public InfoThemeViewModel(SiocTheme model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion
    }
}
