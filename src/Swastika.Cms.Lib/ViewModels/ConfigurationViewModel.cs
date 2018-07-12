// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ConfigurationViewModel :
        ViewModelBase
        <SiocCmsContext, SiocConfiguration, ConfigurationViewModel>
    {
        [Required]
        public string Keyword { get; set; }

        public string Category { get; set; }
        public string Value { get; set; }
        public SWCmsConstants.DataType DataType { get; set; }
        public string Description { get; set; }

        public ConfigurationViewModel() : base()
        {
        }

        public ConfigurationViewModel(
            SiocConfiguration model
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

        public override RepositoryResponse<ConfigurationViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.SaveModel(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.Refresh(_context, _transaction);
            }
            return result;
        }

        public override async Task<RepositoryResponse<ConfigurationViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.Refresh(_context, _transaction);
            }
            return result;
        }

        #endregion Overrides
    }
}
