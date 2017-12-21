using Swastika.Infrastructure.Data.ViewModels;
using System;
using Newtonsoft.Json;
using ChatRoom.Lib.Helpers;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.IO.Common.Helper;
using Swastika.Messenger.Lib.Models;

namespace ChatRoom.Lib.ViewModels.Chat
{
    public class AccountViewModel: ViewModelBase<ChatContext, AspNetUsers, AccountViewModel>
    {
        public AccountViewModel(AspNetUsers model, ChatContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Avatar) && Avatar.IndexOf("http") == -1)
                {
                    return CommonHelper.GetFullPath(new string[] {
                    ChatConstants.Domain,  Avatar
                });
                }
                else
                {
                    return !string.IsNullOrEmpty(Avatar) ? Avatar : ChatConstants.DefaultAvatar;
                }

            }
            set
            {
                Avatar = value;
            }
        }
        [JsonIgnore]
        public string Avatar { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
        [JsonProperty("joinDate")]
        public System.DateTime JoinDate { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("emailConfirmed")]
        public bool EmailConfirmed { get; set; }
        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }
        [JsonProperty("securityStamp")]
        public string SecurityStamp { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }
        [JsonProperty("twoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }
        [JsonProperty("lockoutEndDateUtc")]
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }
        [JsonProperty("accessFailedCount")]
        public int AccessFailedCount { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}
