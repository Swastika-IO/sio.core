// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Mvc.Controllers;
using System.Threading.Tasks;

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
            return View(BECultureViewModel.Repository.GetModelList("FullName", OrderByDirection.Ascending
                , pageSize, pageIndex).Data);
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

            var ttsCulture = await BECultureViewModel.Repository.GetSingleModelAsync(m => m.Id == id).ConfigureAwait(false);
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
            return View(new BECultureViewModel());
        }

        // POST: Culture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BECultureViewModel vmCulture)
        {
            if (ModelState.IsValid)
            {
                var result = await vmCulture.SaveModelAsync().ConfigureAwait(false);
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
        public async Task<IActionResult> Edit(int id)
        {
            var ttsCulture = await BECultureViewModel.Repository.GetSingleModelAsync(m => m.Id == id);//.ConfigureAwait(false);
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
        public async Task<IActionResult> Edit(int id, [FromForm] BECultureViewModel culture)
        {
            if (id != culture.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await culture.SaveModelAsync().ConfigureAwait(false);
                    if (result.IsSucceed)
                    {
                        GlobalLanguageService.Instance.RefreshCultures();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BECultureViewModel.Repository.CheckIsExists(c => c.Specificulture == culture.Specificulture))
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

        
        // POST: Culture/Delete/5
        [Route("Delete/{id}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var vm = await BECultureViewModel.Repository.GetSingleModelAsync(c => c.Id == id);
            if (vm.IsSucceed)
            {
                vm.Data.RemoveModelAsync(true);
            }
            return RedirectToAction("Index");
        }
    }
}
