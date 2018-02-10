using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Domain.Data.ViewModels;
using Swastika.Cms.Lib.Models.Cms;
using System.ComponentModel.DataAnnotations;
using Swastika.Domain.Core.ViewModels;
using System.Threading.Tasks;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.Models;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BELanguageViewModel :
        ViewModelBase
        <SiocCmsContext, SiocLanguage, BELanguageViewModel>
    {
        [Required]
        public string Keyword { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
        public SWCmsConstants.DataType DataType { get; set; }
        public string Description { get; set; }


        public BELanguageViewModel() : base()
        {
        }

        public BELanguageViewModel(
            SiocLanguage model
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {

        }

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported = true);
        }

        public override RepositoryResponse<BELanguageViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.SaveModel(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }

        public override async Task<RepositoryResponse<BELanguageViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }

        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }
        public override async Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }

        public override RepositoryResponse<List<BELanguageViewModel>> Clone(List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Model.Value = Model.Keyword;
            return base.Clone(cloneCultures, _context, _transaction);
        }

        public override Task<RepositoryResponse<List<BELanguageViewModel>>> CloneAsync(List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Model.Value = Model.Keyword;
            return base.CloneAsync(cloneCultures, _context, _transaction);
        }
        #endregion
    }
}
