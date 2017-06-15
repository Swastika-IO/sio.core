using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swastika.Common.Utility;
using Swastika.Infrastructure.CrossCutting.Bus;
using Swastika.Infrastructure.CrossCutting.Identity.Data;
using Swastika.Infrastructure.CrossCutting.Identity.Models;
using Swastika.Infrastructure.CrossCutting.IoC;
using Swastika.UI.Base.Extensions;
using Swastika.UI.Base.Extensions.Web;
using System.IO;
using Webpack;

namespace Swastika.UI.Spa {
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Const.CONST_FILE_APPSETTING, optional: true, reloadOnChange: true)
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

            // Load extensions
            services.LoadExtensions(extensionsFilePath, extensionsFileName);

            // Add Database context
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString(Const.CONST_DEFAULT_CONNECTION)));

            // Add Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.Cookies.ApplicationCookie.AccessDeniedPath =
                Const.CONST_PATH_HOME_ACCESS_DENIED)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add MVC
            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            // Add AutoMapper
            services.AddAutoMapper();

            // Add custom view for extensions
            services.Configure<RazorViewEngineOptions>(options =>
            {
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
            loggerFactory.AddConsole(Configuration.GetSection(Const.CONST_SECTION_LOGGING));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler(Const.CONST_PATH_HOME_ERROR);
            }

            app.UseStaticFiles();
            app.UseIdentity();

            app.UseFacebookAuthentication(new FacebookOptions() {
                AppId = Const.CONST_APPID,
                AppSecret = Const.CONST_APPSECRET
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: Const.CONST_ROUTE_DEFAULT,
                    template: "{controller=Home}/{action=welcome}/{id?}");

                // Ref: https://github.com/aspnet/JavaScriptServices/tree/dev/src/Microsoft.AspNetCore.SpaServices#routing-helper-mapspafallbackroute
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
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
