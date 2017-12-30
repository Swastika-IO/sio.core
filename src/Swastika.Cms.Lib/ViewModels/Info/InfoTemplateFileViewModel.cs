using System;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Domain.Core.ViewModels;
using Swastika.Cms.Lib.Repositories;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoTemplateFileViewModel
       : ViewModelBase<SiocCmsContext, SiocTemplateFile, InfoTemplateFileViewModel>
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
      
        #endregion

        #endregion

        #region Contructors

        public InfoTemplateFileViewModel() 
            : base()
        {
        }

        public InfoTemplateFileViewModel(SiocTemplateFile model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #region Common

        public override SiocTemplateFile ParseModel()
        {
            if (Id==0)
            {
                CreatedDateTime = DateTime.UtcNow;                
            }
            FileFolder = SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , TemplateName
                    , FolderType
                });
            Content = Content.Trim();
            return base.ParseModel();
        }

        #endregion
        #region Sync
        public override RepositoryResponse<InfoTemplateFileViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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

        public override async Task<RepositoryResponse<InfoTemplateFileViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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
