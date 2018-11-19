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
    public class ReadViewModel : ViewModelBase<SioCmsAccountContext, AspNetRoles, ReadViewModel>
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
        public List<SioPortalPages.ReadRolePermissionViewModel> Permissions { get; set; }

        #endregion

        #endregion

        #region Contructors

        public ReadViewModel() : base()
        {
        }

        public ReadViewModel(AspNetRoles model, SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
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
        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(ReadViewModel view, SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
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

            Permissions = SioPortalPages.ReadRolePermissionViewModel.Repository.GetModelListBy(p => p.Level == 0
            && (p.SioPortalPageRole.Any(r => r.RoleId == Id) || Name == "SuperAdmin")
            ).Data;
            foreach (var item in Permissions)
            {
                item.NavPermission = SioPortalPageRoles.ReadViewModel.Repository.GetSingleModel(n => n.PageId == item.Id && n.RoleId == Id).Data;

                foreach (var child in item.ChildPages)
                {
                    child.Page.NavPermission =  SioPortalPageRoles.ReadViewModel.Repository.GetSingleModel(n => n.PageId == child.Page.Id && n.RoleId == Id).Data;
                }
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
                new  SioPortalPageRoles.ReadViewModel(
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

        #endregion

    }
}
