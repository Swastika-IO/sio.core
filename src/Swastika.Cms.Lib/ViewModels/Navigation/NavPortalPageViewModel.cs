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
    public class NavPortalPageViewModel
        : ViewModelBase<SiocCmsContext, SiocPortalPageNavigation, NavPortalPageViewModel>
    {
        public NavPortalPageViewModel(SiocPortalPageNavigation model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public NavPortalPageViewModel() : base()
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

        [JsonProperty("page")]
        public InfoPortalPageViewModel Page { get; set; }

        [JsonProperty("parent")]
        public InfoPortalPageViewModel Parent { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCategory = InfoPortalPageViewModel.Repository.GetSingleModel(p => p.Id == Id
                , _context: _context, _transaction: _transaction
            );
            if (getCategory.IsSucceed)
            {
                Page = getCategory.Data;
            }
            var getParent = InfoPortalPageViewModel.Repository.GetSingleModel(p => p.Id == ParentId
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
