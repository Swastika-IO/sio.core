using Microsoft.AspNetCore.Mvc;
using Swastika.UI.Base.Extensions;
using System.Collections.Generic;

namespace Swastika.UI.Site.Controllers
{
    [Route("portal")]
    public class PortalController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
