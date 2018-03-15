// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEArticleMediaViewModel
        : ViewModelBase<SiocCmsContext, SiocArticleMedia, BEArticleMediaViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("articleId")]
        public string ArticleId { get; set; }

        [JsonProperty("mediaId")]
        public int MediaId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("media")]
        public BEMediaViewModel Media { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public BEArticleMediaViewModel() : base()
        {
        }

        public BEArticleMediaViewModel(SiocArticleMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMediaResult = BEMediaViewModel.Repository.GetSingleModel(
                m => m.Id == MediaId && m.Specificulture == Specificulture
                && ArticleId == ArticleId
                , _context: _context, _transaction: _transaction);
            if (getMediaResult.IsSucceed)
            {
                this.Media = getMediaResult.Data;
            }
        }

        #endregion Overrides
    }
}
