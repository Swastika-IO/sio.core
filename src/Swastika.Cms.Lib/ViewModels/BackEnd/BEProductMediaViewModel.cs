using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using System.Threading.Tasks;
using Swastika.Cms.Lib.ViewModels.FrontEnd;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEProductMediaViewModel
        : ViewModelBase<SiocCmsContext, SiocProductMedia, BEProductMediaViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("productId")]
        public string ProductId { get; set; }
        [JsonProperty("mediaId")]
        public int MediaId { get; set; }
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        #endregion

        #region Views
        [JsonProperty("media")]
        public BEMediaViewModel Media { get; set; }
        #endregion

        #endregion

        #region Contructors

        public BEProductMediaViewModel() : base()
        {
        }

        public BEProductMediaViewModel(SiocProductMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMediaResult = BEMediaViewModel.Repository.GetSingleModel(
                m => m.Id == MediaId && m.Specificulture == Specificulture
                && ProductId == ProductId
                , _context:_context, _transaction: _transaction);
            if (getMediaResult.IsSucceed)
            {
                this.Media = getMediaResult.Data;
            }
        }

        #region Async
      
        #endregion
        #endregion

        #region Expands

        #endregion

    }
}
