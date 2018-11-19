using Microsoft.EntityFrameworkCore.Storage;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using Sio.Cms.Lib.Models.Account;

namespace Sio.Cms.Lib.ViewModels.Account
{
    public class UserRoleViewModel
        : ViewModelBase<SioCmsAccountContext, AspNetUserRoles, UserRoleViewModel>
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

        public UserRoleViewModel(AspNetUserRoles model, SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SioCmsAccountContext _context = null, IDbContextTransaction _transaction = null)
        {
            Role = RoleViewModel.Repository.GetSingleModel(r => r.Id == RoleId, _context, _transaction).Data;
        }
        #endregion

        #region Expands

        #endregion

    }
}
