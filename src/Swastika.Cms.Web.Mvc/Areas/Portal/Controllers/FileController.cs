using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib;
using Swastika.IO.Common.Helper;
using System.Collections.Generic;

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

        [Route("Theme/{themeName}")]
        [Route("Theme/{themeName}/{folder}")]
        public IActionResult Theme(string themeName, string folder)
        {
            string fullPath = CommonHelper.GetFullPath(new string[]
            {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.TemplatesAssetFolder,
                themeName,
                folder
            });
            List<string> directories = FileRepository.Instance.GetTopDirectories(fullPath);
            List<FileViewModel> files = !string.IsNullOrEmpty(folder)? FileRepository.Instance.GetTopFiles(fullPath)
                : new List<FileViewModel>();
            ViewData["name"] = themeName;
            ViewData["directories"] = directories;
            return View(files);
        }

        [Route("EditTheme/{themeName}/{folder}/{name}/{ext}")]
        public IActionResult EditTheme(string themeName, string folder, string name, string ext)
        {

            string fullPath = CommonHelper.GetFullPath(new string[]
          {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.TemplatesAssetFolder,
                themeName,
                folder,
                name
          });
            string filePath = string.Format("{0}{1}", fullPath, ext);
            return View(FileRepository.Instance.GetFile(filePath, folder));
        }

        [Route("")]
        [Route("{folder}")]
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
                return RedirectToAction("", new { folder });
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
            return RedirectToAction("", routeValues: new { folder });
        }

        [Route("DeleteTheme/{themeName}/{folder}/{name}/{ext}")]
        [Route("DeleteTheme/{themeName}/{name}/{ext}")]
        public IActionResult DeleteTheme(string themeName, string folder, string name, string ext)
        {

            string fullPath = CommonHelper.GetFullPath(new string[]
          {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.TemplatesAssetFolder,
                themeName,
                folder,
                name
          });
            string filePath = string.Format("{0}{1}", fullPath, ext);
            var file = FileRepository.Instance.DeleteFile(filePath);
            return RedirectToAction("Theme", routeValues: new { themeName, folder });
        }
    }
}