// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swastika.Cms.Lib;

namespace Swastka.Cms.Web
{
    public partial class Startup
    {
        public const string CONST_ROUTE_DEFAULT_CULTURE = SWCmsConstants.Default.Specificulture;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            services.AddAuthentication("Bearer");
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "apiRoute",
                    template: "api/{culture=" + CONST_ROUTE_DEFAULT_CULTURE + "}/{area:exists}/{controller=Portal}/{action=Index}");
            });
        }
    }
}