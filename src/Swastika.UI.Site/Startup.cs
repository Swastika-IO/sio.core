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
using Swastika.UI.Base.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using Swastika.UI.Base.Extensions.Web;

namespace Swastika.UI.Site
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The constant default connection
        /// </summary>
        private const string CONST_DEFAULT_CONNECTION = "DefaultConnection";
        /// <summary>
        /// The constant file appsetting
        /// </summary>
        private const string CONST_FILE_APPSETTING = "appsettings.json";
        /// <summary>
        /// The constant authentication policy canwritecustomerdata
        /// </summary>
        private const string CONST_AUTH_POLICY_CANWRITECUSTOMERDATA = "CanWriteCustomerData";
        /// <summary>
        /// The constant authentication policy canremovecustomerdata
        /// </summary>
        private const string CONST_AUTH_POLICY_CANREMOVECUSTOMERDATA = "CanRemoveCustomerData";
        /// <summary>
        /// The constant path home access denied
        /// </summary>
        private const string CONST_PATH_HOME_ACCESS_DENIED = "/home/access-denied";
        /// <summary>
        /// The constant path home error
        /// </summary>
        private const string CONST_PATH_HOME_ERROR = "/Home/Error";
        /// <summary>
        /// The constant section logging
        /// </summary>
        private const string CONST_SECTION_LOGGING = "Logging";
        /// <summary>
        /// The constant route default
        /// </summary>
        private const string CONST_ROUTE_DEFAULT = "default";
        /// <summary>
        /// The constant appid
        /// </summary>
        private const string CONST_APPID = "SetYourDataHere";
        /// <summary>
        /// The constant appsecret
        /// </summary>
        private const string CONST_APPSECRET = "SetYourDataHere";

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
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

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Load all extensions to services
            string extensionsFilePath = Configuration.GetSection("Extensions:Path").Value;
            string extensionsFileName = Configuration.GetSection("Extensions:FileName").Value;
            services.LoadExtensions(extensionsFilePath, extensionsFileName);

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

            // Add custom view for extensions
            services.Configure<RazorViewEngineOptions>(
                options => {
                    options.ViewLocationExpanders.Add(new ViewLocationExpander());
                });

            services.AddMvcToExtensions(ExtensionManager.Extensions);

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="accessor">The accessor.</param>
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

        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            SimpleInjectorBootStrapper.RegisterServices(services);
        }
    }
}
