using System;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Domain.Core.ViewModels;
using Swastika.Cms.Lib.Repositories;
using System.Threading.Tasks;
using Swastika.IO.Common.Helper;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoTemplateViewModel
       : ViewModelBase<SiocCmsContext, SiocTemplate, InfoTemplateViewModel>
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
                return CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesAssetFolder, TemplateName });
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
        #endregion

        #endregion

        #region Contructors

        public InfoTemplateViewModel()
            : base()
        {
        }

        public InfoTemplateViewModel(SiocTemplate model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #region Common

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
            Content = Content.Trim();
            return base.ParseModel();
        }

        public override void Validate(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            base.Validate(_context, _transaction);
            if (Repository.CheckIsExists(t => Id == 0 && t.FileName == FileName && t.FileFolder == FileFolder && t.Extension == Extension))
            {
                IsValid = false;
                Errors.Add("File Name existed");
            }
        }

        #endregion
        #region Sync
        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.DeleteTemplate(FileName, FileFolder);
            }
            return result;
        }
        public override RepositoryResponse<InfoTemplateViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {

            var result = base.SaveModel(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.SaveTemplate(new TemplateViewModel()
                {
                    Filename = FileName,
                    Extension = Extension,
                    Content = Content,
                    FileFolder = FileFolder
                });
            }
            return result;
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
        public override async Task<RepositoryResponse<InfoTemplateViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                if (result.IsSucceed)
                {
                    TemplateRepository.Instance.SaveTemplate(new TemplateViewModel()
                    {
                        Filename = FileName,
                        Extension = Extension,
                        Content = Content,
                        FileFolder = FileFolder
                    });
                }
            }
            return result;
        }

        #endregion

        #endregion
    }
}
