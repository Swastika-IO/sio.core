using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Cms.Lib.ViewModels.Info;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavCategoryArticleViewModel 
        : ViewModelBase<SiocCmsContext, SiocCategoryArticle, NavCategoryArticleViewModel>
    {
        public NavCategoryArticleViewModel(SiocCategoryArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }
        public NavCategoryArticleViewModel(): base()
        {

        }

        public string ArticleId { get; set; }
        public int CategoryId { get; set; }
        //public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }
        #region Views
        public InfoArticleViewModel Article { get; set; }
        #endregion
        #region overrides

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
