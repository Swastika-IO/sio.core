using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Mvc.Controllers;

namespace Swastika.Cms.Web.Mvc.Controllers
{
    
    public class InitCmsController : BaseController<InitCmsController>
    {
        public InitCmsController(IHostingEnvironment env) : base(env)
        {

        }
        [Route("")]
        [Route("{culture}")]
        public IActionResult Index()
        {
            if (!GlobalConfigurationService.Instance.IsInit)
            {
                return RedirectToAction("Init", "Portal", new { culture = "vi-vn" });

            }
            else
            {
                return RedirectToAction("Home", "Home", new { culture = _lang });
            }
        }

    }
}