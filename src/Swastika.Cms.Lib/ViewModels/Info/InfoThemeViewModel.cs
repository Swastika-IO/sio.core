// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Common.Helper;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Threading.Tasks;

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

        [JsonProperty("previewUrl")]
        public string PreviewUrl { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("asset")]
        public IFormFile Asset { get; set; }

        [JsonProperty("assetFolder")]
        public string AssetFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.FileFolder,
                    SWCmsConstants.Parameters.TemplatesAssetFolder,
                    SeoHelper.GetSEOString(Name) });
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

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        #endregion Views

        #endregion Properties

        #region Contructors

        public InfoThemeViewModel()
            : base()
        {
        }

        public InfoThemeViewModel(SiocTheme model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Domain = GlobalConfigurationService.Instance.CmsConfigurations.GetLocalString("Domain", null, "/");
            if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
            {
                ImageUrl = SwCmsHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
            }
            else
            {
                ImageUrl = Image;
            }

        }
        public override Task<bool> ExpandViewAsync(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Domain = GlobalConfigurationService.Instance.CmsConfigurations.GetLocalString("Domain", Specificulture, "/");
            if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
            {
                ImageUrl = SwCmsHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
            }
            else
            {
                ImageUrl = Image;
            }

            return base.ExpandViewAsync(_context, _transaction);
        }
        #endregion
    }
}
