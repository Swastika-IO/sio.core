// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Mvc.Areas.Portal.Controllers;
using Swastika.Cms.Mvc.Controllers;
using System;
using System.Threading.Tasks;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers.Apis
{
    [Area("Portal")]
    [Route("api/{culture}/Portal/Module")]
    public class ApiModuleController : BaseController
    {
        public ApiModuleController(IHostingEnvironment env, IStringLocalizer<PortalController> localizer) : base(env)
        {
        }

        // GET: Portal/Modules
        [HttpGet]
        [Route("Index")]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var pagingPages = await BEModuleViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == CurrentLanguage
                    && (string.IsNullOrEmpty(keyword) || m.Name.Contains(keyword)),
                "Name", OrderByDirection.Ascending,
                pageSize, pageIndex);

            return View(pagingPages);
        }

        // GET: Portal/Modules/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var Module = new BEModuleViewModel()
            {
                Specificulture = CurrentLanguage,
                Columns = new System.Collections.Generic.List<Swastika.Cms.Lib.ViewModels.ModuleFieldViewModel>()
            };
            return View(Module);
        }

        // POST: Module/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BEModuleViewModel Module)
        {
            if (ModelState.IsValid)
            {
                var result = await Module.SaveModelAsync();
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception(result.Exception.StackTrace);
                }
            }
            return View(Module);
        }

        // GET: Module/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var Module = await BEModuleViewModel.Repository.GetSingleModelAsync(m => m.Id == id && m.Specificulture == CurrentLanguage);
            if (Module == null)
            {
                return RedirectToAction("Index");
            }
            return View(Module);
        }

        // POST: Module/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BEModuleViewModel Module)
        {
            if (id != Module.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await Module.SaveModelAsync();
                    if (result.IsSucceed)
                    {
                        return RedirectToAction("Details", new { id = Module.Id });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Exception.Message);
                        return View(Module);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BEModuleViewModel.Repository.CheckIsExists(m => m.Id == Module.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["Action"] = "Edit";
            ViewData["Controller"] = "Pages";
            return View(Module);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Module = await BEModuleViewModel.Repository.RemoveModelAsync(m => m.Id == id && m.Specificulture == CurrentLanguage);
            return RedirectToAction("Index");
        }

        #region Ajax Functions

        [HttpGet]
        [Route("AjaxAddModuleData/{moduleId}")]
        public async Task<InfoModuleDataViewModel> AjaxAddModuleData(int moduleId)
        {
            string _lang = RouteData.Values["culture"].ToString();
            var module = await BEModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang);
            if (module.IsSucceed)
            {
                var ModuleData = new InfoModuleDataViewModel()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ModuleId = moduleId,
                    Specificulture = _lang,

                    Fields = module.Data?.Fields
                };
                return ModuleData;
            }
            else
            {
                return null;
            }
        }

        // POST: ModuleData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("AjaxSaveModuleData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjaxSaveModuleData(InfoModuleDataViewModel ModuleData)
        {
            if (ModelState.IsValid)
            {
                ModuleData.CreatedDateTime = DateTime.UtcNow;
                var result = await ModuleData.SaveModelAsync();
                if (result.IsSucceed)
                {
                    return PartialView("_ModuleData_Record", result.Data);
                }
                else
                {
                    throw new Exception(result.Exception.StackTrace);
                }
            }
            return View(ModuleData);
        }

        [Route("AjaxAtiveModuleData/{articleId}/{dataId}/{isActived:bool}")]
        [HttpGet]
        public async Task<bool> AjaxAtiveModuleData(string articleId, string dataId, bool isActived)
        {
            var getData = await InfoModuleDataViewModel.Repository.GetSingleModelAsync(
                d => d.Id == dataId && d.Specificulture == CurrentLanguage);
            if (getData.IsSucceed)
            {
                var data = getData.Data;
                data.ArticleId = isActived ? articleId : null;
                var result = await InfoModuleDataViewModel.Repository.SaveModelAsync(data);
                return result.IsSucceed;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("AjaxEditModuleData/{dataId}")]
        public async Task<IActionResult> AjaxEditModuleData(string dataId)
        {
            var getData = await InfoModuleDataViewModel.Repository.GetSingleModelAsync(
                d => d.Id == dataId && d.Specificulture == CurrentLanguage);
            if (getData.IsSucceed)
            {
                var data = getData.Data;
                return PartialView("_ModuleData", data);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion Ajax Functions

        #region Module Details Handler

        // GET: Portal/Modules
        [HttpGet]
        [Route("Details/{id}")]
        [Route("Details/{id}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Details(int id, int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var getModule = await BEModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Specificulture == CurrentLanguage && m.Id == id);
            if (getModule.IsSucceed)
            {
                return View(getModule.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Portal/ModuleDatas/AddModuleData
        [HttpGet]
        [Route("AddModuleData/{id:int}")]
        public async Task<IActionResult> AddModuleData(int id)
        {
            var getModule = await InfoModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == id && m.Specificulture == CurrentLanguage);
            if (getModule.IsSucceed)
            {
                var module = getModule.Data;
                var ModuleData = new InfoModuleDataViewModel(
                    new SiocModuleData()
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        ModuleId = id,
                        Specificulture = CurrentLanguage,
                        Fields = module.Fields
                    });
                return View(ModuleData);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: ModuleData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("AddModuleData/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddModuleData(InfoModuleDataViewModel ModuleData)
        {
            if (ModelState.IsValid)
            {
                ModuleData.CreatedDateTime = DateTime.UtcNow;
                var result = await ModuleData.SaveModelAsync();
                if (result.IsSucceed)
                {
                    return RedirectToAction("Details", new RouteValueDictionary(new { id = ModuleData.ModuleId }));
                }
                else
                {
                    throw new Exception(result.Exception.StackTrace);
                }
            }
            return View(ModuleData);
        }

        // GET: ModuleData/Edit/5
        [HttpGet]
        [Route("EditModuleData/{id}/{dataId}")]
        public async Task<IActionResult> EditModuleData(int id, string dataId)
        {
            var getModuleData = await InfoModuleDataViewModel.Repository.GetSingleModelAsync(
                m => m.Id == dataId);
            if (getModuleData.IsSucceed)
            {
                return View(getModuleData.Data);
            }
            return RedirectToAction("Index");
        }

        // POST: ModuleData/EditModuleData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("EditModuleData/{id}/{dataId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditModuleData(InfoModuleDataViewModel ModuleData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await ModuleData.SaveModelAsync();
                    if (result.IsSucceed)
                    {
                        return RedirectToAction("Details", new RouteValueDictionary(
                            new { id = ModuleData.ModuleId }));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Exception.Message);
                        return View(ModuleData);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoModuleDataViewModel.Repository.CheckIsExists(m => m.Id == ModuleData.Id))
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
            return View(ModuleData);
        }

        [HttpGet]
        [Route("DeleteModuleData/{id}")]
        public async Task<IActionResult> DeleteModuleData(string id)
        {
            var getData = await InfoModuleDataViewModel.Repository.GetSingleModelAsync(
                m => m.Id == id);
            if (getData.IsSucceed)
            {
                await InfoModuleDataViewModel.Repository.RemoveModelAsync(m => m.Id == id);
            }

            return RedirectToAction("Details", new RouteValueDictionary(new { id = id }));
        }

        #endregion Module Details Handler
    }
}