// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavCategoryModuleViewModel
        : ViewModelBase<SiocCmsContext, SiocCategoryModule, NavCategoryModuleViewModel>
    {
        public NavCategoryModuleViewModel(SiocCategoryModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public NavCategoryModuleViewModel() : base()
        {
        }

        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public FEModuleViewModel Module { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getModule = FEModuleViewModel.Repository.GetSingleModel(p => p.Id == ModuleId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getModule.IsSucceed)
            {
                Module = getModule.Data;
            }
        }

        #region Async

        #endregion Async

        #endregion overrides
    }
}
