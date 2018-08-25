// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
    public class RolePortalPageViewModel
       : ViewModelBase<SiocCmsContext, SiocPortalPage, RolePortalPageViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("textKeyword")]
        public string TextKeyword { get; set; }

        [JsonProperty("textDefault")]
        public string TextDefault { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Descriotion { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }

        [JsonProperty("childPages")]
        public List<NavPortalPageViewModel> ChildPages { get; set; } = new List<NavPortalPageViewModel>();

        [JsonProperty("navPermission")]
        public NavPortalPageRoleViewModel NavPermission { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public RolePortalPageViewModel() : base()
        {
        }

        public RolePortalPageViewModel(SiocPortalPage model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getChilds = NavPortalPageViewModel.Repository.GetModelListBy(n => n.ParentId == Id, _context, _transaction);
            if (getChilds.IsSucceed)
            {
                ChildPages = getChilds.Data.OrderBy(c => c.Priority).ToList();
            }            
        }

        #endregion Overrides
    }
}
