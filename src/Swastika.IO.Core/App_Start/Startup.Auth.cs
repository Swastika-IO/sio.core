using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swastika.Identity.Data;
using Swastika.Identity.Models;
using Swastika.Identity.Services;
using Swastika.IO.Cms.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swastika.IO.Admin
{
    public partial class Startup
    {
        public void ConfigureApiServices(IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.WithExposedHeaders("WWW-Authenticate");
                });
            });
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureAuth(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = SWCmsConstants.AuthConfiguration.ConnectionString;
            string apiEndPoint = SWCmsConstants.AuthConfiguration.ApiEndPoint;

            string fbId = SWCmsConstants.AuthConfiguration.FacebookId;
            string fbSecret = SWCmsConstants.AuthConfiguration.FacebookSecret;

            string ggId = SWCmsConstants.AuthConfiguration.GoogleId;
            string ggSecret = SWCmsConstants.AuthConfiguration.GoogleSecret;

            string msId = SWCmsConstants.AuthConfiguration.MicrosoftId;
            string msSecret = SWCmsConstants.AuthConfiguration.MicrosoftSecret;

            string twConsumerKey = SWCmsConstants.AuthConfiguration.TwitterKey;
            string twConsumerSecret = SWCmsConstants.AuthConfiguration.TwitterSecret;

            string openIdAuthority = SWCmsConstants.AuthConfiguration.OpenIdAuthority;
            string openIdClientId = SWCmsConstants.AuthConfiguration.OpenIdClientId;

            int authCookieExpiration = SWCmsConstants.AuthConfiguration.AuthCookieExpiration;
            string authCookieLoginPath = SWCmsConstants.AuthConfiguration.AuthCookieLoginPath;
            string authCookieLogoutPath = SWCmsConstants.AuthConfiguration.AuthCookieLogoutPath;
            string authCookieAccessDeniedPath = SWCmsConstants.AuthConfiguration.AuthCookieAccessDeniedPath;

            string authTokenIssuer = SWCmsConstants.AuthConfiguration.AuthTokenIssuer;
            string authTokenKey = SWCmsConstants.AuthConfiguration.AuthTokenKey;

            services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(authCookieExpiration);
                options.LoginPath = authCookieLoginPath; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = authCookieLogoutPath; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = authCookieAccessDeniedPath; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Audience = apiEndPoint;
                    options.Authority = apiEndPoint;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = authTokenIssuer,
                        ValidAudience = authTokenIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authTokenKey))
                    };
                })
                .AddCookie()
               // Auth with OpenId
               //.AddOpenIdConnect(options =>
               //{
               //    options.Authority = openIdAuthority;
               //    options.ClientId = openIdClientId;
               //})
               // Auth with Facebook
               //.AddFacebook(options =>
               //{
               //    options.AppId = fbId;
               //    options.AppSecret = fbSecret;
               //})
               // Auth with Google
               //.AddGoogle(options =>
               //{
               //    options.ClientId = ggId;
               //    options.ClientSecret = ggSecret;
               //})
               // Auth with Microsoft
               //.AddMicrosoftAccount(options =>
               //{
               //    options.ClientId = msId;
               //    options.ClientSecret = msSecret;
               //})
               // Auth with Twitter
               //.AddTwitter(options =>
               //{
               //    options.ConsumerKey = twConsumerKey;
               //    options.ConsumerSecret = twConsumerSecret;
               //})
               ;

            // Add application services.
            //services.AddTransient<IEmailSender, EmailSender>();

        }
    }
}
