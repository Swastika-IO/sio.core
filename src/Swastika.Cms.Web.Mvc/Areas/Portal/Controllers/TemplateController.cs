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

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Template")]
    public class TemplateController : BaseController<TemplateController>
    {
        //private readonly IViewRenderService _viewRenderService;
        public TemplateController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> templateLocalizer
            //, IViewRenderService viewRenderService
            //, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
           var getTemplate = await InfoTemplateViewModel.Repository.GetModelListByAsync(
                template => (string.IsNullOrEmpty(keyword) || template.Name.Contains(keyword)),
                "CreatedDateTime", OrderByDirection.Descending,
                pageSize, pageIndex);

            return View(getTemplate.Data);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            var template = new InfoTemplateViewModel()
            {
                CreatedBy = User.Identity.Name
            };
            return View(template);
        }

        // POST: TtsMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InfoTemplateViewModel template)
        {
            if (ModelState.IsValid)
            {
                template.CreatedDateTime = DateTime.UtcNow;
                var result = await template.SaveModelAsync();
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
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

            var template = await InfoTemplateViewModel.Repository.GetSingleModelAsync(m => m.Id == id);
            if (!template.IsSucceed)
            {
                return NotFound();
            }
            return View(template.Data);
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
                    var result = await template.SaveModelAsync();
                    if (result.IsSucceed)
                    {
                        return RedirectToAction("Index");
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
            ViewData["Controller"] = "Template";
            return View(template);
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var template = await InfoTemplateViewModel.Repository.RemoveModelAsync(m => m.Id == id);
            return RedirectToAction("Index");
        }
    }
    //public class FileViewModel
    //{
    //    public string Filename { get; set; }
    //    public string Content { get; set; }
    //}
}
