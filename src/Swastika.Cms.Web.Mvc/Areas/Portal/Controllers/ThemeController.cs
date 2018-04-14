// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Mvc.Controllers;
using System;
using System.Threading.Tasks;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Theme")]
    [RequestSizeLimit(int.MaxValue)]
    public class ThemeController : BaseController<ThemeController>
    {
        //private readonly IViewRenderService _viewRenderService;
        public ThemeController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> templateLocalizer
            //, IViewRenderService viewRenderService
            //, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        [HttpGet]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var getTemplate = await InfoThemeViewModel.Repository.GetModelListByAsync(
                 template => (string.IsNullOrEmpty(keyword) || template.Name.Contains(keyword)),
                 "CreatedDateTime", OrderByDirection.Descending,
                 pageSize, pageIndex).ConfigureAwait(false);

            return View(getTemplate.Data);
        }

        [HttpGet]
        [Route("SyncFromLocal/{id}")]
        public async Task<IActionResult> SyncFromLocal(int id)
        {
            var getTemplate = await BETemplateViewModel.Repository.GetModelListByAsync(
                 template => template.TemplateId == id).ConfigureAwait(false);
            foreach (var item in getTemplate.Data)
            {
                await item.SaveModelAsync().ConfigureAwait(false);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var template = new BEThemeViewModel()
            {
                CreatedBy = User.Identity.Name,
                Specificulture = CurrentLanguage
            };
            return View(template);
        }

        // POST: TtsMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(BEThemeViewModel template)
        {
            if (ModelState.IsValid)
            {
                template.CreatedDateTime = DateTime.UtcNow;
                var result = await template.SaveModelAsync(true).ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return View(template);
                }
            }
            return View(template);
        }

        // GET: TtsMenu/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var template = await BEThemeViewModel.Repository.GetSingleModelAsync(m => m.Id == id).ConfigureAwait(false);
            if (!template.IsSucceed)
            {
                return NotFound();
            }
            else
            {
                template.Data.Specificulture = CurrentLanguage;
                template.Data.IsActived = template.Data.Name == GlobalConfigurationService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, CurrentLanguage, SWCmsConstants.Default.DefaultTemplateFolder);
            }
            return View(template.Data);
        }

        // POST: TtsMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [HttpPost]
        [RequestSizeLimit(100000000)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BEThemeViewModel template)
        {
            if (id != template.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await template.SaveModelAsync(true).ConfigureAwait(false);
                    if (result.IsSucceed)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (result.Exception!=null)
                        {
                            ModelState.AddModelError(string.Empty, result.Exception.Message);
                        }
                        
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }
                        return View(template);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BEThemeViewModel.Repository.CheckIsExists(m => m.Id == template.Id))
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

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var template = await BEThemeViewModel.Repository.GetSingleModelAsync(m => m.Id == id).ConfigureAwait(false);
            if (template.IsSucceed)
            {
                await template.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            return RedirectToAction("Index");
        }
    }

    //public class FileViewModel
    //{
    //    public string Filename { get; set; }
    //    public string Content { get; set; }
    //}
}
