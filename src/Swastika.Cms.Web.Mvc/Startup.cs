// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Identity.Services;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using RewriteRules;

namespace Swastika.Cms.Web.Mvc
{
    public partial class Startup
    {
        public const string CONST_ROUTE_DEFAULT_CULTURE = "en-us";

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
            //ConfigureSignalRServices(services);
            services.AddDbContext<SiocCmsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(Swastika.Cms.Lib.SWCmsConstants.CONST_DEFAULT_CONNECTION)));

            //When View Page Source That changes only the HTML encoder, leaving the JavaScript and URL encoders with their (ASCII) defaults.
            services.Configure<WebEncoderOptions>(options => options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));
            services.Configure<FormOptions>(options => options.MultipartBodyLengthLimit = 100000000);

            //Swastika.Identity.Startup.ConfigIdentity(services, Configuration, "CmsConnection");
            ConfigIdentity(services, Configuration, Swastika.Cms.Lib.SWCmsConstants.CONST_DEFAULT_CONNECTION); //Cms Config

            // SignalR Services

            ConfigCookieAuth(services, Configuration);
            ConfigJWTToken(services, Configuration);

            // Add application services.
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSmsMessageSender>();

            // Add Singleton Configs App Configs (load from db)
            services.AddSingleton<GlobalConfigurationService>();
            services.AddSingleton<GlobalLanguageService>();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddScoped<IViewRenderService, ViewRenderService>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                //options.CacheProfiles.Add("Never",
                //    new CacheProfile()
                //    {
                //        Location = ResponseCacheLocation.None,
                //        NoStore = true
                //    });
            });

            //// Register the Swagger generator, defining one or more Swagger documents
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(option => { option.AllowAnyMethod(); option.AllowAnyOrigin(); option.AllowAnyHeader(); });
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

            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{area:exists}/{controller=Portal}/{action=Index}");
                routes.MapRoute(
                    name: "areaRoute2",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{area:exists}/{controller=Portal}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "apiRoute",
                    template: "api/{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{area:exists}/{controller=Portal}/{action=Index}");
                routes.MapRoute(
                    name: "apiCommonRoute",
                    template: "api/{area:exists}/{controller=Portal}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{controller=InitCms}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Page",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{seoName}");
                routes.MapRoute(
                    name: "File",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/Portal/File");
                routes.MapRoute(
                    name: "Article",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/article/{seoName}");
                routes.MapRoute(
                    name: "Product",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/product/{seoName}");
            });

            using (StreamReader apacheModRewriteStreamReader =
                File.OpenText("ApacheModRewrite.txt"))
            using (StreamReader iisUrlRewriteStreamReader =
                File.OpenText("IISUrlRewrite.xml"))
            {
                var options = new RewriteOptions()
                    .AddRedirect("admin/(.*)", "admin/$1")
                    .AddRewrite(@"^admin/*", "/admin",
                        skipRemainingRules: true)
                    .AddApacheModRewrite(apacheModRewriteStreamReader)
                    .AddIISUrlRewrite(iisUrlRewriteStreamReader)
                    .Add(MethodRules.RedirectXMLRequests)
                    .Add(new RedirectImageRequests(".png", "/png-images"))
                    .Add(new RedirectImageRequests(".jpg", "/jpg-images"));

                app.UseRewriter(options);
            }
        }

        /// <summary>
        ///  REF: https://irensaltali.com/en/asp-net-core-mvc-localization-by-url-routedatarequestcultureprovider/
        /// </summary>
        public class LanguageRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (!values.ContainsKey("culture"))
                    return false;

                var culture = values["culture"].ToString();
                return culture == "en" || culture == "vi";
            }
        }
    }
}