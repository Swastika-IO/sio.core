// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using RewriteRules;
using Swashbuckle.AspNetCore.Swagger;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Identity.Services;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Swastika.Cms.Web.Mvc
{
    public partial class Startup
    {
        public const string CONST_ROUTE_DEFAULT_CULTURE = "vi-vn";
        private const string ErrorHandlingPath = "/Home/Error";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ConfigIdentity(services, Configuration, Swastika.Cms.Lib.SWCmsConstants.CONST_DEFAULT_CONNECTION); //Cms Config
            ConfigCookieAuth(services, Configuration);
            ConfigJWTToken(services, Configuration);

            services.AddDbContext<SiocCmsContext>();
            //When View Page Source That changes only the HTML encoder, leaving the JavaScript and URL encoders with their (ASCII) defaults.
            services.Configure<WebEncoderOptions>(options => options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));
            services.Configure<FormOptions>(options => options.MultipartBodyLengthLimit = 100000000);

            // add application services.
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSmsMessageSender>();

            services.AddSingleton<GlobalConfigurationService>();
            GlobalConfigurationService.Instance.RefreshAll();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "AccountOwner API", Version = "v1" });
            });
            services.AddAuthentication("Bearer");

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
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler(errorHandlingPath: ErrorHandlingPath);
                app.UseHsts();
            }
            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin();
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
            });
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swastika API V1");
            });
            using (StreamReader apacheModRewriteStreamReader =
        File.OpenText("ApacheModRewrite.txt"))
            using (StreamReader iisUrlRewriteStreamReader =
                File.OpenText("IISUrlRewrite.xml"))
            {
                var options = new RewriteOptions()
                    .AddRedirect("redirect-rule/(.*)", "redirected/$1")
                    .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2",
                        skipRemainingRules: true)
                    .AddApacheModRewrite(apacheModRewriteStreamReader)
                    .AddIISUrlRewrite(iisUrlRewriteStreamReader)
                    .Add(MethodRules.RedirectXMLRequests);
                    //.Add(new RedirectImageRequests(".png", "/png-images"))
                    //.Add(new RedirectImageRequests(".jpg", "/jpg-images"));

                app.UseRewriter(options);
            }


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{area:exists}/{controller=Portal}/{action=Init}");
                routes.MapRoute(
                    name: "Alias",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{seoName}");
                routes.MapRoute(
                    name: "Page",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/page/{seoName}");
                routes.MapRoute(
                    name: "File",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/portal/file");
                routes.MapRoute(
                    name: "Article",
                    template: "{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/article/{seoName}");
                routes.MapRoute(
                    name: "Product",
                    template: @"{culture=" + CONST_ROUTE_DEFAULT_CULTURE + @"}/product/{seoName}");
            });


            //app.Run(context => context.Response.WriteAsync(
            //    $"Rewritten or Redirected Url: " +
            //    $"{context.Request.Path + context.Request.QueryString}"));
        }
    }
}
