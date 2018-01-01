using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.Data.OData.Query;
using Swastika.IO.Domain.Core.ViewModels;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.BackEnd;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Policy ="AddEditUser")]
    [Area("Portal")]
    [Route("{culture}/Portal/Articles")]
    public class ArticlesController : BaseController<ArticlesController>
    {

        public ArticlesController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> portalLocalizer, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
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
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            RepositoryResponse<PaginationModel<InfoArticleViewModel>> getArticles = 
                await InfoArticleViewModel.Repository.GetModelListByAsync(
                article => article.Specificulture == _lang
                    && !article.IsDeleted
                    && (string.IsNullOrEmpty(keyword) || article.Title.Contains(keyword)),
                "Priority", OrderByDirection.Ascending
                , pageSize, pageIndex);
            ViewBag.keyword = keyword;
            return View(getArticles.Data);
        }

        // GET: Portal/Articles/Draft
        [Route("Draft")]
        [Route("Draft/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Draft(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var getArticles = await InfoArticleViewModel.Repository.GetModelListByAsync(
                article => article.Specificulture == _lang &&
                    (string.IsNullOrEmpty(keyword) || article.Title.Contains(keyword))
                    && article.IsDeleted,
                "CreatedDateTime", OrderByDirection.Descending,
                pageSize, pageIndex);

            return View(getArticles.Data);
        }

        // GET: Portal/Articles/Create
        [Route("Create")]
        [Route("Create/{categoryId:int}")]
        public IActionResult Create(int? categoryId = null)
        {           
            var vmArticle = new BEArticleViewModel( new SiocArticle() 
            {
                IsVisible = true,
                Specificulture = _lang,              
                CreatedBy = User.Identity.Name,
                CreatedDateTime = DateTime.UtcNow
            });
            if (categoryId.HasValue)
            {
                var activeCate = vmArticle.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                if (activeCate != null)
                {
                    activeCate.IsActived = true;
                }
            }
            ViewBag.categoryId = categoryId;
            return View(vmArticle);
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
                var result = await article.SaveModelAsync(true);
                if (result.IsSucceed)
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
        [Route("Edit/{id}")]
        [Route("Edit/{id}/{categoryId:int}")]
        public async Task<IActionResult> Edit(string id = null, int? categoryId = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var article =  await BEArticleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == id && m.Specificulture == _lang);
            if (article == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = categoryId;
            return View(article.Data);
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
                    var result = await article.SaveModelAsync();
                    if (result.IsSucceed)
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
                        ModelState.AddModelError(string.Empty, result.Exception.Message);
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

        [Route("Recycle/{id}")]
        public async Task<IActionResult> Recycle(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.IsDeleted = true;
                var result = await data.SaveModelAsync();
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

        [Route("Restore/{id}")]
        public async Task<IActionResult> Restore(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.IsDeleted = false;
                var result = await data.SaveModelAsync();
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


        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var getArticle = await BEArticleViewModel.Repository.GetSingleModelAsync(m => m.Id == id && m.Specificulture == _lang);
            if (getArticle.IsSucceed)
            {
                await getArticle.Data.RemoveModelAsync(true);
            }
            return RedirectToAction("Draft","Articles");
        }
    }
}
