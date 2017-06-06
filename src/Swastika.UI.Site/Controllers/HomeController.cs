using Microsoft.AspNetCore.Mvc;
using Swastika.UI.Base.Extensions;
using System.Collections.Generic;

namespace Swastika.UI.Site.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [Route("welcome")]
        [Route("")]
        [Route("/")]
        public IActionResult Index()
        {
            IList<ExtensionInfo> extensionsInfo = ExtensionManager.Extensions;
            return View();
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns></returns>
        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// Accesses the denied.
        /// </summary>
        /// <returns></returns>
        [Route("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
