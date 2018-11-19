using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;

namespace Sio.Cms.Lib.ViewModels.SioPortalPageRoles
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioPortalPageRole, ReadViewModel>
    {
        #region Properties

        #region Model
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("pageId")]
        public int PageId { get; set; }

        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        #endregion

        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("page")]
        public SioPortalPages.ReadViewModel Page { get; set; }

        #endregion Views

        #endregion

        public ReadViewModel(SioPortalPageRole model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
        {
        }


        #region overrides

        public override SioPortalPageRole ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (CreatedDateTime == default(DateTime))
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCategory = SioPortalPages.ReadViewModel.Repository.GetSingleModel(p => p.Id == Id
            , _context: _context, _transaction: _transaction
            );
            if (getCategory.IsSucceed)
            {
                Page = getCategory.Data;
            }
        }

        #endregion overrides
    }
}
