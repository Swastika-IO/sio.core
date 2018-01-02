using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Swastika.Cms.Mvc.Controllers;
using System.IO;
using System.Collections.Generic;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using Microsoft.Data.OData.Query;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Swastika.Cms.Lib;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Template")]
    public class TemplateController : BaseController<TemplateController>
    {
        //private readonly IViewRenderService _viewRenderService;
        public TemplateController(IHostingEnvironment env
            )
            : base(env)
        {
        }

        [Route("{templateId:int}")]
        [Route("{templateId:int}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{templateId:int}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("Index/{templateId:int}/{folder}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{templateId:int}/{folder}/{pageSize:int?}/{pageIndex:int?}")]
        public async Task<IActionResult> Index(int templateId,string folder, int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
           var getTemplateFile = await InfoTemplateViewModel.Repository.GetModelListByAsync(
                template => template.TemplateId == templateId 
                && template.FolderType == folder
                && (string.IsNullOrEmpty(keyword) || template.FileName.Contains(keyword)),
                "CreatedDateTime", OrderByDirection.Descending,
                pageSize, pageIndex);
            ViewBag.templateId = templateId;
            return View(getTemplateFile.Data);
        }

        [Route("Create/{templateId:int}")]
        public IActionResult Create(int templateId)
        {
            var getTemplate = InfoThemeViewModel.Repository.GetSingleModel(t => t.Id == templateId);
            if (getTemplate.IsSucceed)
            {
                var TemplateFile = new InfoTemplateViewModel()
                {
                    ModifiedBy = User.Identity.Name,
                    Extension = SWCmsConstants.Parameters.TemplateExtension,
                    TemplateId = templateId,
                    TemplateName = getTemplate.Data.Name
                };
                return View(TemplateFile);
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST: TtsMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create/{templateId:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int templateId, InfoTemplateViewModel template)
        {
            if (ModelState.IsValid)
            {
                template.CreatedDateTime = DateTime.UtcNow;
                var result = await template.SaveModelAsync(true);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index", new { templateId = template.TemplateId });
                }
                else
                {
                    return View(template);
                }
            }
            return View(template);
        }

        // GET: TtsMenu/Edit/5
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TemplateFile = await InfoTemplateViewModel.Repository.GetSingleModelAsync(m => m.Id == id);
            if (!TemplateFile.IsSucceed)
            {
                return NotFound();
            }
            return View(TemplateFile.Data);
        }

        // POST: TtsMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InfoTemplateViewModel template)
        {
            if (id != template.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    template.ModifiedBy = User.Identity.Name;
                    template.LastModified = DateTime.UtcNow;
                    var result = await template.SaveModelAsync(true);
                    if (result.IsSucceed)
                    {
                        return RedirectToAction("Index", new { templateId = template.TemplateId });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Exception.Message);
                        return View(template);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoTemplateViewModel.Repository.CheckIsExists(m => m.Id == template.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Index");
            }
            ViewData["Action"] = "Edit";
            ViewData["Controller"] = "TemplateFile";
            return View(template);
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var template = await InfoTemplateViewModel.Repository.GetSingleModelAsync(m => m.Id == id);
            await template.Data.RemoveModelAsync();
            return RedirectToAction("Index", new { templateId = template.Data.TemplateId });
        }
    }
    //public class FileViewModel
    //{
    //    public string Filename { get; set; }
    //    public string Content { get; set; }
    //}
}
