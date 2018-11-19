using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Repositories;
using Sio.Cms.Lib.Services;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;


namespace Sio.Cms.Lib.ViewModels.SioTemplates
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioTemplate, ReadViewModel>
    {
        #region Properties

        #region Models

        [JsonIgnore]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonIgnore]
        [JsonProperty("templateId")]
        public int TemplateId { get; set; }

        [JsonIgnore]
        [JsonProperty("templateName")]
        public string TemplateName { get; set; }

        [JsonIgnore]
        [JsonProperty("folderType")]
        public string FolderType { get; set; }

        [JsonIgnore]
        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }

        [JsonIgnore]
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonIgnore]
        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonIgnore]
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonIgnore]
        [JsonProperty("mobileContent")]
        public string MobileContent { get; set; }

        [JsonProperty("spaContent")]
        public string SpaContent { get; set; }

        [JsonProperty("scripts")]
        public string Scripts { get; set; }

        [JsonProperty("styles")]
        public string Styles { get; set; }

        [JsonIgnore]
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonIgnore]
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonIgnore]
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion Models

        #region Views

        [JsonIgnore]
        [JsonProperty("assetFolder")]
        public string AssetFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    SioConstants.Folder.FileFolder,
                    SioConstants.Folder.TemplatesAssetFolder,
                    TemplateName });
            }
        }

        [JsonIgnore]
        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] { SioConstants.Folder.TemplatesFolder, TemplateName });
            }
        }

        [JsonProperty("templatePath")]
        public string TemplatePath
        {
            get
            {
                return CommonHelper.GetFullPath(new string[]
                {
                    ""
                    , TemplateFolder
                    , FileFolder
                });
            }
        }

        //TO DO Ref swastika core SioTemplateViewModel for spa view

        #endregion Views

        #endregion Properties

        #region Contructors

        public ReadViewModel()
            : base()
        {
        }

        public ReadViewModel(SioTemplate model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        #region Common

        public override SioTemplate ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            FileFolder = CommonHelper.GetFullPath(new string[]
                {
                    SioConstants.Folder.TemplatesFolder
                    , TemplateName
                    , FolderType
                });
            Content = Content?.Trim();
            Scripts = Scripts?.Trim();
            Styles = Styles?.Trim();
            return base.ParseModel(_context, _transaction);
        }

        #endregion Common

        #region Async

        public override RepositoryResponse<SioTemplate> RemoveModel(bool isRemoveRelatedModels = false, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.DeleteTemplate(FileName, FileFolder);
            }
            return result;
        }

        public override RepositoryResponse<bool> SaveSubModels(SioTemplate parent, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            TemplateRepository.Instance.SaveTemplate(new TemplateViewModel()
            {
                Filename = FileName,
                Extension = Extension,
                Content = Content,
                FileFolder = FileFolder
            });
            return base.SaveSubModels(parent, _context, _transaction);
        }

        #endregion Async

        #region Async

        public override async Task<RepositoryResponse<SioTemplate>> RemoveModelAsync(bool isRemoveRelatedModels = false, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.DeleteTemplate(FileName, FileFolder);
            }
            return result;
        }

        public override Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioTemplate parent, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            TemplateRepository.Instance.SaveTemplate(new TemplateViewModel()
            {
                Filename = FileName,
                Extension = Extension,
                Content = Content,
                FileFolder = FileFolder
            });
            return base.SaveSubModelsAsync(parent, _context, _transaction);
        }

        #endregion Async

        #endregion Overrides

        #region Expands

        /// <summary>
        /// Gets the template by path.
        /// </summary>
        /// <param name="path">The path.</param> Ex: "Pages/_Home"
        /// <returns></returns>
        public static RepositoryResponse<ReadViewModel> GetTemplateByPath(string path, string culture
            , SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<ReadViewModel> result = new RepositoryResponse<ReadViewModel>();
            string[] temp = path.Split('/');
            if (temp.Length < 2)
            {
                result.IsSucceed = false;
                result.Errors.Add("Template Not Found");
            }
            else
            {
                int activeThemeId = SioService.GetConfig<int>(
                    SioConstants.ConfigurationKeyword.ThemeId, culture);

                result = Repository.GetSingleModel(t => t.FolderType == temp[0] && t.FileName == temp[1].Split('.')[0] && t.ThemeId == activeThemeId
                    , _context, _transaction);
            }
            return result;
        }

        public static ReadViewModel GetTemplateByPath(int themeId, string path, string type, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            string templateName = path?.Split('/')[1];
            var getView = ReadViewModel.Repository.GetSingleModel(t =>
                    t.ThemeId == themeId && t.FolderType == type
                    && !string.IsNullOrEmpty(templateName) && templateName.Equals($"{t.FileName}{t.Extension}"), _context, _transaction);
            return getView.Data;
        }

        public static ReadViewModel GetDefault(string activedTemplate, string folderType, string folder, string specificulture)
        {
            return new ReadViewModel(new SioTemplate()
            {
                Extension = SioService.GetConfig<string>("TemplateExtension"),
                ThemeId = SioService.GetConfig<int>(SioConstants.ConfigurationKeyword.ThemeId, specificulture),
                ThemeName = activedTemplate,
                FolderType = folderType,
                FileFolder = folder,
                FileName = SioService.GetConfig<string>("DefaultTemplate"),
                Content = "<div></div>"
            });

        }
        #endregion Expands

    }
}
