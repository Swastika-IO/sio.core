using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;
using Microsoft.IdentityModel.Tokens;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Web.Mvc.Models.Identity;
using Swastika.Identity.Data;
using Swastika.Identity.Models;
using Swastika.Identity.Services;

namespace Swastika.Cms.Web.Mvc
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            
            services.AddDbContext<SiocCmsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CmsConnection")));

            //When View Page Source That changes only the HTML encoder, leaving the JavaScript and URL encoders with their (ASCII) defaults.
            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 100000000;
            });

            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            Swastika.Identity.Startup.ConfigIdentity(services, Configuration);
            
            //PasswordOptions pOpt = new PasswordOptions()
            //{
            //    RequireDigit = false,
            //    RequiredLength = 6,
            //    RequireLowercase = false,
            //    RequireNonAlphanumeric = false,
            //    RequireUppercase = false
            //};

            //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //{
            //    options.Password = pOpt;

            //})
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders()
            //    .AddUserManager<AuthRepository>();



            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AddEditUser", policy =>
            //    {
            //        policy.RequireClaim("Add User", "Add User");
            //        policy.RequireClaim("Edit User", "Edit User");
            //    });
            //    options.AddPolicy("DeleteUser", policy => policy.RequireClaim("Delete User", "Delete User"));
            //});


            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/vi-vn/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/vi-vn/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            var secretKey = Configuration.GetSection("JWTSettings:SecretKey").Value;
            var issuer = Configuration.GetSection("JWTSettings:Issuer").Value;
            var audience = Configuration.GetSection("JWTSettings:Audience").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = issuer,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = audience
            };

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                options =>
                {                    
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Expiration = TimeSpan.FromDays(150);
                    options.LoginPath = "/vi-vn/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                    options.LogoutPath = "/vi-vn/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                    options.AccessDeniedPath = "/"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                    options.SlidingExpiration = true;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = tokenValidationParameters;
                });
           
            

            // Add application services.
            services.AddTransient<Swastika.Identity.Services.IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Add Singleton Configs App Configs (load from db)
            services.AddSingleton<ApplicationConfigService>();

            services.AddScoped<IViewRenderService, ViewRenderService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                //app.UseExceptionHandler("/");
                app.UseDeveloperExceptionPage();
            }

            //var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            //app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();
            app.UseAuthentication();
            

            //app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{culture=vi-vn}/{area:exists}/{controller=Portal}/{action=Index}");
                routes.MapRoute(
                    name: "areaRoute2",
                    template: "{culture=vi-vn}/{area:exists}/{controller=Portal}/{action=Index}/{id?}");
                //routes.MapRoute(
                //  name: "apiRoute",
                //  template: "api/{culture=vi-vn}/{area:exists}/{controller=Portal}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{culture=vi-vn}/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
