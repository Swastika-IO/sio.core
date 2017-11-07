using Swastika.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Infrastructure.Data.Repository;
using Swastika.IO.Cms.Lib.Models;
using Swastika.Domain.Core.Models;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels
{
    public class CategoryArticleViewModel: ViewModelBase<SiocCmsContext, SiocCategoryArticle, CategoryArticleViewModel>
    {
        public CategoryArticleViewModel(SiocCategoryArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }
        

        public string ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }

        #region overrides

        #region Async
        
        #endregion

        #region Sync

      
        #endregion

        #endregion

    }
}
