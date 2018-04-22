// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavCategoryCategoryViewModel
        : ViewModelBase<SiocCmsContext, SiocCategoryCategory, NavCategoryCategoryViewModel>
    {
        public NavCategoryCategoryViewModel(SiocCategoryCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public NavCategoryCategoryViewModel() : base()
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parentId")]
        public int ParentId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #region Views

        public InfoCategoryViewModel Category { get; set; }
        public InfoCategoryViewModel Parent { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCategory = InfoCategoryViewModel.Repository.GetSingleModel(p => p.Id == Id && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getCategory.IsSucceed)
            {
                Category = getCategory.Data;
            }
            var getParent = InfoCategoryViewModel.Repository.GetSingleModel(p => p.Id == ParentId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getParent.IsSucceed)
            {
                Parent = getCategory.Data;
            }
        }

        #endregion overrides
    }
}
