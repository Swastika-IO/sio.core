using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ModuleArticleViewModel: ViewModelBase<SiocCmsContext, SiocModuleArticle, ModuleArticleViewModel>
    {
        public ModuleArticleViewModel(SiocModuleArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
        public ModuleArticleViewModel(): base()
        {

        }
        public string ArticleId { get; set; }
        public int ModuleId { get; set; }
        //public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }

        #region Override

        #region Async

        //public override async Task<RepositoryResponse<ModuleArticleViewModel>> CloneAsync(string desSpecificulture, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        //{
        //    //Check is destinate cate and article already defined in des culture
        //    bool isValidDes = ModuleListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.ModuleId && c.Specificulture == desSpecificulture, _context, _transaction)
        //    && ModuleListItemViewModel.Repository.CheckIsExists(
        //        c => c.Id == this.ModuleId && c.Specificulture == desSpecificulture, _context, _transaction);
        //    RepositoryResponse<ModuleArticleViewModel> result = new RepositoryResponse<ModuleArticleViewModel>();

        //    if (isValidDes)
        //    {
        //        var data = new ModuleArticleViewModel(
        //            new SiocModuleArticle()
        //            {
        //                ArticleId = this.ArticleId,
        //                Specificulture = desSpecificulture,
        //                ModuleId = this.ModuleId
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
        #region Expand

        #endregion
    }
}
