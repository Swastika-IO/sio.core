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
using Swashbuckle.AspNetCore.Swagger;

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

            
            Swastika.Identity.Startup.ConfigIdentity(services, Configuration, Configuration.GetConnectionString("CmsConnection"));
            //ConfigIdentity(services, Configuration, Configuration.GetConnectionString("CmsConnection")); //Cms Config

            //ConfigCookieAuth(services, Configuration);
            ConfigJWTToken(services, Configuration);
               



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
                //options.CacheProfiles.Add("Never",
                //    new CacheProfile()
                //    {
                //        Location = ResponseCacheLocation.None,
                //        NoStore = true
                //    });
            });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            ConfigurationSignalR(app);
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
                routes.MapRoute(
                 name: "Product",
                 template: "{culture=vi-vn}/product/{seoName}");

            });
        }
    }
}
