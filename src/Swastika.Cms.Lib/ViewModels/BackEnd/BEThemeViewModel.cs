using System;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Domain.Core.ViewModels;
using System.Threading.Tasks;
using Swastika.IO.Common.Helper;
using Swastika.Cms.Lib.Repositories;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Swastika.Cms.Lib.ViewModels.Info;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEThemeViewModel
       : ViewModelBase<SiocCmsContext, SiocTheme, BEThemeViewModel>
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

        public BEThemeViewModel()
            : base()
        {
        }

        public BEThemeViewModel(SiocTheme model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override SiocTheme ParseModel()
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel();
        }

        #region Sync
        public override RepositoryResponse<BEThemeViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.SaveModel(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                if (IsActived)
                {
                    ConfigurationViewModel config = (ConfigurationViewModel.Repository.GetSingleModel(
                        c => c.Keyword == SWCmsConstants.ConfigurationKeyword.Theme, _context, _transaction)).Data;
                    if (config == null)
                    {
                        config = new ConfigurationViewModel()
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
                    var saveConfigResult = config.SaveModel(false, _context, _transaction);
                    if (!saveConfigResult.IsSucceed)
                    {
                        Errors.AddRange(saveConfigResult.Errors);
                    }
                    result.IsSucceed = result.IsSucceed && saveConfigResult.IsSucceed;

                    ConfigurationViewModel configId = (ConfigurationViewModel.Repository.GetSingleModel(
                          c => c.Keyword == SWCmsConstants.ConfigurationKeyword.ThemeId, _context, _transaction)).Data;
                    if (configId == null)
                    {
                        configId = new ConfigurationViewModel()
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
                    var saveResult = configId.SaveModel(false, _context, _transaction);
                    if (!saveResult.IsSucceed)
                    {
                        Errors.AddRange(saveResult.Errors);
                    }
                    result.IsSucceed = result.IsSucceed && saveResult.IsSucceed;

                }
                if (Id == 0)
                {
                    string defaultFolder = CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesFolder, SWCmsConstants.Default.DefaultTemplateFolder });
                    var files = FileRepository.Instance.CopyDirectory(defaultFolder, TemplateFolder);
                    foreach (var file in files)
                    {
                        if (file.FolderName != "Assets")
                        {
                            BETemplateViewModel template = new BETemplateViewModel()
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
                            };
                            template.SaveModel(true, _context, _transaction);
                        }
                    }

                }
                if (Asset != null && Asset.Length > 0)
                {
                    var files = FileRepository.Instance.GetWebFiles(AssetFolder);
                    string strStyles = string.Empty;
                    foreach (var css in files.Where(f => f.Extension == ".css"))
                    {
                        strStyles += string.Format(@"   <link href='{0}/{1}{2}' rel='stylesheet'/>
", css.FileFolder, css.Filename, css.Extension);
                    }
                    string strScripts = string.Empty;
                    foreach (var js in files.Where(f => f.Extension == ".js"))
                    {
                        strScripts += string.Format(@"  <script src='{0}/{1}{2}'></script>
", js.FileFolder, js.Filename, js.Extension);
                    }
                    var layout = InfoTemplateViewModel.Repository.GetSingleModel(
                        t => t.FileName == "_Layout" && t.TemplateId == Model.Id
                        , _context, _transaction);
                    layout.Data.Content = layout.Data.Content.Replace("<!--[STYLES]-->", strStyles + @"
<!--[STYLES]-->");
                    layout.Data.Content = layout.Data.Content.Replace("<!--[SCRIPTS]-->", strScripts + @"
<!--[SCRIPTS]-->");
                    layout.Data.SaveModel(true, _context, _transaction);
                }
            }
            return result;
        }
        public override RepositoryResponse<bool> SaveSubModels(SiocTheme parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };

            if (Asset != null && Asset.Length > 0)
            {
                string filename = FileRepository.Instance.SaveWebFile(Asset, AssetFolder);
                if (!string.IsNullOrEmpty(filename))
                {
                    FileRepository.Instance.UnZipFile(filename, AssetFolder);
                }
            }
            return result;
        }

        public override RepositoryResponse<bool> RemoveRelatedModels(BEThemeViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            result = InfoTemplateViewModel.Repository.RemoveListModel(t => t.TemplateId == Id);
            if (result.IsSucceed)
            {
                FileRepository.Instance.DeleteWebFolder(AssetFolder);
                FileRepository.Instance.DeleteFolder(TemplateFolder);
            }
            return result;
        }
        #endregion

        #region Async
        public override async Task<RepositoryResponse<BEThemeViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                if (IsActived)
                {
                    ConfigurationViewModel config = (await ConfigurationViewModel.Repository.GetSingleModelAsync(
                        c => c.Keyword == SWCmsConstants.ConfigurationKeyword.Theme, _context, _transaction)).Data;
                    if (config == null)
                    {
                        config = new ConfigurationViewModel()
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
                    result.IsSucceed = result.IsSucceed && saveConfigResult.IsSucceed;

                    ConfigurationViewModel configId = (await ConfigurationViewModel.Repository.GetSingleModelAsync(
                          c => c.Keyword == SWCmsConstants.ConfigurationKeyword.ThemeId, _context, _transaction)).Data;
                    if (configId == null)
                    {
                        configId = new ConfigurationViewModel()
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
                    result.IsSucceed = result.IsSucceed && saveResult.IsSucceed;
                }                

                if (Asset != null && Asset.Length > 0)
                {
                    var files = FileRepository.Instance.GetWebFiles(AssetFolder);
                    string strStyles = string.Empty;
                    foreach (var css in files.Where(f => f.Extension == ".css"))
                    {
                        strStyles += string.Format(@"   <link href='{0}/{1}{2}' rel='stylesheet'/>
", css.FileFolder, css.Filename, css.Extension);
                    }
                    string strScripts = string.Empty;
                    foreach (var js in files.Where(f => f.Extension == ".js"))
                    {
                        strScripts += string.Format(@"  <script src='{0}/{1}{2}'></script>
", js.FileFolder, js.Filename, js.Extension);
                    }
                    var layout = BETemplateViewModel.Repository.GetSingleModel(
                        t => t.FileName == "_Layout" && t.TemplateId == Model.Id
                        , _context, _transaction);
                    layout.Data.Content = layout.Data.Content.Replace("<!--[STYLES]-->", strStyles + @"
<!--[STYLES]-->");
                    layout.Data.Content = layout.Data.Content.Replace("<!--[SCRIPTS]-->", strScripts + @"
<!--[SCRIPTS]-->");
                    await layout.Data.SaveModelAsync(true, _context, _transaction);
                }
            }
            return result;
        }
        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocTheme parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };

            if (Asset != null && Asset.Length > 0)
            {
                string filename = FileRepository.Instance.SaveWebFile(Asset, AssetFolder);
                if (!string.IsNullOrEmpty(filename))
                {
                    FileRepository.Instance.UnZipFile(filename, AssetFolder);
                }
            }
            if (Id == 0)
            {
                string defaultFolder = CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesFolder, SWCmsConstants.Default.DefaultTemplateFolder });
                var files = FileRepository.Instance.CopyDirectory(defaultFolder, TemplateFolder);
                foreach (var file in files)
                {
                    BETemplateViewModel template = new BETemplateViewModel()
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
                    };
                   var saveResult=  await template.SaveModelAsync(true, _context, _transaction);
                    result.IsSucceed = result.IsSucceed && saveResult.IsSucceed;
                    if (!saveResult.IsSucceed)
                    {
                        result.Exception = saveResult.Exception;
                        result.Errors.AddRange(saveResult.Errors);
                        break;
                    }

                }

            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(BEThemeViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            result = await InfoTemplateViewModel.Repository.RemoveListModelAsync(t => t.TemplateId == Id);
            if (result.IsSucceed)
            {
                FileRepository.Instance.DeleteWebFolder(AssetFolder);
                FileRepository.Instance.DeleteFolder(TemplateFolder);
            }
            return result;
        }
        #endregion
        #endregion
    }
}
