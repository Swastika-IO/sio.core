using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;

namespace Sio.Cms.Lib.ViewModels.SioPageProducts
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioPageProduct, ReadViewModel>
    {
        public ReadViewModel(SioPageProduct model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
        {
        }

        [JsonProperty("ProductId")]
        public int ProductId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public SioProducts.ReadListItemViewModel Product { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getProduct = SioProducts.ReadListItemViewModel.Repository.GetSingleModel(p => p.Id == ProductId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getProduct.IsSucceed)
            {
                Product = getProduct.Data;
            }
        }

        #region Async

        #endregion Async

        #endregion overrides
    }
}
