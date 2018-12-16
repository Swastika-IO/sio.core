using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Sio.Cms.Lib;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Cms.Web.Models;
using Sio.Domain.Core.ViewModels;
using Sio.Identity.Models;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApiDescriptionGroupCollectionProvider _apiExplorer;
        public HomeController(IHostingEnvironment env,
            IMemoryCache memoryCache,
             UserManager<ApplicationUser> userManager,
             IApiDescriptionGroupCollectionProvider apiExplorer
            ) : base(env, memoryCache)
        {
            this._userManager = userManager;
            _apiExplorer = apiExplorer;
        }
        [Route("doc")]
        public IActionResult Documentation()
        {
            return View(_apiExplorer);
        }

        [Route("")]
        [Route("{culture}")]
        [Route("{culture}/{seoName}")]
        public async System.Threading.Tasks.Task<IActionResult> Index(
            string culture, string seoName)
        {
            if (SioService.GetConfig<bool>("IsInit"))
            {
                //Go to landing page
                return await PageAsync(seoName);
            }
            else
            {
                if (string.IsNullOrEmpty(SioService.GetConnectionString(SioConstants.CONST_CMS_CONNECTION)))
                {
                    return Redirect("Init");
                }
                else
                {
                    return Redirect($"/init/step2");
                }
            }
        }

        [Route("article/{seoName}")]
        [Route("{culture}/article/{seoName}")]
        public async System.Threading.Tasks.Task<IActionResult> Article(string culture, string seoName)
        {
            return await ArticleViewAsync(seoName);
        }

        [Route("product/{seoName}")]
        [Route("{culture}/product/{seoName}")]
        public async System.Threading.Tasks.Task<IActionResult> Product(string culture, string seoName)
        {
            return await ProductViewAsync(seoName);
        }

        [HttpGet]
        [Route("portal")]
        [Route("admin")]
        [Route("portal/{pageName}")]
        [Route("portal/{pageName}/{type}")]
        [Route("portal/{pageName}/{type}/{param}")]
        [Route("portal/{pageName}/{type}/{param}/{param1}")]
        [Route("portal/{pageName}/{type}/{param}/{param1}/{param2}")]
        [Route("portal/{pageName}/{type}/{param}/{param1}/{param2}/{param3}")]
        [Route("portal/{pageName}/{type}/{param}/{param1}/{param2}/{param3}/{param4}")]
        public IActionResult Portal()
        {
            return View();
        }

        [HttpGet]
        [Route("init")]
        [Route("init/{page}")]
        public IActionResult Init(string page)
        {
            if (string.IsNullOrEmpty(page) && SioService.GetConfig<bool>("IsInit"))
            {
                return Redirect($"/init/login");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        [Route("404")]
        public async System.Threading.Tasks.Task<IActionResult> PageNotFound()
        {
            return await PageAsync("404");
        }

        async System.Threading.Tasks.Task<IActionResult> PageAsync(string seoName)//Expression<Func<SioPage, bool>> predicate, int? pageIndex = null, int pageSize = 10)
        {
            // Home Page
            int.TryParse(Request.Query["pageSize"], out int pageSize);
            int.TryParse(Request.Query["pageIndex"], out int pageIndex);
            var getPage = new RepositoryResponse<Lib.ViewModels.SioPages.ReadMvcViewModel>();

            var cacheKey = $"page_{_culture}_{seoName}_{pageSize}_{pageIndex}";

            var data = _memoryCache.Get<Lib.ViewModels.SioPages.ReadMvcViewModel>(cacheKey);
            if (data != null)
            {
                getPage.IsSucceed = true;
                getPage.Data = data;
            }
            else
            {
                Expression<Func<SioPage, bool>> predicate;
                if (string.IsNullOrEmpty(seoName))
                {
                    predicate = p =>
                    p.Type == (int)SioPageType.Home
                    && p.Status == (int)SioContentStatus.Published && p.Specificulture == _culture;
                }
                else
                {
                    predicate = p =>
                    p.SeoName == seoName
                    && p.Status == (int)SioContentStatus.Published && p.Specificulture == _culture;
                }

                getPage = await Lib.ViewModels.SioPages.ReadMvcViewModel.Repository.GetSingleModelAsync(predicate);
                if (getPage.Data!=null)
                {
                    getPage.Data.LoadData(pageIndex: pageIndex, pageSize: pageSize);
                }
                _memoryCache.Set(cacheKey, getPage.Data);
                if (!SioConstants.cachedKeys.Contains(cacheKey))
                {
                    SioConstants.cachedKeys.Add(cacheKey);
                }
            }

            if (getPage.IsSucceed && getPage.Data.View != null)
            {
                GeneratePageDetailsUrls(getPage.Data);
                if (!SioConstants.cachedKeys.Contains(cacheKey))
                {
                    SioConstants.cachedKeys.Add(cacheKey);
                }
                ViewData["Title"] = getPage.Data.SeoTitle;
                ViewData["Description"] = getPage.Data.SeoDescription;
                ViewData["Keywords"] = getPage.Data.SeoKeywords;
                ViewData["Image"] = getPage.Data.ImageUrl;
                ViewData["PageClass"] = getPage.Data.CssClass;
                return View(getPage.Data);
            }
            else
            {
                return NotFound();
            }
        }

        async System.Threading.Tasks.Task<IActionResult> ArticleViewAsync(string seoName)
        {

            var getArticle = new RepositoryResponse<Lib.ViewModels.SioArticles.ReadMvcViewModel>();

            var cacheKey = $"article_{_culture}_{seoName}";

            var data = _memoryCache.Get<Lib.ViewModels.SioArticles.ReadMvcViewModel>(cacheKey);
            if (data != null)
            {
                getArticle.IsSucceed = true;
                getArticle.Data = data;
            }
            else
            {
                Expression<Func<SioArticle, bool>> predicate;
                if (string.IsNullOrEmpty(seoName))
                {
                    predicate = p =>
                    p.Type == (int)SioPageType.Home
                    && p.Status == (int)SioContentStatus.Published && p.Specificulture == _culture;
                }
                else
                {
                    predicate = p =>
                    p.SeoName == seoName
                    && p.Status == (int)SioContentStatus.Published && p.Specificulture == _culture;
                }

                getArticle = await Lib.ViewModels.SioArticles.ReadMvcViewModel.Repository.GetSingleModelAsync(predicate);
                _memoryCache.Set(cacheKey, getArticle.Data);
                if (!SioConstants.cachedKeys.Contains(cacheKey))
                {
                    SioConstants.cachedKeys.Add(cacheKey);
                }

            }

            if (getArticle.IsSucceed)
            {
                ViewData["Title"] = getArticle.Data.SeoTitle;
                ViewData["Description"] = getArticle.Data.SeoDescription;
                ViewData["Keywords"] = getArticle.Data.SeoKeywords;
                ViewData["Image"] = getArticle.Data.ImageUrl;
                return View(getArticle.Data);
            }
            else
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        async System.Threading.Tasks.Task<IActionResult> ProductViewAsync(string seoName)
        {
            var getProduct = new RepositoryResponse<Lib.ViewModels.SioProducts.ReadMvcViewModel>();

            var cacheKey = $"product_{_culture}_{seoName}";

            var data = _memoryCache.Get<Lib.ViewModels.SioProducts.ReadMvcViewModel>(cacheKey);
            if (data != null)
            {
                getProduct.IsSucceed = true;
                getProduct.Data = data;
            }
            else
            {
                Expression<Func<SioProduct, bool>> predicate;
                if (string.IsNullOrEmpty(seoName))
                {
                    predicate = p =>
                    p.Type == (int)SioPageType.Home
                    && p.Status == (int)SioContentStatus.Published && p.Specificulture == _culture;
                }
                else
                {
                    predicate = p =>
                    p.SeoName == seoName
                    && p.Status == (int)SioContentStatus.Published && p.Specificulture == _culture;
                }

                getProduct = await Lib.ViewModels.SioProducts.ReadMvcViewModel.Repository.GetSingleModelAsync(predicate);
                _memoryCache.Set(cacheKey, getProduct.Data);
                if (!SioConstants.cachedKeys.Contains(cacheKey))
                {
                    SioConstants.cachedKeys.Add(cacheKey);
                }

            }

            if (getProduct.IsSucceed)
            {
                ViewData["Title"] = getProduct.Data.SeoTitle;
                ViewData["Description"] = getProduct.Data.SeoDescription;
                ViewData["Keywords"] = getProduct.Data.SeoKeywords;
                ViewData["Image"] = getProduct.Data.ImageUrl;
                return View(getProduct.Data);
            }
            else
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        void GeneratePageDetailsUrls(Lib.ViewModels.SioPages.ReadMvcViewModel page)
        {
            if (page.Articles != null)
            {
                foreach (var articleNav in page.Articles.Items)
                {
                    if (articleNav.Article != null)
                    {
                        articleNav.Article.DetailsUrl = GenerateDetailsUrl("Article", new { seoName = articleNav.Article.SeoName });
                    }
                }
            }

            if (page.Products != null)
            {
                foreach (var productNav in page.Products.Items)
                {
                    if (productNav.Product != null)
                    {
                        productNav.Product.DetailsUrl = GenerateDetailsUrl("Product", new { seoName = productNav.Product.SeoName });
                    }
                }
            }

            if (page.Modules != null)
            {
                foreach (var nav in page.Modules)
                {
                    GeneratePageDetailsUrls(nav.Module);
                }
            }
        }

        void GeneratePageDetailsUrls(Lib.ViewModels.SioModules.ReadMvcViewModel module)
        {
            foreach (var articleNav in module.Articles.Items)
            {
                if (articleNav.Article != null)
                {
                    articleNav.Article.DetailsUrl = GenerateDetailsUrl("Article", new { seoName = articleNav.Article.SeoName });
                }
            }

            foreach (var productNav in module.Products.Items)
            {
                if (productNav.Product != null)
                {
                    productNav.Product.DetailsUrl = GenerateDetailsUrl("Product", new { seoName = productNav.Product.SeoName });
                }
            }
        }

        string GenerateDetailsUrl(string type, object routeValues)
        {
            return SioCmsHelper.GetRouterUrl(type, routeValues, Request, Url);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
