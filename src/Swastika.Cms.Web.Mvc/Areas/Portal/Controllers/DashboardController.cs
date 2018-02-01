using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.Models.Cms;

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
        public async Task<IActionResult> Index(string keyword, int Dashboardize = 10, int pageIndex = 0)
        {
            
            return View();
        }
        
    }
}
