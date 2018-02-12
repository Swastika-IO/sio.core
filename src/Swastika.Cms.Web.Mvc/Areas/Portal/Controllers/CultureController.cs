using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.Services;
using Microsoft.Data.OData.Query;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Culture")]
    public class CultureController : BaseController<CultureController>
    {
        //private readonly GlobalConfigurationService _appService;
        public CultureController(IHostingEnvironment env
            //, GlobalConfigurationService service
            )
            : base(env)
        {
            //_appService = service;
        }

        // GET: Portal/Cultures
        [HttpGet]
        [Route("Index")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public IActionResult Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            return View(CultureViewModel.Repository.GetModelList("FullName", OrderByDirection.Ascending
                ,pageSize, pageIndex).Data);
        }

        // GET: Culture/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsCulture = await CultureViewModel.Repository.GetSingleModelAsync(m => m.Id == id);
            if (ttsCulture == null)
            {
                return NotFound();
            }

            return View(ttsCulture);
        }

        // GET: Culture/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Culture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CultureViewModel vmCulture)
        {
            if (ModelState.IsValid)
            {
                var result = await vmCulture.SaveModelAsync();
                if (result.IsSucceed)
                {
                    GlobalLanguageService.Instance.RefreshCultures();
                }
                return RedirectToAction("Index");
            }
            return View(vmCulture);
        }

        // GET: Culture/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsCulture = await CultureViewModel.Repository.GetSingleModelAsync(m => m.Id == id);
            if (!ttsCulture.IsSucceed)
            {
                return NotFound();
            }
            return View(ttsCulture.Data);
        }

        // POST: Culture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CultureViewModel culture)
        {
            if (id != culture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await culture.SaveModelAsync();
                    if (result.IsSucceed)
                    {
                        GlobalLanguageService.Instance.RefreshCultures();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CultureViewModel.Repository.CheckIsExists(c => c.Specificulture == culture.Specificulture))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(culture);
        }

        // GET: Culture/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsCulture = await CultureViewModel.Repository.GetSingleModelAsync(m => m.Id == id);
            if (ttsCulture == null)
            {
                return NotFound();
            }

            return View(ttsCulture);
        }

        // POST: Culture/Delete/5
        [Route("Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await CultureViewModel.Repository.RemoveModelAsync(c => c.Id == id);
            return RedirectToAction("Index");
        }

    }
}