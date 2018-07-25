// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiThemeViewModel
       : ViewModelBase<SiocCmsContext, SiocTheme, ApiThemeViewModel>
    {
        public const int templatePageSize = 10;

        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("previewUrl")]
        public string PreviewUrl { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

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

        [JsonProperty("templates")]
        public List<ApiTemplateViewModel> Templates { get; set; }
        [JsonProperty("asset")]
        public FileViewModel Asset { get; set; }

        [JsonProperty("imageFileStream")]
        public FileStreamViewModel ImageFileStream { get; set; }

        [JsonProperty("domain")]
        public string Domain => GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/");

        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
                {
                    return SwCmsHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
                }
                else
                {
                    return Image;
                }
            }
        }
        #endregion Views

        #endregion Properties

        #region Contructors

        public ApiThemeViewModel()
            : base()
        {
        }

        public ApiThemeViewModel(SiocTheme model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override SiocTheme ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            Asset.FolderName = Name;
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Templates = ApiTemplateViewModel.Repository.GetModelListBy(t => t.TemplateId == Id,
                _context: _context, _transaction: _transaction).Data;
            Asset = new FileViewModel() { FileFolder = AssetFolder };
        }



        #region Async

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocTheme parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };

            if (Asset.Content != null || Asset.FileStream != null)
            {
                Asset.FileFolder = AssetFolder;
                Asset.Filename = "assets";
                string fullPath = CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.WebRootPath,
                    Asset.FileFolder
                });
                FileRepository.Instance.EmptyFolder(fullPath);
                var isSaved = FileRepository.Instance.SaveWebFile(Asset);
                result.IsSucceed = isSaved;
                if (isSaved)
                {
                    result.IsSucceed = FileRepository.Instance.UnZipFile(Asset);
                    if (!result.IsSucceed)
                    {
                        result.Errors.Add("Cannot unzip file");
                    }

                }
                else
                {
                    result.Errors.Add("Cannot saved asset file");
                }

            }
            if (Id == 0)
            {
                string defaultFolder = CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesFolder, Name == "Default" ? "Default" : SWCmsConstants.Default.DefaultTemplateFolder });
                bool copyResult = FileRepository.Instance.CopyDirectory(defaultFolder, TemplateFolder);
                var files = copyResult ? FileRepository.Instance.GetFilesWithContent(TemplateFolder) : new System.Collections.Generic.List<FileViewModel>();
                //TODO: Create default asset
                foreach (var file in files)
                {
                    ApiTemplateViewModel template = new ApiTemplateViewModel(
                        new SiocTemplate()
                        {
                            FileFolder = file.FileFolder,
                            FileName = file.Filename,
                            Content = file.Content,
                            Extension = file.Extension,
                            CreatedDateTime = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            TemplateId = Model.Id,
                            TemplateName = Model.Name,
                            FolderType = file.FolderName,
                            ModifiedBy = CreatedBy
                        });
                    var saveResult = await template.SaveModelAsync(true, _context, _transaction);
                    result.IsSucceed = result.IsSucceed && saveResult.IsSucceed;
                    if (!saveResult.IsSucceed)
                    {
                        result.Exception = saveResult.Exception;
                        result.Errors.AddRange(saveResult.Errors);
                        break;
                    }
                }
            }

            // Actived Theme
            if (IsActived)
            {
                InfoConfigurationViewModel config = (await InfoConfigurationViewModel.Repository.GetSingleModelAsync(
                    c => c.Keyword == SWCmsConstants.ConfigurationKeyword.Theme && c.Specificulture == Specificulture
                    , _context, _transaction)).Data;
                if (config == null)
                {
                    config = new InfoConfigurationViewModel()
                    {
                        Keyword = SWCmsConstants.ConfigurationKeyword.Theme,
                        Specificulture = Specificulture,
                        Category = SWCmsConstants.ConfigurationType.User,
                        DataType = SWCmsConstants.DataType.String,
                        Description = "Cms Theme",
                        Value = Name
                    };
                }
                else
                {
                    config.Value = Name;
                }

                var saveConfigResult = await config.SaveModelAsync(false, _context, _transaction);
                if (!saveConfigResult.IsSucceed)
                {
                    Errors.AddRange(saveConfigResult.Errors);
                }
                else
                {
                    GlobalConfigurationService.Instance.RefreshConfigurations(_context, _transaction);
                }
                result.IsSucceed = result.IsSucceed && saveConfigResult.IsSucceed;

                InfoConfigurationViewModel configId = (await InfoConfigurationViewModel.Repository.GetSingleModelAsync(
                      c => c.Keyword == SWCmsConstants.ConfigurationKeyword.ThemeId && c.Specificulture == Specificulture, _context, _transaction)).Data;
                if (configId == null)
                {
                    configId = new InfoConfigurationViewModel()
                    {
                        Keyword = SWCmsConstants.ConfigurationKeyword.ThemeId,
                        Specificulture = Specificulture,
                        Category = SWCmsConstants.ConfigurationType.User,
                        DataType = SWCmsConstants.DataType.String,
                        Description = "Cms Theme Id",
                        Value = Model.Id.ToString()
                    };
                }
                else
                {
                    configId.Value = Model.Id.ToString();
                }
                var saveResult = await configId.SaveModelAsync(false, _context, _transaction);
                if (!saveResult.IsSucceed)
                {
                    Errors.AddRange(saveResult.Errors);
                }
                else
                {
                    GlobalConfigurationService.Instance.RefreshConfigurations(_context, _transaction);
                }
                result.IsSucceed = result.IsSucceed && saveResult.IsSucceed;
            }

            if (Asset.Content != null || Asset.FileStream != null)
            {
                var files = FileRepository.Instance.GetWebFiles(AssetFolder);
                StringBuilder strStyles = new StringBuilder();

                foreach (var css in files.Where(f => f.Extension == ".css"))
                {
                    strStyles.Append($"   <link href='{css.FileFolder}/{css.Filename}{css.Extension}' rel='stylesheet'/>");
                }
                StringBuilder strScripts = new StringBuilder();
                foreach (var js in files.Where(f => f.Extension == ".js"))
                {
                    strScripts.Append($"  <script src='{js.FileFolder}/{js.Filename}{js.Extension}'></script>");
                }
                var layout = ApiTemplateViewModel.Repository.GetSingleModel(
                    t => t.FileName == "_Layout" && t.FolderType == "Masters" && t.TemplateId == Model.Id
                    , _context, _transaction);
                layout.Data.Content = layout.Data.Content.Replace("<!--[STYLES]-->"
                    , string.Format(@"{0}"
                    , strStyles));
                layout.Data.Content = layout.Data.Content.Replace("<!--[SCRIPTS]-->"
                    , string.Format(@"{0}"
                    , strScripts));

                await layout.Data.SaveModelAsync(true, _context, _transaction);
            }

            return result;
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(ApiThemeViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await InfoTemplateViewModel.Repository.RemoveListModelAsync(t => t.TemplateId == Id);
            if (result.IsSucceed)
            {
                FileRepository.Instance.DeleteWebFolder(AssetFolder);
                FileRepository.Instance.DeleteFolder(TemplateFolder);
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result.IsSucceed,
                Errors = result.Errors,
                Exception = result.Exception
            };
        }

        #endregion Async
        #endregion Overrides
    }
}
