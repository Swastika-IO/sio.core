using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Domain.Data.ViewModels;
using Swastika.Cms.Lib.Models.Cms;
using System.ComponentModel.DataAnnotations;
using Swastika.Domain.Core.ViewModels;
using System.Threading.Tasks;
using Swastika.Cms.Lib.Services;

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
            this.ListSupportedCulture.ForEach(c => c.IsSupported =
            (string.IsNullOrEmpty(Keyword) && c.Specificulture == Specificulture)
            || Repository.CheckIsExists(a => a.Keyword == Keyword && a.Specificulture == c.Specificulture, _context, _transaction)
            );
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
        #endregion
    }
}
