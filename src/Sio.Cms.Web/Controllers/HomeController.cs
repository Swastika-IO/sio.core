using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            ViewData["TopPages"] = GetCategory(CatePosition.Nav, seoName);
            ViewData["HeaderPages"] = GetCategory(CatePosition.Top, seoName);
            ViewData["FooterPages"] = GetCategory(CatePosition.Footer, seoName);
            ViewData["LeftPages"] = GetCategory(CatePosition.Left, seoName);
            // Home Page
            int.TryParse(Request.Query["pageSize"], out int pageSize);
            int.TryParse(Request.Query["pageIndex"], out int pageIndex);
            var getPage = new RepositoryResponse<Lib.ViewModels.SioPages.ReadMvcViewModel>();
            var cacheKey = $"page_{_culture}_{seoName}_{pageSize}_{pageIndex}";

            var data = _memoryCache.Get<Lib.ViewModels.SioPages.ReadMvcViewModel>(cacheKey);
            if (data != null && SioService.GetConfig<bool>("IsCache"))
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
                if (getPage.Data != null)
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
                getPage.LastUpdateConfiguration = SioService.GetConfig<DateTime?>("LastUpdateConfiguration");
                return View(getPage.Data);
            }
            else
            {
                return NotFound();
            }
        }

        async System.Threading.Tasks.Task<IActionResult> ArticleViewAsync(string seoName)
        {
            ViewData["TopPages"] = GetCategory(CatePosition.Nav, seoName);
            ViewData["HeaderPages"] = GetCategory(CatePosition.Top, seoName);
            ViewData["FooterPages"] = GetCategory(CatePosition.Footer, seoName);
            ViewData["LeftPages"] = GetCategory(CatePosition.Left, seoName);
            var getArticle = new RepositoryResponse<Lib.ViewModels.SioArticles.ReadMvcViewModel>();

            var cacheKey = $"article_{_culture}_{seoName}";

            var data = _memoryCache.Get<Lib.ViewModels.SioArticles.ReadMvcViewModel>(cacheKey);
            if (data != null && SioService.GetConfig<bool>("IsCache"))
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
                getArticle.LastUpdateConfiguration = SioService.GetConfig<DateTime?>("LastUpdateConfiguration");
                return View(getArticle.Data);
            }
            else
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        async System.Threading.Tasks.Task<IActionResult> ProductViewAsync(string seoName)
        {
            ViewData["TopPages"] = GetCategory(CatePosition.Nav, seoName);
            ViewData["HeaderPages"] = GetCategory(CatePosition.Top, seoName);
            ViewData["FooterPages"] = GetCategory(CatePosition.Footer, seoName);
            ViewData["LeftPages"] = GetCategory(CatePosition.Left, seoName);
            var getProduct = new RepositoryResponse<Lib.ViewModels.SioProducts.ReadMvcViewModel>();

            var cacheKey = $"product_{_culture}_{seoName}";

            var data = _memoryCache.Get<Lib.ViewModels.SioProducts.ReadMvcViewModel>(cacheKey);
            if (data != null && SioService.GetConfig<bool>("IsCache"))
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
                getProduct.LastUpdateConfiguration = SioService.GetConfig<DateTime?>("LastUpdateConfiguration");
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
            if (module.Articles != null)
            {

                foreach (var articleNav in module.Articles.Items)
                {
                    if (articleNav.Article != null)
                    {
                        articleNav.Article.DetailsUrl = GenerateDetailsUrl("Article", new { seoName = articleNav.Article.SeoName });
                    }
                }
            }
            if (module.Products != null)
            {

                foreach (var productNav in module.Products.Items)
                {
                    if (productNav.Product != null)
                    {
                        productNav.Product.DetailsUrl = GenerateDetailsUrl("Product", new { seoName = productNav.Product.SeoName });
                    }
                }
            }
        }

        string GenerateDetailsUrl(string type, object routeValues)
        {
            return SioCmsHelper.GetRouterUrl(type, routeValues, Request, Url);
        }

        List<Lib.ViewModels.SioPages.ReadListItemViewModel> GetCategory(SioEnums.CatePosition position, string seoName)
        {
            var result = new List<Lib.ViewModels.SioPages.ReadListItemViewModel>();
            var cacheKey = $"page_position_{position}";

            var data = _memoryCache.Get<List<Lib.ViewModels.SioPages.ReadListItemViewModel>>(cacheKey);
            if (data != null && SioService.GetConfig<bool>("IsCache"))
            {
                result = data;
            }
            else
            {
                var getTopCates = Lib.ViewModels.SioPages.ReadListItemViewModel.Repository.GetModelListBy
            (c => c.Specificulture == _culture && c.SioPagePosition.Any(
              p => p.PositionId == (int)position)
            );

                result = getTopCates.Data ?? new List<Lib.ViewModels.SioPages.ReadListItemViewModel>();
                foreach (var cate in result)
                {
                    switch (cate.Type)
                    {
                        case SioPageType.Blank:
                            foreach (var child in cate.Childs)
                            {
                                child.Page.DetailsUrl = GenerateDetailsUrl("Page", new { seoName = child.Page.SeoName });
                            }
                            break;

                        case SioPageType.StaticUrl:
                            cate.DetailsUrl = cate.StaticUrl;
                            break;

                        case SioPageType.Home:
                        case SioPageType.ListArticle:
                        case SioPageType.Article:
                        case SioPageType.Modules:
                        default:
                            cate.DetailsUrl = GenerateDetailsUrl("Page", new { seoName = cate.SeoName });
                            break;
                    }
                }

            }

            foreach (var cate in result)
            {
                cate.IsActived = (cate.SeoName == seoName
                    || (cate.Type == SioPageType.Home && string.IsNullOrEmpty(seoName)));
                cate.Childs.ForEach((Action<Lib.ViewModels.SioPagePages.ReadViewModel>)(c =>
                {
                    c.IsActived = (
                    c.Page.SeoName == seoName);
                    cate.IsActived = cate.IsActived || c.IsActived;
                }));
            }
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
