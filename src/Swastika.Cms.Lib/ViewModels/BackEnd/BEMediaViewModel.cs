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
        [JsonProperty("fileSize")]
        public int FileSize { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }
        #endregion

        #region Views
        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }

        [JsonProperty("fullPath")]
        public string FullPath
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]{
                    Domain,
                    FileFolder,
                    $"{FileName}{Extension}"
                });
            }
        }

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
        public override SiocMedia ParseModel()
        {
            if (Id == 0)
            {
                Id = BEMediaViewModel.Repository.Max(c => c.Id).Data + 1;
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel();
        }
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported = true);
        }
      
        public override RepositoryResponse<bool> RemoveRelatedModels(BEMediaViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>();

            result.IsSucceed = FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder);
            return result;
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(BEMediaViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>();

            result.IsSucceed = FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder);
            return result;
        }
        #endregion

        #region Expands

        #endregion

    }
}
