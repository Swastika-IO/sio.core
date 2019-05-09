using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;

namespace Sio.Cms.Lib.ViewModels.SioPageModules
{
    public class ImportViewModel
       : ViewModelBase<SioCmsContext, SioPageModule, ImportViewModel>
    {
        public ImportViewModel(SioPageModule model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ImportViewModel() : base()
        {
        }

        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views
    
        [JsonProperty("module")]
        public SioModules.ImportViewModel Module { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getModule = SioModules.ImportViewModel.Repository.GetSingleModel(p => p.Id == ModuleId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getModule.IsSucceed)
            {
                Module = getModule.Data;
            }
        }

        #region Async

        #endregion Async

        #endregion overrides
    }
}
