using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Swastika.Extensions.Blog.Web.Controllers
{
    public class BlogPortalController : Controller
    {
        [Route("portal/blog")]
        public IActionResult Index()
        {
            return View();
        }
    }
}