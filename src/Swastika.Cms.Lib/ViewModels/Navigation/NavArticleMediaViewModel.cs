using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavArticleMediaViewModel
        : ViewModelBase<SiocCmsContext, SiocArticleMedia, NavArticleMediaViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("mediaId")]
        public int MediaId { get; set; }
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion

        #region Views
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("media")]
        public BEMediaViewModel Media { get; set; }

        #endregion

        #endregion

        #region Contructors

        public NavArticleMediaViewModel() : base()
        {
        }

        public NavArticleMediaViewModel(SiocArticleMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
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
