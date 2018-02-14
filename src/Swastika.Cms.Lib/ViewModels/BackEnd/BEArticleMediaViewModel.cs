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
        #endregion

        #region Views
        [JsonProperty("media")]
        public BEMediaViewModel Media { get; set; }
        #endregion

        #endregion

        #region Contructors

        public BEArticleMediaViewModel() : base()
        {
        }

        public BEArticleMediaViewModel(SiocArticleMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMediaResult = BEMediaViewModel.Repository.GetSingleModel(
                m => m.Id == MediaId && m.Specificulture == Specificulture
                && ArticleId == ArticleId
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
