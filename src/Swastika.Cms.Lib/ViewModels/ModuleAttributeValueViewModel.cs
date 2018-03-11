// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ModuleAttributeValueViewModel
        : ViewModelBase<SiocCmsContext, SiocModuleAttributeValue, ModuleAttributeValueViewModel>
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public string DefaultValue { get; set; }

        #region Overrides

        public override void Validate(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (DataType == 0)
            {
                Errors.Add("aaaa");
                IsValid = false;
            }
            base.Validate(_context, _transaction);
        }

        public override RepositoryResponse<bool> SaveSubModels(SiocModuleAttributeValue parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            return base.SaveSubModels(parent, _context, _transaction);
        }

        public override RepositoryResponse<bool> RemoveRelatedModels(
            ModuleAttributeValueViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            return base.RemoveRelatedModels(view, _context, _transaction);
        }

        #endregion Overrides
    }
}
