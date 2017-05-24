using System.IO;
using Swastika.Infrastructure.CrossCutting.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Swastika.Infrastructure.CrossCutting.Identity.Models;
using AutoMapper;
using Swastika.Infrastructure.CrossCutting.Bus;
using Swastika.Infrastructure.CrossCutting.Identity.Authorization;
using Swastika.Infrastructure.CrossCutting.IoC;

namespace Swastika.UI.Site
{
    public class Startup
    {
        private const string CONST_DEFAULT_CONNECTION = "DefaultConnection";
        private const string CONST_FILE_APPSETTING = "appsettings.json";
        private const string CONST_AUTH_POLICY_CANWRITECUSTOMERDATA = "CanWriteCustomerData";
        private const string CONST_AUTH_POLICY_CANREMOVECUSTOMERDATA = "CanRemoveCustomerData";
        private const string CONST_PATH_HOME_ACCESS_DENIED = "/home/access-denied";
        private const string CONST_PATH_HOME_ERROR = "/Home/Error";
        private const string CONST_SECTION_LOGGING = "Logging";
        private const string CONST_ROUTE_DEFAULT = "default";
        private const string CONST_APPID = "SetYourDataHere";
        private const string CONST_APPSECRET = "SetYourDataHere";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(CONST_FILE_APPSETTING, optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(CONST_DEFAULT_CONNECTION)));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    options.Cookies.ApplicationCookie.AccessDeniedPath = CONST_PATH_HOME_ACCESS_DENIED)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddAutoMapper();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(CONST_AUTH_POLICY_CANWRITECUSTOMERDATA, policy => policy.Requirements.Add(new ClaimRequirement("Customers","Write")));
                options.AddPolicy(CONST_AUTH_POLICY_CANREMOVECUSTOMERDATA, policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
            });
            
            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app,
                                      IHostingEnvironment env,
                                      ILoggerFactory loggerFactory,
                                      IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole(Configuration.GetSection(CONST_SECTION_LOGGING));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler(CONST_PATH_HOME_ERROR);
            }

            app.UseStaticFiles();
            app.UseIdentity();

            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AppId = CONST_APPID,
                AppSecret = CONST_APPSECRET
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: CONST_ROUTE_DEFAULT,
                    template: "{controller=Home}/{action=welcome}/{id?}");
            });

            // Setting the IContainer interface for use like service locator for events.
            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
            
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            SimpleInjectorBootStrapper.RegisterServices(services);
        }
    }
}
