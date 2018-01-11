using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Routing;
using Swastika.Cms.Mvc.Areas.Portal.Controllers;
using Swastika.Cms.Mvc.Controllers;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Microsoft.Data.OData.Query;

namespace TTS.Web.Areas.Portal.Controllers.Apis
{
    [Area("Portal")]
    [Route("api/{culture}/Portal/Module")]
    public class ApiModuleController : BaseController<ApiModuleController>
    {

        public ApiModuleController(IHostingEnvironment env, IStringLocalizer<PortalController> localizer) : base(env)
        {
        }


        // GET: Portal/Modules
        [Route("Index")]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var pagingPages = await BEModuleViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang
                    && (string.IsNullOrEmpty(keyword) || m.Name.Contains(keyword)),
                "Name", OrderByDirection.Ascending,
                pageSize, pageIndex);

            return View(pagingPages);
        }

        // GET: Portal/Modules/Create
        [Route("Create")]
        public IActionResult Create()
        {
            var Module = new BEModuleViewModel()
            {
                Specificulture = _lang,
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
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var Module = await BEModuleViewModel.Repository.GetSingleModelAsync(m => m.Id == id && m.Specificulture == _lang);
            if (Module == null)
            {
                return RedirectToAction("Index");
            }
            //ViewData["Specificulture"] = new SelectList(_context.TtsCulture, "Specificulture", "Specificulture", Module.Specificulture);

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
                //return RedirectToAction("Index");
            }
            ViewData["Action"] = "Edit";
            ViewData["Controller"] = "Pages";
            return View(Module);
        }


        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Module = await BEModuleViewModel.Repository.RemoveModelAsync(m => m.Id == id && m.Specificulture == _lang);
            return RedirectToAction("Index");
        }

        
        //#region Ajax Functions


        //[HttpGet]
        //[Route("AjaxAddModuleData/{moduleId}")]
        //public async Task<IActionResult> AjaxAddModuleData(int moduleId)
        //{
        //    var module = await _repo.GetSingleModelAsync(m => m.Id == moduleId && m.Specificulture == _lang, Constants.ViewModelType.BackEnd);
        //    if (module != null)
        //    {
        //        var ModuleData = new ModuleDataViewModel(_lang, module.Columns)
        //        {
        //            Id = Guid.NewGuid().ToString("N"),
        //            ModuleId = moduleId,
        //            Specificulture = _lang,
        //            Fields = module.Fields
        //        };
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
        //public async Task<IActionResult> AjaxSaveModuleData(ModuleDataViewModel ModuleData)
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

        //#region Module Details Handler


        //// GET: Portal/Modules
        //[Route("Details/{id}")]
        //[Route("Details/{id}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        //public async Task<IActionResult> Details(int id, int pageSize = 10, int pageIndex = 0, string keyword = null)
        //{
        //    ModuleViewModel module = await _repo.GetSingleModelAsync(m => m.Specificulture == _lang && m.Id == id, Constants.ViewModelType.FrontEnd);
        //    if (module != null)
        //    {
        //        module.Data = await ModuleDataRepository.GetInstance().GetModelListByAsync(d => d.ModuleId == id && d.Specificulture == _lang, d => d.CreatedDate, "asc", pageIndex, pageSize, Constants.ViewModelType.FrontEnd);
        //        module.Articles = await ArticleRepository.GetInstance().GetModelListByModuleAsync(id, _lang, pageIndex, pageSize);
        //        return View(module);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        //// GET: Portal/ModuleDatas/AddModuleData
        //[Route("AddModuleData/{id:int}")]
        //public async Task<IActionResult> AddModuleData(int id)
        //{
        //    var module = await _repo.GetSingleModelAsync(m => m.Id == id && m.Specificulture == _lang, Constants.ViewModelType.BackEnd);
        //    if (module != null)
        //    {
        //        var ModuleData = new ModuleDataViewModel(_lang, module.Columns)
        //        {
        //            Id = Guid.NewGuid().ToString("N"),
        //            ModuleId = id,
        //            Specificulture = _lang,
        //            Fields = module.Fields
        //        };
        //        return View(ModuleData);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //// POST: ModuleData/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Route("AddModuleData/{id:int}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddModuleData(ModuleDataViewModel ModuleData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ModuleData.CreatedDate = DateTime.UtcNow;
        //        var result = await ModuleData.SaveModelAsync();
        //        if (result.IsSucceed)
        //        {
        //            return RedirectToAction("Details", new RouteValueDictionary(new { id = ModuleData.ModuleId }));
        //        }
        //        else
        //        {
        //            throw new Exception(result.Ex.StackTrace);
        //        }
        //    }
        //    return View(ModuleData);
        //}

        //// GET: ModuleData/Edit/5
        //[Route("EditModuleData/{id}/{dataId}")]
        //public async Task<IActionResult> EditModuleData(int id, string dataId)
        //{
        //    var ModuleData = await ModuleDataRepository.GetInstance().GetSingleModelAsync(m => m.Id == dataId, Constants.ViewModelType.BackEnd);
        //    if (ModuleData == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(ModuleData);
        //}

        //// POST: ModuleData/EditModuleData/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Route("EditModuleData/{id}/{dataId}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditModuleData(ModuleDataViewModel ModuleData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var result = await ModuleData.SaveModelAsync();
        //            if (result.IsSucceed)
        //            {
        //                return RedirectToAction("Details", new RouteValueDictionary(new { id = ModuleData.ModuleId }));
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, result.Ex.Message);
        //                return View(ModuleData);
        //            }
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ModuleDataRepository.GetInstance().CheckIsExists(m => m.Id == ModuleData.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        //return RedirectToAction("Index");
        //    }
        //    return View(ModuleData);
        //}
        //[Route("DeleteModuleData/{id}")]
        //public async Task<IActionResult> DeleteModuleData(string id)
        //{
        //    var data = await ModuleDataRepository.GetInstance().GetSingleModelAsync(m => m.Id == id);
        //    if (data != null)
        //    {
        //        await ModuleDataRepository.GetInstance().RemoveModelAsync(m => m.Id == id);
        //    }


        //    return RedirectToAction("Details", new RouteValueDictionary(new { id = data.ModuleId }));
        //}

        //#endregion
    }
}
