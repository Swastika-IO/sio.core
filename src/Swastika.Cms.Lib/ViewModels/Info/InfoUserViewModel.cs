using System;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using System.Collections.Generic;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels.Account;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoUserViewModel
        : ViewModelBase<SiocCmsContext, SiocCmsUser, InfoUserViewModel>
    {
        #region Properties
        //[JsonProperty("id")]

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
        public List<UserRoleViewModel> UserRoles { get; set; } = new List<UserRoleViewModel>();


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

        public InfoUserViewModel() : base()
        {
        }

        public InfoUserViewModel(SiocCmsUser model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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
            UserRoles = UserRoleViewModel.Repository.GetModelListBy(ur => ur.UserId == Id).Data;
        }

        #endregion

        #region Expands

        #endregion
    }
}
