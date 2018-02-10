using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Core.ViewModels;
using System.Linq.Expressions;
using Swastika.Cms.Lib.Repositories;
using System.Threading.Tasks;
using Swastika.Cms.Lib.Services;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEMediaViewModel
        : ViewModelBase<SiocCmsContext, SiocMedia, BEMediaViewModel>
    {
        #region Properties
        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("extension")]
        public string Extension { get; set; }
        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }
        [JsonProperty("fileName")]
        public string FileName { get; set; }
        [JsonProperty("fileType")]
        public string FileType { get; set; }
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

        public BEMediaViewModel() : base()
        {
        }

        public BEMediaViewModel(SiocMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported = true);
        }
        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result =base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder);
            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder);
            }
            return result;
        }
        #endregion

        #region Expands

        #endregion

    }
}
