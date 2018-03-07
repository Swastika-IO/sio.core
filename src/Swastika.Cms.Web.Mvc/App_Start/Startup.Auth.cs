// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Account;
using Swastika.Identity.Data;
using Swastika.Identity.Models;
using System;
using System.Text;

namespace Swastika.Cms.Web.Mvc
{
    public partial class Startup
    {
        public static void ConfigIdentity(IServiceCollection services, IConfigurationRoot Configuration, string connectionName)
        {
            string connectionString = Configuration.GetConnectionString(connectionName);
            if (string.IsNullOrEmpty(connectionString))
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

        public static void ConfigJWTToken(IServiceCollection services, IConfigurationRoot Configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters =
                             new TokenValidationParameters
                             {
                                 ValidateIssuer = false,
                                 ValidateAudience = false,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,

                                 ValidIssuer = SWCmsConstants.JWTSettings.ISSUER,
                                 ValidAudience = SWCmsConstants.JWTSettings.AUDIENCE,
                                 IssuerSigningKey =
                                  JwtSecurityKey.Create(SWCmsConstants.JWTSettings.SECRET_KEY)
                             };
                        //options.Events = new JwtBearerEvents
                        //{
                        //    OnAuthenticationFailed = context =>
                        //    {
                        //        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                        //        return Task.CompletedTask;
                        //    },
                        //    OnTokenValidated = context =>
                        //    {
                        //        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                        //        return Task.CompletedTask;
                        //    }
                        //};
                    });
        }

        public static void ConfigCookieAuth(IServiceCollection services, IConfigurationRoot Configuration)
        {
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/" + CONST_ROUTE_DEFAULT_CULTURE + "/Portal/Auth/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/" + CONST_ROUTE_DEFAULT_CULTURE + "/Portal/Auth/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Expiration = TimeSpan.FromDays(150);
                    options.LoginPath = "/" + CONST_ROUTE_DEFAULT_CULTURE + "/Portal/Auth/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                    options.LogoutPath = "/" + CONST_ROUTE_DEFAULT_CULTURE + "/Portal/Auth/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                    options.AccessDeniedPath = "/"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                    options.SlidingExpiration = true;
                });
        }

        public static class JwtSecurityKey
        {
            public static SymmetricSecurityKey Create(string secret)
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            }
        }
    }
}