using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Account;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;


namespace Sio.Cms.Lib.ViewModels.Account.SioRoles
{
    public class UpdateViewModel : ViewModelBase<SioCmsAccountContext, AspNetRoles, UpdateViewModel>
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
        public List<SioPortalPages.UpdateRolePermissionViewModel> Permissions { get; set; }

        #endregion

        #endregion

        #region Contructors

        public UpdateViewModel() : base()
        {
        }

        public UpdateViewModel(AspNetRoles model, SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override AspNetRoles ParseModel(SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
            }
            return base.ParseModel(_context, _transaction);
        }
        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(UpdateViewModel view, SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await UserRoleViewModel.Repository.RemoveListModelAsync(ur => ur.RoleId == Id, _context, _transaction);
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result.IsSucceed,
                Errors = result.Errors,
                Exception = result.Exception
            };
        }

        public override void ExpandView(SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {

            Permissions = SioPortalPages.UpdateRolePermissionViewModel.Repository.GetModelListBy(p => p.Level == 0).Data;
            foreach (var item in Permissions)
            {
                item.NavPermission = SioPortalPageRoles.ReadViewModel.Repository.GetSingleModel(n => n.PageId == item.Id && n.RoleId == Id).Data;
                if (item.NavPermission == null)
                {
                    var nav = new SioPortalPageRole()
                    {
                        PageId = item.Id,
                        RoleId = Id,
                        Status = (int)SioContentStatus.Published
                    };
                    item.NavPermission = new SioPortalPageRoles.ReadViewModel(nav) { IsActived = false };
                }
                else
                {
                    item.NavPermission.IsActived = true;
                }

                foreach (var child in item.ChildPages)
                {
                    child.Page.NavPermission = SioPortalPageRoles.ReadViewModel.Repository.GetSingleModel(n => n.PageId == child.Page.Id && n.RoleId == Id).Data;
                    if (child.Page.NavPermission == null)
                    {
                        var nav = new SioPortalPageRole()
                        {
                            PageId = child.Page.Id,
                            RoleId = Id,
                            Status = (int)SioContentStatus.Published
                        };
                        child.Page.NavPermission = new SioPortalPageRoles.ReadViewModel(nav) { IsActived = false };
                    }
                    else
                    {
                        child.Page.NavPermission.IsActived = true;
                    }
                }
            }
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(AspNetRoles parent, SioCmsAccountContext _context, IDbContextTransaction _transaction)
        {

            SioCmsContext context = new SioCmsContext();
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

        List<SioPortalPageRoles.ReadViewModel> GetPermission()
        {
            using (SioCmsContext context = new SioCmsContext())
            {
                var transaction = context.Database.BeginTransaction();
                var query = context.SioPortalPage
                .Include(cp => cp.SioPortalPageRole)
                .Select(Category =>
                new SioPortalPageRoles.ReadViewModel(
                      new SioPortalPageRole()
                      {
                          RoleId = Id,
                          PageId = Category.Id,
                      }, context, transaction));

                var result = query.ToList();
                result.ForEach(nav =>
                {
                    nav.IsActived = context.SioPortalPageRole.Any(
                            m => m.PageId == nav.PageId && m.RoleId == Id);
                });
                transaction.Commit();
                return result.OrderBy(m => m.Priority).ToList();
            }
        }

        async Task<RepositoryResponse<bool>> HandlePermission(SioPortalPages.UpdateRolePermissionViewModel item, SioCmsContext context, IDbContextTransaction transaction)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };

            if (item.NavPermission.IsActived)
            {
                item.NavPermission.CreatedBy = item.CreatedBy;
                var saveResult = await item.NavPermission.SaveModelAsync(false, context, transaction);
                result.IsSucceed = saveResult.IsSucceed;
                /* skip child nav*/
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

                if (!result.IsSucceed)
                {
                    result.Exception = saveResult.Exception;
                    Errors.AddRange(saveResult.Errors);

                }
            }
            else
            {
                var saveResult = await item.NavPermission.RemoveModelAsync(false, context, transaction);
                /* skip child nav */
                result.IsSucceed = saveResult.IsSucceed;
                if (result.IsSucceed)
                {
                    foreach (var child in item.ChildPages)
                    {
                        child.Page.NavPermission.IsActived = false;
                        result = await HandlePermission(child.Page, context, transaction);
                    }
                }

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
