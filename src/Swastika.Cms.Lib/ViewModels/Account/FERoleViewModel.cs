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
    public class FERoleViewModel
        : ViewModelBase<SiocCmsAccountContext, AspNetRoles, FERoleViewModel>
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

        public FERoleViewModel() : base()
        {
        }

        public FERoleViewModel(AspNetRoles model, SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
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
        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(FERoleViewModel view, SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
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

            Permissions = RolePortalPageViewModel.Repository.GetModelListBy(p => p.Level == 0
            && (p.SiocPortalPageRole.Any(r => r.RoleId == Id) || Name == "SuperAdmin")
            ).Data;
            foreach (var item in Permissions)
            {
                item.NavPermission = NavPortalPageRoleViewModel.Repository.GetSingleModel(n => n.PageId == item.Id && n.RoleId == Id).Data;

                foreach (var child in item.ChildPages)
                {
                    child.Page.NavPermission = NavPortalPageRoleViewModel.Repository.GetSingleModel(n => n.PageId == child.Page.Id && n.RoleId == Id).Data;
                }
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

        #endregion

    }
}
