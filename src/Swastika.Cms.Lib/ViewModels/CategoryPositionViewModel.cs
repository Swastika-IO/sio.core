using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace Swastika.Cms.Lib.ViewModels
{
    public class CategoryPositionViewModel : ViewModelBase<SiocCmsContext, SiocCategoryPosition, CategoryPositionViewModel>
    {
        public CategoryPositionViewModel(SiocCategoryPosition model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }
        public CategoryPositionViewModel(): base()
        {

        }

        public int PositionId { get; set; }
        public int CategoryId { get; set; }
        //public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }
        
        #region overrides

        #region Async

        //public override async Task<RepositoryResponse<CategoryPositionViewModel>> CloneAsync(string desSpecificulture, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        //{
        //    //Check is destinate cate and Position already defined in des culture
        //    bool isValidDes = CategoryListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.CategoryId && c.Specificulture == desSpecificulture, _context, _transaction)
        //    && CategoryListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.CategoryId && c.Specificulture == desSpecificulture, _context, _transaction);
        //    RepositoryResponse<CategoryPositionViewModel> result = new RepositoryResponse<CategoryPositionViewModel>();

        //    if (isValidDes)
        //    {
        //        var data = new CategoryPositionViewModel(
        //            new SiocCategoryPosition()
        //            {
        //                PositionId = this.PositionId,
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
