// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Media")]
    public class MediaController : BaseController
    {
        public MediaController(IHostingEnvironment env
            )
            : base(env)
        {
        }

        //[Route("/portal/Media")]
        [HttpGet]
        [Route("{Mediaize:int?}/{pageIndex:int?}")]
        [Route("Index/{Mediaize:int?}/{pageIndex:int?}")]
        public IActionResult Index(string keyword, int Mediaize = 10, int pageIndex = 0)
        {
            return View();
        }
    }
}
