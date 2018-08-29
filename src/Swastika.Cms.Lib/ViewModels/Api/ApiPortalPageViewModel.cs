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
    public class ApiPortalPageViewModel
       : ViewModelBase<SiocCmsContext, SiocPortalPage, ApiPortalPageViewModel>
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

        [JsonProperty("positionNavs")]
        public List<NavPortalPagePositionViewModel> PositionNavs { get; set; }

        [JsonProperty("childNavs")]
        public List<NavPortalPageViewModel> ChildNavs { get; set; }

        [JsonProperty("parentNavs")]
        public List<NavPortalPageViewModel> ParentNavs { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public ApiPortalPageViewModel() : base()
        {
        }

        public ApiPortalPageViewModel(SiocPortalPage model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override SiocPortalPage ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                Id = ApiPortalPageViewModel.Repository.Max(c => c.Id, _context, _transaction).Data + 1;
                CreatedDateTime = DateTime.UtcNow;
            }
            var navParent = ParentNavs?.FirstOrDefault(p => p.IsActived);

            if (navParent != null)
            {
                Level = navParent.Level + 1;
            }
            else
            {
                Level = 0;
            }
            return base.ParseModel(_context, _transaction);
        }
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {

            this.ParentNavs = GetParentNavs(_context, _transaction);
            this.ChildNavs = GetChildNavs(_context, _transaction);
            this.PositionNavs = GetPositionNavs(_context, _transaction);
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocPortalPage parent, SiocCmsContext _context, IDbContextTransaction _transaction)
        {
            var result = new RepositoryResponse<bool> { IsSucceed = true };
            if (result.IsSucceed)
            {
                foreach (var item in PositionNavs)
                {
                    item.PortalPageId = parent.Id;
                    if (item.IsActived)
                    {
                        var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in ParentNavs)
                {
                    item.Id = parent.Id;
                    if (item.IsActived)
                    {
                        var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in ChildNavs)
                {
                    item.ParentId = parent.Id;
                    if (item.IsActived)
                    {
                        var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }
            return result;
        }
        #endregion Overrides

        #region Expands

        public List<NavPortalPageViewModel> GetParentNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SiocPortalPage
                .Include(cp => cp.SiocPortalPageNavigationParent)
                .Where(PortalPage => PortalPage.Id != Id)
                .Select(PortalPage =>
                    new NavPortalPageViewModel()
                    {
                        Id = Id,
                        ParentId = PortalPage.Id,
                        Description = PortalPage.TextDefault,
                        Level = PortalPage.Level
                    }
                );

            var result = query.ToList();
            result.ForEach(nav =>
            {
                nav.IsActived = context.SiocPortalPageNavigation.Any(
                        m => m.ParentId == nav.ParentId && m.Id == Id);
            });
            return result.OrderBy(m => m.Priority).ToList();
        }

        public List<NavPortalPageViewModel> GetChildNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SiocPortalPage
                .Include(cp => cp.SiocPortalPageNavigationParent)
                .Where(PortalPage => PortalPage.Id != Id)
                .Select(PortalPage =>
                new NavPortalPageViewModel(
                      new SiocPortalPageNavigation()
                      {
                          Id = PortalPage.Id,
                          ParentId = Id,
                          Description = PortalPage.TextDefault,
                      }, context, transaction));

            var result = query.ToList();
            result.ForEach(nav =>
            {
                var currentNav = context.SiocPortalPageNavigation.FirstOrDefault(
                        m => m.ParentId == Id && m.Id == nav.Id);
                nav.Priority = currentNav?.Priority;
                nav.IsActived = currentNav != null;
            });
            return result.OrderBy(m => m.Priority).ToList();
        }

        public List<NavPortalPagePositionViewModel> GetPositionNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SiocPosition
                  .Include(cp => cp.SiocPortalPagePosition)
                  .Select(p => new NavPortalPagePositionViewModel()
                  {
                      PortalPageId = Id,
                      PositionId = p.Id,
                      Specificulture = Specificulture,
                      Description = p.Description,
                      IsActived = context.SiocPortalPagePosition.Count(m => m.PortalPageId == Id && m.PositionId == p.Id) > 0
                  });

            return query.OrderBy(m => m.Priority).ToList();
        }


        #endregion
    }
}
