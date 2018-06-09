using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Cms.Lib.ViewModels.Account
{
    public class UserRoleViewModel
        : ViewModelBase<SiocCmsAccountContext, AspNetUserRoles, UserRoleViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("roleId")]
        public string RoleId { get; set; }
        [JsonProperty("applicationUserId")]
        public string ApplicationUserId { get; set; }
        #endregion

        #region Views

        [JsonProperty("role")]
        public RoleViewModel Role { get; set; }

        #endregion
        #endregion

        #region Contructors

        public UserRoleViewModel() : base()
        {
        }

        public UserRoleViewModel(AspNetUserRoles model, SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            Role = RoleViewModel.Repository.GetSingleModel(r => r.Id == RoleId, _context, _transaction).Data;
        }
        #endregion

        #region Expands

        #endregion

    }
}
