// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Dashboard")]
    public class DashboardController : BaseController<DashboardController>
    {
        public DashboardController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> pageLocalizer, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        //[Route("/portal/Dashboard")]
        [HttpGet]
        [Route("{Dashboardize:int?}/{pageIndex:int?}")]
        [Route("Index/{Dashboardize:int?}/{pageIndex:int?}")]
        public IActionResult Index(string keyword, int Dashboardize = 10, int pageIndex = 0)
        {
            return View();
        }
    }
}