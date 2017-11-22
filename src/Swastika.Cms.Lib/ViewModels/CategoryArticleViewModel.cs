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
    public class CategoryArticleViewModel : ViewModelBase<SiocCmsContext, SiocCategoryArticle, CategoryArticleViewModel>
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

        //public override async Task<RepositoryResponse<CategoryArticleViewModel>> CloneAsync(string desSpecificulture, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        //{
        //    //Check is destinate cate and article already defined in des culture
        //    bool isValidDes = CategoryListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.CategoryId && c.Specificulture == desSpecificulture, _context, _transaction)
        //    && CategoryListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.CategoryId && c.Specificulture == desSpecificulture, _context, _transaction);
        //    RepositoryResponse<CategoryArticleViewModel> result = new RepositoryResponse<CategoryArticleViewModel>();

        //    if (isValidDes)
        //    {
        //        var data = new CategoryArticleViewModel(
        //            new SiocCategoryArticle()
        //            {
        //                ArticleId = this.ArticleId,
        //                Specificulture = desSpecificulture,
        //                CategoryId = this.CategoryId
        //            },
        //            _context, _transaction)
        //        {
        //            IsActived = this.IsActived,
        //            Description = this.Description
        //        };
        //        var saveResult = await data.SaveModelAsync(_context: _context, _transaction: _transaction);
        //        if (saveResult.IsSucceed)
        //        {
        //            result.IsSucceed = true;
        //            result.Data = data;
        //        }
        //        return result;
        //    }
        //    else
        //    {
        //        return result;
        //    }

        //}

        #endregion

        #region Sync


        #endregion

        #endregion

    }
}
