using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;
using Microsoft.IdentityModel.Tokens;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Web.Mvc.Models.Identity;
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
            ConfigureSignalRServices(services);
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
            //Swastika.Identity.Startup.ConfigIdentity(services, Configuration);
            ConfigIdentity(services, Configuration); //Cms Config

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
                options.LoginPath = "/vi-vn/Portal/Auth/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/vi-vn/Portal/Auth/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
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
                    options.LoginPath = "/vi-vn/Portal/Auth/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                    options.LogoutPath = "/vi-vn/Portal/Auth/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
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
            services.AddSingleton<GlobalConfigurationService>();

            services.AddScoped<IViewRenderService, ViewRenderService>();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            ConfigurationSignalR(app);
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
                routes.MapRoute(
                  name: "apiRoute",
                  template: "api/{culture=vi-vn}/{area:exists}/{controller=Portal}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{culture=vi-vn}/{controller=InitCms}/{action=Index}/{id?}");
                routes.MapRoute(
                  name: "Page",
                  template: "{culture=vi-vn}/{pageName}");
                routes.MapRoute(
                 name: "File",
                 template: "{culture=vi-vn}/Portal/File");
                routes.MapRoute(
                 name: "Article",
                 template: "{culture=vi-vn}/article/{seoName}");

            });
        }
    }
}
