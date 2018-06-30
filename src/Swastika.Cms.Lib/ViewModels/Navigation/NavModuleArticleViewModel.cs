// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavModuleArticleViewModel : ViewModelBase<SiocCmsContext, SiocModuleArticle, NavModuleArticleViewModel>
    {
        public NavModuleArticleViewModel(SiocModuleArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        public NavModuleArticleViewModel() : base()
        {
        }
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }
        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public InfoArticleViewModel Article { get; set; }

        #endregion Views

        #region Override

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(p => p.Id == ArticleId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getArticle.IsSucceed)
            {
                Article = getArticle.Data;
            }
        }

        #region Async


        #endregion Async

        #endregion Override
    }
}
