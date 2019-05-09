using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Repositories;
using Sio.Cms.Lib.Services;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioThemes
{
    public class InitViewModel
      : ViewModelBase<SioCmsContext, SioTheme, InitViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("status")]
        public SioContentStatus Status { get; set; }
        #endregion Models

        #region Views
        [JsonProperty("domain")]
        public string Domain { get { return SioService.GetConfig<string>("Domain"); } }

        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Image) && (Image.IndexOf("http") == -1) && Image[0] != '/')
                {
                    return CommonHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
                }
                else
                {
                    return Image;
                }
            }
        }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("templateAsset")]
        public FileViewModel TemplateAsset { get; set; }

        [JsonProperty("asset")]
        public FileViewModel Asset { get; set; }

        [JsonProperty("assetFolder")]
        public string AssetFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    SioConstants.Folder.WebRootPath,
                    SioConstants.Folder.FileFolder,
                    SioConstants.Folder.TemplatesAssetFolder,
                    Name
                });
            }
        }
        public string UploadsFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    SioConstants.Folder.FileFolder,
                    SioConstants.Folder.UploadFolder,
                    Name
                });
            }
        }

        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    SioConstants.Folder.TemplatesFolder,
                    Name
                });
            }
        }

        public List<SioTemplates.InitViewModel> Templates { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public InitViewModel()
            : base()
        {
        }

        public InitViewModel(SioTheme model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Templates = SioTemplates.InitViewModel.Repository.GetModelListBy(t => t.ThemeId == Id,
                _context: _context, _transaction: _transaction).Data;
            TemplateAsset = new FileViewModel() { FileFolder = $"Import/Themes/{DateTime.UtcNow.ToShortDateString()}/{Name}" };
            Asset = new FileViewModel() { FileFolder = AssetFolder };
        }

        #region Async

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioTheme parent, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            try
            {
                // Clone Default templates
                Name = SeoHelper.GetSEOString(Title);
                string defaultTemplateFolder = $"{SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultTemplateFolder) }";
                bool copyResult = FileRepository.Instance.CopyDirectory(defaultTemplateFolder, TemplateFolder);
                string defaultAssetsFolder = CommonHelper.GetFullPath(new string[] {
                    SioConstants.Folder.WebRootPath,
                    "assets",
                    SioConstants.Folder.TemplatesAssetFolder,
                    "default"
                });
                copyResult = FileRepository.Instance.CopyDirectory(defaultAssetsFolder, AssetFolder);

                var files = FileRepository.Instance.GetFilesWithContent(TemplateFolder);
                //TODO: Create default asset
                int id = 0; 
                foreach (var file in files)
                {
                    id++;
                    string content = file.Content.Replace("/assets/templates/default", $"/{ SioConstants.Folder.FileFolder}/{SioConstants.Folder.TemplatesAssetFolder}/{Name}");
                    SioTemplates.InitViewModel template = new SioTemplates.InitViewModel(
                        new SioTemplate()
                        {
                            Id = id,
                            FileFolder = file.FileFolder,
                            FileName = file.Filename,
                            Content = content,
                            Extension = file.Extension,
                            CreatedDateTime = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            ThemeId = Model.Id,
                            ThemeName = Model.Name,
                            FolderType = file.FolderName,
                            ModifiedBy = CreatedBy
                        }, _context, _transaction);
                    var saveResult = await template.SaveModelAsync(true, _context, _transaction);
                    result.IsSucceed = result.IsSucceed && saveResult.IsSucceed;
                    if (!saveResult.IsSucceed)
                    {
                        result.Exception = saveResult.Exception;
                        result.Errors.AddRange(saveResult.Errors);
                        break;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.IsSucceed = false;
                result.Errors.Add(ex.Message);
                result.Exception = ex;
                return result;
            }

        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(InitViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await SioTemplates.InitViewModel.Repository.RemoveListModelAsync(false,  t => t.ThemeId == Id);
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
