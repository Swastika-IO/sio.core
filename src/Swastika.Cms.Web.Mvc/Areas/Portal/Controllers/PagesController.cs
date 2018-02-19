// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Mvc.Controllers;
using System.Threading.Tasks;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Pages")]
    public class PagesController : BaseController<PagesController>
    {
        public PagesController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> pageLocalizer, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        //[Route("/portal/pages")]
        [HttpGet]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}")]
        public async Task<IActionResult> Index(string keyword, int pageSize = 10, int pageIndex = 0)
        {
            var pagingPages = await InfoCategoryViewModel.Repository.GetModelListByAsync(
                cate => cate.Specificulture == _lang &&
                    (string.IsNullOrEmpty(keyword) || cate.Title.Contains(keyword))
                , "Priority", OrderByDirection.Ascending
                , pageSize, pageIndex);

            return View(pagingPages.Data);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            //ViewData["Specificulture"] = new SelectList(_context.TtsCulture, "Specificulture", "Specificulture");
            var ttsMenu = new BECategoryViewModel(new SiocCategory()
            {
                Specificulture = _lang,
                CreatedBy = User.Identity.Name,
                //CreatedDate = DateTime.UtcNow
            });
            return View(ttsMenu);
        }

        // POST: TtsMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BECategoryViewModel ttsMenu)
        {
            if (ModelState.IsValid)
            {
                var result = await ttsMenu.SaveModelAsync(true);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(ttsMenu);
                }
            }
            return View(ttsMenu);
        }

        // GET: TtsMenu/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        [Route("Edit/{id}/{pageName}")]
        public async Task<IActionResult> Edit(int? id, string pageName)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getCategory = await BECategoryViewModel.Repository.GetSingleModelAsync(
                m => m.Id == id && m.Specificulture == _lang
                );
            if (!getCategory.IsSucceed)
            {
                return RedirectToAction("Index");
            }
            return View(getCategory.Data);
        }

        // POST: TtsMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [Route("Edit/{id}/{pageName}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BECategoryViewModel ttsMenu)
        {
            if (id != ttsMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await ttsMenu.SaveModelAsync(true);
                    if (result.IsSucceed)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Exception.Message);
                        return View(ttsMenu);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BECategoryViewModel.Repository.CheckIsExists(
                        m => m.Id == ttsMenu.Id))
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
            return View(ttsMenu);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var ttsMenu = await BECategoryViewModel.Repository.RemoveModelAsync(
                m => m.Id == id && m.Specificulture == _lang);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Contents/{id}")]
        [Route("Contents/{id}/{pageSize}/{pageIndex}/{orderBy}/{pageName}")]
        [Route("Contents/{id}/{pageName}")]
        public async Task<IActionResult> Contents(int id, string pageName
            , int? pageSize, int? pageIndex, string orderBy = SWCmsConstants.Default.OrderBy)
        {
            pageSize = pageSize ?? SWCmsConstants.Default.PageSizeArticle;
            pageIndex = pageIndex ?? 0;
            var articles = await InfoArticleViewModel.GetModelListByCategoryAsync(
                id, _lang, orderBy, OrderByDirection.Ascending,
                pageSize, pageIndex);

            if (!articles.IsSucceed)
            {
                return NotFound();
            }
            ViewBag.categoryId = id;
            return View(articles.Data);
        }
    }
}