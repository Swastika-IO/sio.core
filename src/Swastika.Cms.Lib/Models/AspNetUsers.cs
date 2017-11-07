using System;
using System.Collections.Generic;

namespace Swastika.IO.Cms.Lib.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public int CountryId { get; set; }
        public string Culture { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public bool? IsActived { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public string NickName { get; set; }
        public string RegisterType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
