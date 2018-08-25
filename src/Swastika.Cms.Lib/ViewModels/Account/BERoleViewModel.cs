using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Account;
using System.ComponentModel.DataAnnotations;
using Swastika.Domain.Core.ViewModels;
using System.Threading.Tasks;
using Swastika.Cms.Lib.ViewModels.Navigation;
using System.Collections.Generic;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using System.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Microsoft.EntityFrameworkCore;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Cms.Lib.ViewModels.Account
{
    public class BERoleViewModel
        : ViewModelBase<SiocCmsAccountContext, AspNetRoles, BERoleViewModel>
    {
        #region Properties

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("concurrencyStamp")]
        public string ConcurrencyStamp { get; set; }
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("normalizedName")]
        public string NormalizedName { get; set; }

        #region Models

        #endregion

        #region Views

        [JsonProperty("permissions")]
        public List<RolePortalPageViewModel> Permissions { get; set; }

        #endregion

        #endregion

        #region Contructors

        public BERoleViewModel() : base()
        {
        }

        public BERoleViewModel(AspNetRoles model, SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override AspNetRoles ParseModel(SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
            }
            return base.ParseModel(_context, _transaction);
        }
        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(BERoleViewModel view, SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await UserRoleViewModel.Repository.RemoveListModelAsync(ur => ur.RoleId == Id, _context, _transaction);
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result.IsSucceed,
                Errors = result.Errors,
                Exception = result.Exception
            };
        }

        public override void ExpandView(SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {

            Permissions = RolePortalPageViewModel.Repository.GetModelListBy(p => p.Level == 0).Data;
            foreach (var item in Permissions)
            {
                item.NavPermission = NavPortalPageRoleViewModel.Repository.GetSingleModel(n => n.PageId == item.Id && n.RoleId == Id).Data;
                if (item.NavPermission == null)
                {
                    var nav = new SiocPortalPageRole()
                    {
                        PageId = item.Id,
                        RoleId = Id,
                        Status = (int)SWStatus.Preview
                    };
                    item.NavPermission = new NavPortalPageRoleViewModel(nav) { IsActived = false };
                }
                else
                {
                    item.NavPermission.IsActived = true;
                }

                foreach (var child in item.ChildPages)
                {
                    child.Page.NavPermission = NavPortalPageRoleViewModel.Repository.GetSingleModel(n => n.PageId == child.Page.Id && n.RoleId == Id).Data;
                    if (child.Page.NavPermission == null)
                    {
                        var nav = new SiocPortalPageRole()
                        {
                            PageId = item.Id,
                            RoleId = Id,
                            Status = (int)SWStatus.Preview
                        };
                        child.Page.NavPermission = new NavPortalPageRoleViewModel(nav) { IsActived = false };
                    }else
                {
                    item.NavPermission.IsActived = true;
                }
                }
            }
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(AspNetRoles parent, SiocCmsAccountContext _context, IDbContextTransaction _transaction)
        {

            SiocCmsContext context = new SiocCmsContext();
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var item in Permissions)
                {
                    if (result.IsSucceed)
                    {
                        result = await HandlePermission(item, context, transaction);
                    }
                    else
                    {
                        break;
                    }
                }
                if (result.IsSucceed)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                result.IsSucceed = false;
                result.Exception = ex;
                return result;
            }
            finally
            {
                transaction.Dispose();
                context.Dispose();
            }

        }

        #endregion

        #region Expands

        List<NavPortalPageRoleViewModel> GetPermission()
        {
            using (SiocCmsContext context = new SiocCmsContext())
            {
                var transaction = context.Database.BeginTransaction();
                var query = context.SiocPortalPage
                .Include(cp => cp.SiocPortalPageRole)
                .Select(Category =>
                new NavPortalPageRoleViewModel(
                      new SiocPortalPageRole()
                      {
                          RoleId = Id,
                          PageId = Category.Id,
                      }, context, transaction));

                var result = query.ToList();
                result.ForEach(nav =>
                {
                    nav.IsActived = context.SiocPortalPageRole.Any(
                            m => m.PageId == nav.PageId && m.RoleId == Id);
                });
                transaction.Commit();
                return result.OrderBy(m => m.Priority).ToList();
            }
        }

        async Task<RepositoryResponse<bool>> HandlePermission(RolePortalPageViewModel item, SiocCmsContext context, IDbContextTransaction transaction)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };

            if (item.NavPermission.IsActived)
            {
                item.NavPermission.CreatedBy = item.CreatedBy;
                var saveResult = await item.NavPermission.SaveModelAsync(false, context, transaction);
                result.IsSucceed = saveResult.IsSucceed;
                /* skip child nav
                if (result.IsSucceed)
                {
                    foreach (var child in item.ChildPages)
                    {
                        result = await HandlePermission(child.Page, context, transaction);
                        if (!result.IsSucceed)
                        {
                            break;
                        }
                    }
                }
                */
                if (!result.IsSucceed)
                {
                    result.Exception = saveResult.Exception;
                    Errors.AddRange(saveResult.Errors);

                }
            }
            else
            {
                var saveResult = await item.NavPermission.RemoveModelAsync(false, context, transaction);
                /* skip child nav
                result.IsSucceed = saveResult.IsSucceed;
                if (result.IsSucceed)
                {
                    foreach (var child in item.ChildPages)
                    {
                        child.Page.NavPermission.IsActived = false;
                        result = await HandlePermission(child.Page, context, transaction);
                    }
                }
                */
                if (!result.IsSucceed)
                {
                    result.Exception = saveResult.Exception;
                    Errors.AddRange(saveResult.Errors);
                }
            }

            return result;
        }
        #endregion

    }
}
