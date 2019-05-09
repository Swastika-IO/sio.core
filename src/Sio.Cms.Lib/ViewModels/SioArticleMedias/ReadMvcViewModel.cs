using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.ViewModels.SioMedias;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;

namespace Sio.Cms.Lib.ViewModels.SioArticleMedias
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioArticleMedia, ReadViewModel>
    {
        public ReadViewModel(SioArticleMedia model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
        {
        }

        [JsonProperty("mediaId")]
        public int MediaId { get; set; }

        [JsonProperty("articleId")]
        public int ArticleId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public UpdateViewModel Media { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMedia = UpdateViewModel.Repository.GetSingleModel(p => p.Id == MediaId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getMedia.IsSucceed)
            {
                Media = getMedia.Data;
            }
        }
        public override RepositoryResponse<bool> SaveSubModels(SioArticleMedia parent, SioCmsContext _context, IDbContextTransaction _transaction)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var saveMedia = Media.SaveModel(false, _context, _transaction);
            if (!saveMedia.IsSucceed)
            {
                result.IsSucceed = false;
                result.Exception = saveMedia.Exception;
                result.Errors = saveMedia.Errors;
            }
            return result;
        }
        #region Async

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioArticleMedia parent, SioCmsContext _context, IDbContextTransaction _transaction)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var saveMedia = await Media.SaveModelAsync(false, _context, _transaction);
            if (!saveMedia.IsSucceed)
            {
                result.IsSucceed = false;
                result.Exception = saveMedia.Exception;
                result.Errors = saveMedia.Errors;
            }
            return result;
        }
        #endregion Async

        #endregion overrides
    }
}
