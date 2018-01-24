using System;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.Repositories;
using System.Threading.Tasks;
using Swastika.Common.Helper;
using Newtonsoft.Json.Linq;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BETemplateViewModel
       : ViewModelBase<SiocCmsContext, SiocTemplate, BETemplateViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("templateId")]
        public int TemplateId { get; set; }
        [JsonProperty("templateName")]
        public string TemplateName { get; set; }
        [JsonProperty("folderType")]
        public string FolderType { get; set; }
        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }
        [JsonProperty("fileName")]
        public string FileName { get; set; }
        [JsonProperty("extension")]
        public string Extension { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonIgnore]
        [JsonProperty("mobileContent")]
        public string MobileContent { get; set; } = "{}";
        [JsonProperty("spaContent")]
        public string SpaContent { get; set; } = "";
        [JsonProperty("scripts")]
        public string Scripts { get; set; }
        [JsonProperty("styles")]
        public string Styles { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion

        #region Views
        [JsonProperty("assetFolder")]
        public string AssetFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.FileFolder,
                    SWCmsConstants.Parameters.TemplatesAssetFolder,
                    TemplateName });
            }
        }
        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesFolder, TemplateName });
            }
        }

        public string TemplatePath
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    ""
                    , TemplateFolder
                    , FileFolder
                });
            }
        }

        [JsonProperty("mobileView")]
        public JObject MobileView { get { return !string.IsNullOrEmpty(MobileContent)? JObject.Parse(MobileContent): new JObject(); } }
        #endregion

        #endregion

        #region Contructors

        public BETemplateViewModel()
            : base()
        {
        }

        public BETemplateViewModel(SiocTemplate model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #region Common

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            //var file = FileRepository.Instance.GetFile(FileName, Extension, FileFolder);
            //if (!string.IsNullOrWhiteSpace(file?.Content))
            //{
            //    Content = file.Content;
            //}
            //var file = FileRepository.Instance.GetFile("Style", ".Json", FileFolder);
            //if (!string.IsNullOrWhiteSpace(file?.Content))
            //{
            //    string json = file.Content.Replace("\r\n", "").Trim();
            //    MobileContent= JObject.Parse(json);
            //}

        }
        public override SiocTemplate ParseModel()
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            FileFolder = SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , TemplateName
                    , FolderType
                });
            //if (FileName.IndexOf(Extension)==-1)
            //{
            //    FileName += Extension;
            //}
            Content = Content?.Trim();
            Scripts = Scripts?.Trim();
            Styles = Styles?.Trim();
            return base.ParseModel();
        }

        #endregion
        #region Async
        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.DeleteTemplate(FileName, FileFolder);
            }
            return result;
        }

        public override RepositoryResponse<bool> SaveSubModels(SiocTemplate parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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
        #endregion
        #region Async
        public override async Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.DeleteTemplate(FileName, FileFolder);
            }
            return result;
        }

        public override Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocTemplate parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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
        #endregion

        #endregion

    }
}
