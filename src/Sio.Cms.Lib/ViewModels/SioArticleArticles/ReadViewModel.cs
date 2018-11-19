using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;

namespace Sio.Cms.Lib.ViewModels.SioArticleArticles
{
    public class ReadViewModel
        : ViewModelBase<SioCmsContext, SioRelatedArticle, ReadViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("sourceId")]
        public int SourceId { get; set; }

        [JsonProperty("destinationId")]
        public int DestinationId { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("relatedArticle")]
        public SioArticles.ReadListItemViewModel RelatedArticle { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public ReadViewModel() : base()
        {
        }

        public ReadViewModel(SioRelatedArticle model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getArticle = SioArticles.ReadListItemViewModel.Repository.GetSingleModel(
                m => m.Id == DestinationId && m.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction);
            if (getArticle.IsSucceed)
            {
                this.RelatedArticle = getArticle.Data;
            }
        }

        public override SioRelatedArticle ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (CreatedDateTime == default(DateTime))
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }

        #endregion Overrides
    }
}
