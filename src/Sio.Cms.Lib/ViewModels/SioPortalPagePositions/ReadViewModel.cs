using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;

namespace Sio.Cms.Lib.ViewModels.SioPortalPagePositions
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioPortalPagePosition, ReadViewModel>
    {
        public ReadViewModel(SioPortalPagePosition model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
        {
        }

        [JsonProperty("positionId")]
        public int PositionId { get; set; }
        [JsonProperty("portalPageId")]
        public int PortalPageId { get; set; }
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public SioPositions.ReadViewModel Position { get; set; }

        #endregion Views

        #region overrides
        public override SioPortalPagePosition ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Priority == 0)
            {
                Priority = Repository.Max(n => n.Priority).Data + 1;
            }
            return base.ParseModel(_context, _transaction);
        }
        #region Async

        #endregion Async

        #endregion overrides
    }
}
