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

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoPortalPageViewModel
       : ViewModelBase<SiocCmsContext, SiocPortalPage, InfoPortalPageViewModel>
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

        public override Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(InfoPortalPageViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var navPages = _context.SiocPortalPageNavigation.Where(p => p.ParentId == Id || p.Id == Id);
            navPages.ForEachAsync(n => _context.Entry(n).State = EntityState.Deleted);
            var navRoles = _context.SiocPortalPageRole.Where(p => p.PageId == Id);
            navPages.ForEachAsync(n => _context.Entry(n).State = EntityState.Deleted);
            return base.RemoveRelatedModelsAsync(view, _context, _transaction);
        }


        #endregion

    }
}
