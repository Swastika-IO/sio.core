using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavProductMediaViewModel
        : ViewModelBase<SiocCmsContext, SiocProductMedia, NavProductMediaViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("mediaId")]
        public int MediaId { get; set; }
        [JsonProperty("productId")]
        public string ProductId { get; set; }
        [JsonProperty("position")]
        public int Position { get; set; }

        #endregion

        #region Views
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("media")]
        public BEMediaViewModel Media { get; set; }

        #endregion

        #endregion

        #region Contructors

        public NavProductMediaViewModel() : base()
        {
        }

        public NavProductMediaViewModel(SiocProductMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMedia = BEMediaViewModel.Repository.GetSingleModel(m => m.Id == MediaId && m.Specificulture == Specificulture
            , _context: _context, _transaction: _transaction
            );
            Media = getMedia.Data;
        }

        #endregion

        #region Expands

        #endregion

    }
}
