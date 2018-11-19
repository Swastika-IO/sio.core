using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;

namespace Sio.Cms.Lib.ViewModels.SioPagePositions
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioPagePosition, ReadViewModel>
    {
        public ReadViewModel(SioPagePosition model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
        {
        }

        [JsonProperty("PositionId")]
        public int PositionId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public SioPositions.ReadViewModel Position { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getPosition = SioPositions.ReadViewModel.Repository.GetSingleModel(p => p.Id == PositionId
                , _context: _context, _transaction: _transaction
            );
            if (getPosition.IsSucceed)
            {
                Position = getPosition.Data;
            }
        }

        #region Async

        #endregion Async

        #endregion overrides
    }
}
