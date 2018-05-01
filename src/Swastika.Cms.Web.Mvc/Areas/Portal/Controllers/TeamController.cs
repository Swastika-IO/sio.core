using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;

namespace Swastika.Cms.Web.Mvc.Areas.Portal.Controllers
{
    [Area("Portal")]
    [Route("{culture}/Portal/Team")]
    public class TeamController : BaseController<TeamController>
    {
        public TeamController(IHostingEnvironment env) : base(env)
        {
        }

        // GET: Portal/team
        [HttpPost, HttpGet]
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}