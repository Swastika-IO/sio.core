// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.Models;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
            ListSupportedCulture = GlobalConfigurationService.Instance.CmsCulture.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported = true);
        }

        public override RepositoryResponse<BELanguageViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.SaveModel(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {                
                GlobalConfigurationService.Instance.RefreshCultures(_context, _transaction);
            }
            return result;
        }

        public override async Task<RepositoryResponse<BELanguageViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.RefreshCultures(_context, _transaction);
            }
            return result;
        }

        public override RepositoryResponse<SiocLanguage> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.RefreshCultures(_context, _transaction);
            }
            return result;
        }

        public override async Task<RepositoryResponse<SiocLanguage>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.RefreshCultures(_context, _transaction);
            }
            return result;
        }

        #endregion Overrides
    }
}
