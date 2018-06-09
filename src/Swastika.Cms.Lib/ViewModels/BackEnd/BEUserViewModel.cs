using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using System.Collections.Generic;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels.Account;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Swastika.Cms.Lib.Models.Account;

namespace Swastika.Cms.Lib.ViewModels.Backend
{
    public class BEUserViewModel
        : ViewModelBase<SiocCmsContext, SiocCmsUser, BEUserViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        #endregion

        #region Views

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }

        [JsonProperty("userRoles")]
        public List<NavUserRoleViewModel> UserRoles { get; set; }


        [JsonProperty("domain")]
        public string Domain => GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/");

        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (Avatar != null && (Avatar.IndexOf("http") == -1 && Avatar[0] != '/'))
                {
                    return SwCmsHelper.GetFullPath(new string[] {
                    Domain,  Avatar
                });
                }
                else
                {
                    return Avatar;
                }
            }
        }
        [JsonProperty("mediaFile")]
        public FileViewModel MediaFile { get; set; } = new FileViewModel();
        #endregion

        #endregion

        #region Contructors

        public BEUserViewModel() : base()
        {
        }

        public BEUserViewModel(SiocCmsUser model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override SiocCmsUser ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (MediaFile.FileStream != null)
            {
                MediaFile.FileFolder = SwCmsHelper.GetFullPath(new[] {
                    SWCmsConstants.Parameters.UploadFolder,
                    DateTime.UtcNow.ToString("MMM-yyyy")
                }); ;
                var isSaved = FileRepository.Instance.SaveWebFile(MediaFile);
                if (isSaved)
                {
                    Avatar = MediaFile.FullPath;
                }
                else
                {
                    IsValid = false;
                }

            }
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            UserRoles = GetRoleNavs();
        }

        #endregion

        #region Expands

        public List<NavUserRoleViewModel> GetRoleNavs()
        {
            using (SiocCmsAccountContext context = new SiocCmsAccountContext())
            {
                var query = context.AspNetRoles
                  .Include(cp => cp.AspNetUserRoles)
                  .Select(p => new NavUserRoleViewModel()
                  {
                      UserId = Id,
                      RoleId = p.Id,
                      Specificulture = Specificulture,
                      Description = p.Name,
                      IsActived = context.AspNetUserRoles.Any(m => m.UserId == Id && m.RoleId == p.Id)
                  });

                return query.OrderBy(m => m.Priority).ToList();
            }
            
        }

        #endregion
    }
}
