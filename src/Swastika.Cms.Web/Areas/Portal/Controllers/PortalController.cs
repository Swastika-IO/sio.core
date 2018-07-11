using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Swastika.Cms.Web.Areas.Portal.Controllers
{
    public class PortalController : Controller
    {
        [HttpGet]
        [Route("init")]
        [Route("init/{step}")]
        public IActionResult Init()
        {
            return View();
        }
    }
}