using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Common.Helper;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Sio.Cms.Lib.ViewModels.SioThemes
{
    public class ReadViewModel
      : ViewModelBase<SioCmsContext, SioTheme, ReadViewModel>
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
                    SioConstants.Folder.FileFolder,
                    SioConstants.Folder.TemplatesAssetFolder,
                    SeoHelper.GetSEOString(Name) });
            }
        }

        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] { SioConstants.Folder.TemplatesFolder, Name });
            }
        }

        [JsonProperty("domain")]
        public string Domain { get { return SioService.GetConfig<string>("Domain") ?? "/"; } }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        #endregion Views

        #endregion Properties

        #region Contructors

        public ReadViewModel()
            : base()
        {
        }

        public ReadViewModel(SioTheme model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
            {
                ImageUrl = CommonHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
            }
            else
            {
                ImageUrl = Image;
            }

        }
        public override Task<bool> ExpandViewAsync(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
            {
                ImageUrl = CommonHelper.GetFullPath(new string[] {
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
