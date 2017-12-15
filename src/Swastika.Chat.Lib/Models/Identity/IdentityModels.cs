using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Lib.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUser" />
    public class ApplicationUser : IdentityUser
    {
        //Tinku: Custom User Fields
        #region Custome User Fields

        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public string Department { get; set; }
        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }
        /// <summary>
        /// Gets or sets the join date.
        /// </summary>
        /// <value>
        /// The join date.
        /// </value>
        public DateTime JoinDate{ get; set; }

        #endregion

        /// <summary>
        /// Generates the user identity asynchronous.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="authenticationType">Type of the authentication.</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{ChatRoom.Lib.Models.ApplicationUser}" />
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}