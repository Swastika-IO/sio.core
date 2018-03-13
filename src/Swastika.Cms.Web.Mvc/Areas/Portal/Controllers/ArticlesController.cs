// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Mvc.Controllers;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Policy ="AddEditUser")]
    [Area("Portal")]
    [Route("{culture}/Portal/Articles")]
    public class ArticlesController : BaseController<ArticlesController>
    {
        public ArticlesController(IHostingEnvironment hostingEnvironment
            //, IStringLocalizer<PortalController> portalLocalizer, IStringLocalizer<SharedResource> localizer
            )
            : base(hostingEnvironment)
        {
        }

        // GET: Portal/Articles
        [HttpPost, HttpGet]
        [Route("Index")]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}")]
        public IActionResult Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            //RepositoryResponse<PaginationModel<InfoArticleViewModel>> getArticles =
            //    await InfoArticleViewModel.Repository.GetModelListByAsync(
            //    article => article.Specificulture == CurrentLanguage
            //        && article.Status != (int)SWStatus.Deleted
            //        && (string.IsNullOrEmpty(keyword) || article.Title.Contains(keyword)),
            //    "Priority", OrderByDirection.Ascending
            //    , pageSize, pageIndex).ConfigureAwait(false);
            //ViewBag.keyword = keyword;
            return View();
        }

        // GET: Portal/Articles/Draft
        [HttpGet]
        [Route("Draft")]
        [Route("Draft/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Draft(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            RepositoryResponse<PaginationModel<InfoArticleViewModel>> repositoryResponse = await InfoArticleViewModel.Repository.GetModelListByAsync(
                article => article.Specificulture == CurrentLanguage
                    && (string.IsNullOrEmpty(keyword) || article.Title.Contains(keyword))
                    && article.Status == (int)SWStatus.Deleted,
                "CreatedDateTime", OrderByDirection.Descending,
                pageSize, pageIndex).ConfigureAwait(false);

            return View(repositoryResponse.Data);
        }

        // GET: Portal/Articles/Create
        [HttpGet]
        [Route("Create")]
        [Route("Create/{categoryId:int}")]
        public IActionResult Create(int? categoryId = null)
        {
            BEArticleViewModel bEArticleViewModel = new BEArticleViewModel(new SiocArticle()
            {
                Specificulture = CurrentLanguage,
                CreatedBy = User.Identity.Name,
                CreatedDateTime = DateTime.UtcNow
            })
            {
                Status = SWStatus.Preview
            };
            if (categoryId.HasValue)
            {
                CategoryArticleViewModel categoryArticleViewModel = bEArticleViewModel.Categories.Find(c => c.CategoryId == categoryId);
                if (categoryArticleViewModel != null)
                {
                    categoryArticleViewModel.IsActived = true;
                }
            }
            ViewBag.categoryId = categoryId;
            return View(bEArticleViewModel);
        }

        [HttpGet]
        [Route("AddEmptyProperty/{index}")]
        public IActionResult AddEmptyProperty(int index)
        {
            ViewData["Index"] = index;
            return PartialView(new ExtraProperty());
        }

        [HttpPost]
        [Route("GetEditor")]
        public IActionResult GetEditor(int index, SWCmsConstants.DataType type, string id, string name, string value)
        {
            ViewData["Id"] = id;
            ViewData["Name"] = name;
            ViewData["DataType"] = type;
            ViewData["Value"] = value;
            ViewData["Index"] = index;
            return PartialView("_Editor");
        }

        // POST: article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [Route("Create/{categoryId:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BEArticleViewModel article, int? categoryId = null)
        {
            if (ModelState.IsValid)
            {
                //var vmArticle = new SWBEArticleViewModel<BackendBEArticleViewModel>(article);
                //var result = await vmArticle.SaveModelAsync();
                var repositoryResponse = await article.SaveModelAsync(true).ConfigureAwait(false);
                if (repositoryResponse.IsSucceed)
                {
                    if (categoryId.HasValue)
                    {
                        return RedirectToAction("Contents", "Pages", new { id = categoryId });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View(article);
                }
            }
            ViewBag.categoryId = categoryId;
            return View(article);
        }

        // GET: article/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        [Route("Edit/{id}/{categoryId:int}")]
        public async Task<IActionResult> Edit(string id = null, int? categoryId = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var repositoryResponse = await BEArticleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            if (repositoryResponse == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = categoryId;
            return View(repositoryResponse.Data);
        }

        // POST: article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [Route("Edit/{id}/{categoryId:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BEArticleViewModel article, string id, int? categoryId = null)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var repositoryResponse = await article.SaveModelAsync(true).ConfigureAwait(false);
                    if (repositoryResponse.IsSucceed)
                    {
                        if (categoryId.HasValue)
                        {
                            return RedirectToAction("Contents", "Pages", new { id = categoryId });
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        if (repositoryResponse.Exception != null)
                        {
                            ModelState.AddModelError(string.Empty, repositoryResponse.Exception?.Message);
                        }

                        foreach (var error in repositoryResponse.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }

                        return View(article);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BEArticleViewModel.Repository.CheckIsExists(m => m.Id == article.Id))
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
            return View(article);
        }

        [HttpGet]
        [Route("Recycle/{id}")]
        public async Task<IActionResult> Recycle(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var infoArticleViewModel = getArticle.Data;
                infoArticleViewModel.Status = SWStatus.Deleted;
                var result = await infoArticleViewModel.SaveModelAsync().ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
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

        [HttpGet]
        [Route("Restore/{id}")]
        public async Task<IActionResult> Restore(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var infoArticleViewModel = getArticle.Data;
                infoArticleViewModel.Status = SWStatus.Preview;
                var result = await infoArticleViewModel.SaveModelAsync().ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Draft");
                }
                else
                {
                    return RedirectToAction("Draft");
                }
            }
            else
            {
                return RedirectToAction("Draft");
            }
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var getArticle = await BEArticleViewModel.Repository.GetSingleModelAsync(m => m.Id == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            if (getArticle.IsSucceed)
            {
                await getArticle.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            return RedirectToAction("Draft", "Articles");
        }
    }
}
