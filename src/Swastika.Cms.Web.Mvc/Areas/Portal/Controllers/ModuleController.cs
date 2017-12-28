using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.Services;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Module")]
    public class ModuleController : BaseController<ModuleController>
    {
        private ApplicationConfigService _appService;

        public ModuleController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> moduleLocalizer
            //, IStringLocalizer<SharedResource> localizer
            , ApplicationConfigService appService)
            : base(env)
        {
            _appService = appService;
        }


        // GET: Portal/Modules
        [Route("Index")]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var pagingPages = await 
                ModuleListItemViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang
                    && (string.IsNullOrEmpty(keyword) || m.Name.Contains(keyword)),
                "Name", OrderByDirection.Ascending,
                pageSize, pageIndex);

            return View(pagingPages.Data);
        }

        // GET: Portal/Modules/Create
        [Route("Create")]
        public IActionResult Create()
        {
            var Module = new BEModuleViewModel(new SiocModule()
            {
                Specificulture = _lang
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
                var result = await Module.SaveModelAsync();
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
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var Module = await BEModuleViewModel.Repository.GetSingleModelAsync(m => 
            m.Id == id && m.Specificulture == _lang);
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

        [Route("AddEmptyField/{index}")]
        public IActionResult AddEmptyField(int index)
        {
            ViewData["Index"] = index;
            return PartialView(new ModuleFieldViewModel() { Width = 2, IsDisplay = true });
        }

        //#region Ajax Functions


        //[HttpGet]
        //[Route("AjaxAddModuleData/{moduleId}")]
        //public async Task<IActionResult> AjaxAddModuleData(int moduleId)
        //{
        //    var getModule = await ModuleListItemViewModel.Repository.GetSingleModelAsync
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
        [Route("Details/{id}")]
        [Route("Details/{id}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("Details/{id}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Details(int id, int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var getModule = await BEModuleViewModel.Repository.GetSingleModelAsync
                (m => m.Specificulture == _lang && m.Id == id);
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
        [Route("AddModuleData/{id:int}")]
        public async Task<IActionResult> AddModuleData(int id)
        {
            var getModule = await ModuleListItemViewModel.Repository.GetSingleModelAsync(
                m => m.Id == id && m.Specificulture == _lang);
            if (getModule.IsSucceed)
            {
                var ModuleData = new InfoModuleDataViewModel(
                    new SiocModuleData()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ModuleId = id,
                    Specificulture = _lang,
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
        public async Task<IActionResult> AddModuleData(InfoModuleDataViewModel ModuleData)
        {
            if (ModelState.IsValid)
            {
                ModuleData.CreatedDateTime = DateTime.UtcNow;
                var result = await ModuleData.SaveModelAsync();
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
        [Route("EditModuleData/{id}/{dataId}")]
        public async Task<IActionResult> EditModuleData(int id, string dataId)
        {
            var ModuleData = await InfoModuleDataViewModel.Repository.GetSingleModelAsync(
                m => m.Id == dataId && m.Specificulture == _lang);
            if (ModuleData == null)
            {
                return RedirectToAction("Index");
            }
            return View(ModuleData);
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
                    if (!InfoModuleDataViewModel.Repository.CheckIsExists(
                        m => m.Id == ModuleData.Id && m.Specificulture == _lang))
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
        [Route("DeleteModuleData/{id}")]
        public async Task<IActionResult> DeleteModuleData(string id)
        {
            var getData = await InfoModuleDataViewModel.Repository.GetSingleModelAsync(m => m.Id == id);
            if (getData.IsSucceed)
            {
                var result = await InfoModuleDataViewModel.Repository.RemoveModelAsync(m => m.Id == id && m.Specificulture== _lang);
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

        #endregion
    }
}
