// Licensed to the siocore Foundation under one or more agreements.
// The siocore Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Sio.Cms.Lib;
using Sio.Cms.Lib.Services;
using System.Text;

namespace Sio.Cms.Web
{
    public partial class Startup
    {
        protected void ConfigRoutes(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{culture=" + SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture) + "}/{area:exists}/{controller=Portal}/{action=Init}");
                routes.MapRoute(
                    name: "alias",
                    template: "{culture=" + SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture) + "}/{seoName}");
                routes.MapRoute(
                   name: "page",
                   template: "{culture=" + SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture) + "}/{seoName}");
                routes.MapRoute(
                    name: "file",
                    template: "{culture=" + SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture) + "}/portal/file");
                routes.MapRoute(
                    name: "article",
                    template: "{culture=" + SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture) + "}/article/{seoName}");
                routes.MapRoute(
                    name: "product",
                    template: @"{culture=" + SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture) + @"}/product/{seoName}");
            });
        }

    }
}
