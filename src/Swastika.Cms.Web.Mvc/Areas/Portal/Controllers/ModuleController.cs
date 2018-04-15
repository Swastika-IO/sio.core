// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Cms.Mvc.Controllers;
using System;
using System.Threading.Tasks;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Module")]
    public class ModuleController : BaseController<ModuleController>
    {
        //private GlobalConfigurationService _appService;

        public ModuleController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> moduleLocalizer
            //, IStringLocalizer<SharedResource> localizer
            //, GlobalConfigurationService appService
            )
            : base(env)
        {
            //_appService = appService;
        }

        // GET: Portal/Modules
        [HttpGet]
        [Route("Index")]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var pagingPages = await
                InfoModuleViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == CurrentLanguage
                    && (string.IsNullOrEmpty(keyword) || m.Name.Contains(keyword)),
                "Priority", OrderByDirection.Ascending,
                pageSize, pageIndex).ConfigureAwait(false);

            return View(pagingPages.Data);
        }

        // GET: Portal/Modules/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var Module = new BEModuleViewModel(new SiocModule()
            {
                Specificulture = CurrentLanguage,
                Status = (int)Common.Utility.Enums.SWStatus.Published
            });
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
                var result = await Module.SaveModelAsync(true).ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Details", new { id = Module.Id });
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
            var Module = await BEModuleViewModel.Repository.GetSingleModelAsync(m =>
            m.Id == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            if (Module == null)
            {
                return RedirectToAction("Index");
            }
            return View(Module.Data);
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
                    var result = await Module.SaveModelAsync(true).ConfigureAwait(false);
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
                //return RedirectToAction("Index");
            }
            ViewData["Action"] = "Edit";
            ViewData["Controller"] = "Pages";
            return View(Module);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Module = await BEModuleViewModel.Repository.RemoveModelAsync(m => m.Id == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("AddEmptyField/{index}")]
        public IActionResult AddEmptyField(int index)
        {
            ViewData["Index"] = index;
            return PartialView(new ModuleFieldViewModel() { Width = 2, IsDisplay = true });
        }

        [HttpGet]
        [Route("Delete/Product-Nav/{id}/{productId}")]
        public async Task<IActionResult> DeleteNav(int id, string productId)
        {
            var Module = await NavModuleProductViewModel.Repository.RemoveModelAsync(
                m => m.ModuleId == id && m.ProductId == productId && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            return RedirectToAction("Details", new { id });
        }

        //#region Ajax Functions

        //[HttpGet]
        //[Route("AjaxAddModuleData/{moduleId}")]
        //public async Task<IActionResult> AjaxAddModuleData(int moduleId)
        //{
        //    var getModule = await InfoModuleViewModel.Repository.GetSingleModelAsync
        //        (m => m.Id == moduleId && m.Specificulture == _lang);
        //    if (getModule.IsSucceed)
        //    {
        //        var ModuleData = new InfoModuleDataViewModel(
        //            new SiocModuleData() {
        //                Id = Guid.NewGuid().ToString("N"),
        //                ModuleId = moduleId,
        //                Specificulture = _lang,
        //                Fields = getModule.Data.Fields
        //            });
        //        return PartialView("_ModuleData", ModuleData);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //// POST: ModuleData/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Route("AjaxSaveModuleData")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AjaxSaveModuleData(InfoModuleDataViewModel ModuleData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ModuleData.CreatedDate = DateTime.UtcNow;
        //        var result = await ModuleData.SaveModelAsync();
        //        if (result.IsSucceed)
        //        {
        //            return PartialView("_ModuleData_Record", result.Data);
        //        }
        //        else
        //        {
        //            throw new Exception(result.Ex.StackTrace);
        //        }
        //    }
        //    return View(ModuleData);
        //}

        //[Route("AjaxAtiveModuleData/{articleId}/{dataId}/{isActived:bool}")]
        //[HttpGet]
        //public async Task<bool> AjaxAtiveModuleData(string articleId, string dataId, bool isActived)
        //{
        //    var data = await ModuleDataRepository.GetInstance().GetSingleModelAsync(d => d.Id == dataId && d.Specificulture == _lang);
        //    if (data != null)
        //    {
        //        data.ArticleId = isActived ? articleId : null;
        //        var result = await ModuleDataRepository.GetInstance().SaveModelAsync(data);
        //        return result.IsSucceed;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //[Route("AjaxEditModuleData/{dataId}")]
        //public async Task<IActionResult> AjaxEditModuleData(string dataId)
        //{
        //    var data = await ModuleDataRepository.GetInstance().GetSingleModelAsync(d => d.Id == dataId && d.Specificulture == _lang);
        //    if (data != null)
        //    {
        //        return PartialView("_ModuleData", data);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //#endregion

        #region Module Details Handler

        // GET: Portal/Modules
        [HttpGet]
        [Route("Details/{id}")]
        [Route("Details/{id}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("Details/{id}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Details(int id, int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var getModule = await BEModuleViewModel.Repository.GetSingleModelAsync
                (m => m.Specificulture == CurrentLanguage && m.Id == id).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var module = getModule.Data;
                return View(module);
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
                m => m.Id == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new BEModuleDataViewModel(
                    new SiocModuleData()
                    {
                        ModuleId = id,
                        Specificulture = CurrentLanguage,
                        Fields = getModule.Data.Fields
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
        public async Task<IActionResult> AddModuleData(BEModuleDataViewModel ModuleData)
        {
            if (ModelState.IsValid)
            {
                ModuleData.CreatedDateTime = DateTime.UtcNow;
                var result = await ModuleData.SaveModelAsync().ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Details", new { id = ModuleData.ModuleId });
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
            var ModuleData = await BEModuleDataViewModel.Repository.GetSingleModelAsync(
                m => m.Id == dataId && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            var file = FileRepository.Instance.GetWebFile("fonts.css", "Content/Templates/Biotic/css");

            if (!ModuleData.IsSucceed)
            {
                return RedirectToAction("Index");
            }
            return View(ModuleData.Data);
        }

        // POST: ModuleData/EditModuleData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("EditModuleData/{id}/{dataId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditModuleData(BEModuleDataViewModel ModuleData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await ModuleData.SaveModelAsync();//.ConfigureAwait(false);
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
                    if (!InfoModuleDataViewModel.Repository.CheckIsExists(
                        m => m.Id == ModuleData.Id && m.Specificulture == CurrentLanguage))
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
            var getData = await InfoModuleDataViewModel.Repository.GetSingleModelAsync(m => m.Id == id).ConfigureAwait(false);
            if (getData.IsSucceed)
            {
                var result = await getData.Data.RemoveModelAsync().ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Details", new RouteValueDictionary(new
                    {
                        id = getData.Data.ModuleId
                    }));
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        #endregion Module Details Handler
    }
}
