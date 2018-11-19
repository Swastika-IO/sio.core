using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;

namespace Sio.Cms.Lib.ViewModels.SioProductMedias
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioProductMedia, ReadViewModel>
    {
        public ReadViewModel(SioProductMedia model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
        {
        }

        [JsonProperty("mediaId")]
        public int MediaId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public SioMedias.UpdateViewModel Media { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMedia = SioMedias.UpdateViewModel.Repository.GetSingleModel(p => p.Id == MediaId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getMedia.IsSucceed)
            {
                Media = getMedia.Data;
            }
        }

        #region Async

        #endregion Async

        #endregion overrides
    }
}
