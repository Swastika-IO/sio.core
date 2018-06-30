// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels
{
    public class CategoryArticleViewModel : ViewModelBase<SiocCmsContext, SiocCategoryArticle, CategoryArticleViewModel>
    {
        public CategoryArticleViewModel(SiocCategoryArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public CategoryArticleViewModel() : base()
        {
        }

        public string ArticleId { get; set; }
        public int CategoryId { get; set; }

        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region overrides

        #region Async

        #endregion Async

        #endregion overrides
    }
}
