using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Account;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using Sio.Cms.Lib.ViewModels.Account;

namespace Sio.Cms.Lib.ViewModels.Account
{
    public class NavUserRoleViewModel
          : ViewModelBase<SioCmsAccountContext, AspNetUserRoles, NavUserRoleViewModel>
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

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("role")]
        public RoleViewModel Role { get; set; }

        #endregion
        #endregion

        #region Contructors

        public NavUserRoleViewModel() : base()
        {
        }

        public NavUserRoleViewModel(AspNetUserRoles model, SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            Role = RoleViewModel.Repository.GetSingleModel(r => r.Id == RoleId, _context, _transaction).Data;
            Description = Role?.Name;
        }
        #endregion

        #region Expands

        #endregion


    }
}
