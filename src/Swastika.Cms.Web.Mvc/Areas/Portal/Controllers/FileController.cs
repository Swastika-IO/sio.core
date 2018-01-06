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
    [Route("{culture}/Portal/File")]
    public class FileController : BaseController<ApperanceController>
    {
        public FileController(IHostingEnvironment env
            //, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        [Route("")]
        [Route("/{folder}")]
        public IActionResult Index(string folder)
        {
            folder = folder ?? SWCmsConstants.FileFolder.Images;
            var templates = FileRepository.Instance.GetUploadFiles(folder);
            ViewBag.folder = folder;
            return View(templates);
        }

        // GET: article/Edit/5
        [Route("Edit/{folder}")]
        [Route("Edit/{folder}/{name}/{ext}")]
        public IActionResult Edit(string folder, string name, string ext)
        {           
            var template = FileRepository.Instance.GetUploadFile(name, ext, folder);
            if (template == null)
            {
                return RedirectToAction("", new {  folder });
            }
            return View(template);
        }

        // POST: article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{folder}")]
        [Route("Edit/{folder}/{name}/{ext}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FileViewModel template)
        {
            if (ModelState.IsValid)
            {
                var result = FileRepository.Instance.SaveFile(template);
                if (result)
                {
                    return RedirectToAction("", new { folder = template.FileFolder });
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Model");
            return View(template);
        }

        // GET: article/Edit/5
        [Route("Delete/{folder}/{name}/{ext}")]
        public IActionResult Delete(string folder, string name, string ext)
        {
            var template = FileRepository.Instance.DeleteFile(name, ext, folder);
            return RedirectToAction("", routeValues: new {  folder });
        }
    }
}