using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace Swastika.Cms.Lib.ViewModels
{
    public class NavCategoryProductViewModel 
        : ViewModelBase<SiocCmsContext, SiocCategoryProduct, NavCategoryProductViewModel>
    {
        public NavCategoryProductViewModel(SiocCategoryProduct model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }
        public NavCategoryProductViewModel(): base()
        {

        }

        public string ProductId { get; set; }
        public int CategoryId { get; set; }
        //public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }
        
        #region overrides

        #region Async

        //public override async Task<RepositoryResponse<CategoryProductViewModel>> CloneAsync(string desSpecificulture, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        //{
        //    //Check is destinate cate and product already defined in des culture
        //    bool isValidDes = CategoryListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.CategoryId && c.Specificulture == desSpecificulture, _context, _transaction)
        //    && CategoryListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.CategoryId && c.Specificulture == desSpecificulture, _context, _transaction);
        //    RepositoryResponse<CategoryProductViewModel> result = new RepositoryResponse<CategoryProductViewModel>();

        //    if (isValidDes)
        //    {
        //        var data = new CategoryProductViewModel(
        //            new SiocCategoryProduct()
        //            {
        //                ProductId = this.ProductId,
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
