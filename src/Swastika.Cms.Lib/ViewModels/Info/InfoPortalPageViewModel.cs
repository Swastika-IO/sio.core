// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoPortalPageViewModel
       : ViewModelBase<SiocCmsContext, SiocPortalPage, InfoPortalPageViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("parentId")]
        public int? ParentId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("routeAction")]
        public string RouteAction { get; set; }
        [JsonProperty("routeName")]
        public string RouteName { get; set; }
        [JsonProperty("routeValue")]
        public string RouteValue { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        #endregion

        #region Views

        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }
        
        [JsonProperty("childs")]
        public List<InfoPortalPageViewModel> Childs { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public InfoPortalPageViewModel() : base()
        {
        }

        public InfoPortalPageViewModel(SiocPortalPage model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getChilds = Repository.GetModelListBy
                (p => p.SiocPortalPageNavigationIdNavigation.Any(c => c.ParentId == Id
                )
                );
            if (getChilds.IsSucceed)
            {
                Childs = getChilds.Data;
            }
        }

        #endregion Overrides
    }
}
