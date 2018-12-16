using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioPortalPages
{
    public class UpdateViewModel
       : ViewModelBase<SioCmsContext, SioPortalPage, UpdateViewModel>
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

        [JsonProperty("status")]
        public SioContentStatus Status { get; set; }
        #endregion Models

        #region Views

        [JsonProperty("positionNavs")]
        public List<SioPortalPagePositions.ReadViewModel> PositionNavs { get; set; }

        [JsonProperty("childNavs")]
        public List<SioPortalPagePortalPages.UpdateViewModel> ChildNavs { get; set; }

        [JsonProperty("parentNavs")]
        public List<SioPortalPagePortalPages.UpdateViewModel> ParentNavs { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public UpdateViewModel() : base()
        {
        }

        public UpdateViewModel(SioPortalPage model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override SioPortalPage ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                Id = UpdateViewModel.Repository.Max(c => c.Id, _context, _transaction).Data + 1;
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

            if (ChildNavs != null)
            {
                ChildNavs.Where(c => c.IsActived).ToList().ForEach(c => c.Page.Level = Level + 1);
            }

            return base.ParseModel(_context, _transaction);
        }
        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {

            this.ParentNavs = GetParentNavs(_context, _transaction);
            this.ChildNavs = GetChildNavs(_context, _transaction);
            this.PositionNavs = GetPositionNavs(_context, _transaction);
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioPortalPage parent, SioCmsContext _context, IDbContextTransaction _transaction)
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
                        var saveResult = await item.SaveModelAsync(true, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(true, _context, _transaction);
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
                        var saveResult = await item.SaveModelAsync(true, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(true, _context, _transaction);
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
        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(UpdateViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };

            await _context.SioPortalPagePosition.Where(p => p.PortalPageId == Id).ForEachAsync(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var navs = _context.SioPortalPageNavigation.Where(p => p.Id == Id || p.ParentId == Id);
            foreach (var item in navs)
            {
                _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                if (item.ParentId == Id)
                {
                    _context.Entry(_context.SioPortalPage.Single(sub => sub.Id == item.Id)).State = EntityState.Deleted;
                }
            }
            await _context.SaveChangesAsync();
            return result;
        }
        #endregion Overrides

        #region Expands

        public List<SioPortalPagePortalPages.UpdateViewModel> GetParentNavs(SioCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SioPortalPage
                .Include(cp => cp.SioPortalPageNavigationParent)
                .Where(PortalPage => PortalPage.Id != Id && PortalPage.Level == 0)
                .Select(PortalPage =>
                    new SioPortalPagePortalPages.UpdateViewModel()
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
                nav.IsActived = context.SioPortalPageNavigation.Any(
                        m => m.ParentId == nav.ParentId && m.Id == Id);
            });
            return result.OrderBy(m => m.Priority).ToList();
        }

        public List<SioPortalPagePortalPages.UpdateViewModel> GetChildNavs(SioCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SioPortalPage
                .Include(cp => cp.SioPortalPageNavigationParent)
                .Where(PortalPage => PortalPage.Id != Id)
                .Select(PortalPage =>
                new SioPortalPagePortalPages.UpdateViewModel(
                      new SioPortalPageNavigation()
                      {
                          Id = PortalPage.Id,
                          ParentId = Id,
                          Description = PortalPage.TextDefault,
                      }, context, transaction));

            var result = query.ToList();
            result.ForEach(nav =>
            {
                var currentNav = context.SioPortalPageNavigation.FirstOrDefault(
                        m => m.ParentId == Id && m.Id == nav.Id);
                nav.Priority = currentNav?.Priority ?? 0;
                nav.IsActived = currentNav != null;
            });
            return result.OrderBy(m => m.Priority).ToList();
        }

        public List<SioPortalPagePositions.ReadViewModel> GetPositionNavs(SioCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SioPosition
                  .Include(cp => cp.SioPortalPagePosition)
                  .Select(p => new SioPortalPagePositions.ReadViewModel()
                  {
                      PortalPageId = Id,
                      PositionId = p.Id,
                      Specificulture = Specificulture,
                      Description = p.Description,
                      IsActived = context.SioPortalPagePosition.Count(m => m.PortalPageId == Id && m.PositionId == p.Id) > 0
                  });

            return query.OrderBy(m => m.Priority).ToList();
        }


        #endregion
    }
}
