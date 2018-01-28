using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swastika.Cms.Lib.Models.Account;
using Swastika.Identity.Models;

namespace Swastika.Cms.Web.Mvc
{
    public partial class Startup
    {
        public static void ConfigIdentity(IServiceCollection services, IConfigurationRoot Configuration, string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Swastika.Cms.Db;Trusted_Connection=True;MultipleActiveResultSets=true";
            }

            services.AddDbContext<SiocCmsAccountContext>(options =>
                options.UseSqlServer(connectionString));

            PasswordOptions pOpt = new PasswordOptions()
            {
                RequireDigit = false,
                RequiredLength = 6,
                RequireLowercase = false,
                RequireNonAlphanumeric = false,
                RequireUppercase = false
            };

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password = pOpt;

            })
                .AddEntityFrameworkStores<SiocCmsAccountContext>()
                .AddDefaultTokenProviders()
                .AddUserManager<UserManager<ApplicationUser>>();



            services.AddAuthorization(options =>
            {
                options.AddPolicy("AddEditUser", policy =>
                {
                    policy.RequireClaim("Add User");
                    policy.RequireClaim("Edit User");
                });
                options.AddPolicy("DeleteUser", policy => policy.RequireClaim("Delete User"));
            })
             ;

        }

    }
}
