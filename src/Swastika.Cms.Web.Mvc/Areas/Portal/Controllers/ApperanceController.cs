using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Apperance")]
    public class ApperanceController : BaseController<ApperanceController>
    {
        public ApperanceController(IHostingEnvironment env
            //, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        [Route("/portal/apperance")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("/portal/apperance/menus")]
        public IActionResult Menus()
        {
            return View();
        }

        [Route("/portal/apperance/themes")]
        public IActionResult Themes()
        {
            return View();
        }

        [Route("")]
        [Route("templates")]
        [Route("templates/{folder}")]
        public IActionResult Templates(string folder)
        {
            folder = folder ?? SWCmsConstants.TemplateFolder.Layouts;
            string templateFoler = SWCmsHelper.GetFullPath(new string[]
            {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , SWCmsConstants.Default.DefaultTemplateFolder
                    , folder
            });

        var templates = TemplateRepository.Instance.GetTemplates(templateFoler);
            ViewBag.folder = folder;
            return View(templates);
        }

        // GET: article/Edit/5
        [Route("templates/Edit/{folder}")]
        [Route("templates/Edit/{folder}/{name}")]
        public IActionResult EditTemplate(string folder, string name)
        {
            string templateFoler = SWCmsHelper.GetFullPath(new string[]
           {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , SWCmsConstants.Default.DefaultTemplateFolder
                    , folder
           });
            var template = TemplateRepository.Instance.GetTemplate(name, templateFoler);
            if (template == null)
            {
                return RedirectToAction("templates", new {  folder });
            }
            ViewBag.folder = folder;
            return View(template);
        }

        // POST: article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("templates/Edit/{folder}")]
        [Route("templates/Edit/{folder}/{name}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTemplate(string folder, string name, TemplateViewModel template)
        {
            if (ModelState.IsValid)
            {
                var result = TemplateRepository.Instance.SaveTemplate(template);
                if (result)
                {
                    return RedirectToAction("templates", new { folder = folder });
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Model");
            return View(template);
        }

        // GET: article/Edit/5
        [Route("templates/Delete/{folder}/{name}")]
        public IActionResult DeleteTemplate(string folder, string name)
        {
            var template = TemplateRepository.Instance.DeleteTemplate(name, folder);
            return RedirectToAction("templates", new {  folder });
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
