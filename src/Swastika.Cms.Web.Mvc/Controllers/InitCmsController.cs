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
        [HttpGet]
        [Route("")]
        [Route("{culture}")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(GlobalConfigurationService.Instance.GetConfigConnectionKey()))
            {                
                return RedirectToAction("Init", "Portal", new { culture = "vi-vn" });

            }
            else
            {
                GlobalConfigurationService.Instance.IsInit = true;
                return RedirectToAction("", "Home", new { culture = _lang });
            }
        }

    }
}