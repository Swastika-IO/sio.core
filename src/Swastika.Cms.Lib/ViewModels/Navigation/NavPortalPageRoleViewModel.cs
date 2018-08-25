// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Data.ViewModels;
using System;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavPortalPageRoleViewModel
        : ViewModelBase<SiocCmsContext, SiocPortalPageRole, NavPortalPageRoleViewModel>
    {
        #region Properties

        #region Model
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("pageId")]
        public int PageId { get; set; }

        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        #endregion

        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("page")]
        public InfoPortalPageViewModel Page { get; set; }
        
        #endregion Views

        #endregion

        public NavPortalPageRoleViewModel(SiocPortalPageRole model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public NavPortalPageRoleViewModel() : base()
        {
        }


        #region overrides

        public override SiocPortalPageRole ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (CreatedDateTime == default(DateTime))
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCategory = InfoPortalPageViewModel.Repository.GetSingleModel(p => p.Id == Id
            , _context: _context, _transaction: _transaction
            );
            if (getCategory.IsSucceed)
            {
                Page = getCategory.Data;
            }
        }

        #endregion overrides
    }
}
