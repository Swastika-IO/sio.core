// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Identity.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Cms.Mvc.Controllers
{
    //[ServiceFilter(typeof(Lib.Attributes.LanguageActionFilter))]
    [ResponseCache(CacheProfileName = "Default")]
    [Route("{culture}")]
    public class HomeController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(IHostingEnvironment env,
             UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
            : base(env)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        [Route("alias")]
        public async Task<IActionResult> Alias(string alias, int pageIndex, int pageSize = 10)
        {
            // Home Page
            if (!string.IsNullOrEmpty(alias))
            {
                var getAlias = await ApiUrlAliasViewModel.Repository.GetSingleModelAsync(u => u.Alias == alias && u.Specificulture == CurrentLanguage);
                if (getAlias.IsSucceed)
                {
                    switch (getAlias.Data.Type)
                    {
                        case SWCmsConstants.UrlAliasType.Page:
                            int.TryParse(getAlias.Data.SourceId, out int pageId);
                            return Page(p => p.Specificulture == CurrentLanguage && p.Id == pageId, pageIndex, pageSize);
                        case SWCmsConstants.UrlAliasType.Article:
                            return ArticleView(getAlias.Data.SourceId);
                        case SWCmsConstants.UrlAliasType.Product:
                            return ProductView(getAlias.Data.SourceId);
                        case SWCmsConstants.UrlAliasType.Module:
                        case SWCmsConstants.UrlAliasType.ModuleData:
                        default:
                            return RedirectToAction("Index", "Backend");
                    }

                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return Page(p => p.Specificulture == CurrentLanguage && (p.Type == (int)SWCmsConstants.CateType.Home), pageIndex, pageSize);
            }

        }

        IActionResult Page(Expression<Func<SiocCategory, bool>> predicate, int pageIndex, int pageSize = 10)
        {
            // Home Page
            var getPage = FECategoryViewModel.Repository.GetSingleModel(predicate);

            if (getPage.IsSucceed && getPage.Data.View != null)
            {
                GeneratePageDetailsUrls(getPage.Data);
                ViewData["Title"] = getPage.Data.Title;
                ViewData["Description"] = getPage.Data.Excerpt;
                ViewData["Image"] = getPage.Data.ImageUrl;
                ViewData["PageClass"] = getPage.Data.CssClass;
                return View(getPage.Data);
            }
            else
            {
                return RedirectToAction("Index", "Backend");
            }
        }

        IActionResult ArticleView(string id)
        {
            var getArticle = FEArticleViewModel.Repository.GetSingleModel(
                a => a.Id == id && a.Specificulture == CurrentLanguage);
            if (getArticle.IsSucceed)
            {
                ViewData["Title"] = getArticle.Data.Title;
                ViewData["Description"] = getArticle.Data.Excerpt;
                ViewData["Image"] = getArticle.Data.ImageUrl;
                return View(getArticle.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", CurrentLanguage));
            }
        }

        IActionResult ProductView(string id)
        {
            var getProduct = FEProductViewModel.Repository.GetSingleModel(
                a => a.Id == id && a.Specificulture == CurrentLanguage);
            if (getProduct.IsSucceed)
            {
                ViewData["Title"] = getProduct.Data.Title;
                ViewData["Description"] = getProduct.Data.Excerpt;
                ViewData["Image"] = getProduct.Data.ImageUrl;
                return View(getProduct.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", CurrentLanguage));
            }
        }

        void GeneratePageDetailsUrls(FECategoryViewModel page)
        {
            foreach (var articleNav in page.Articles.Items)
            {
                articleNav.Article.DetailsUrl = GenerateDetailsUrl("Alias", new { seoName = articleNav.Article.UrlAlias.Alias });
            }

            foreach (var productNav in page.Products.Items)
            {
                productNav.Product.DetailsUrl = GenerateDetailsUrl("Alias", new { seoName = productNav.Product.UrlAlias.Alias });
            }

            foreach (var nav in page.Modules)
            {
                var module = nav.Module;
                module.DetailsUrl = GenerateDetailsUrl("Alias", new { seoName = module.UrlAlias.Alias });
                GeneratePageDetailsUrls(module);
            }
        }

        void GeneratePageDetailsUrls(FEModuleViewModel module)
        {
            foreach (var articleNav in module.Articles.Items)
            {
                articleNav.Article.DetailsUrl = GenerateDetailsUrl("Alias", new { seoName = articleNav.Article.UrlAlias.Alias });
            }

            foreach (var productNav in module.Products.Items)
            {
                productNav.Product.DetailsUrl = GenerateDetailsUrl("Alias", new { seoName = productNav.Product.UrlAlias.Alias });
            }
        }

        string GenerateDetailsUrl(string type, object routeValues)
        {
            return SwCmsHelper.GetRouterUrl(type, routeValues, Request, Url);
        }

        [HttpGet]
        [Route("List/{pageName}")]
        [Route("List/{pageName}/{pageIndex:int?}")]
        [Route("List/{pageName}/{pageSize:int?}/{pageIndex:int?}")]
        public IActionResult List(string pageName, int pageIndex = 0, int pageSize = 10)
        {
            var getPage = FECategoryViewModel.Repository.GetSingleModel(
                p => p.Type == (int)SWCmsConstants.CateType.Home && p.Specificulture == CurrentLanguage);
            if (getPage.IsSucceed)
            {
                return View(getPage.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", CurrentLanguage));
            }
        }

        [Route("Search")]
        [Route("Search/{keyword}")]
        [Route("Search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [HttpPost, HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> Search(int pageIndex = 0, int pageSize = 10, string keyword = null)
        {
            var getArticles = await InfoArticleViewModel.Repository.GetModelListByAsync(
               article => article.Specificulture == CurrentLanguage
                   && article.Status != (int)SWStatus.Deleted
                   && (
                        string.IsNullOrEmpty(keyword) || article.Title.Contains(keyword)
                        || (article.Excerpt != null && article.Excerpt.Contains(keyword))
                        ),
               "CreatedDateTime", OrderByDirection.Descending,
               pageSize, pageIndex);
            var getProducts = await InfoProductViewModel.Repository.GetModelListByAsync(
               Product => Product.Specificulture == CurrentLanguage
                   && Product.Status != (int)SWStatus.Deleted
                   && (
                        string.IsNullOrEmpty(keyword) || Product.Title.Contains(keyword)
                        || (Product.Excerpt != null && Product.Excerpt.Contains(keyword))
                        ),
               "CreatedDateTime", OrderByDirection.Descending,
               pageSize, pageIndex);
            ViewData["Products"] = getProducts.Data;
            return View(getArticles.Data);
        }

        [HttpGet]
        [Route("Tag/{keyword}")]
        [Route("Tag/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [HttpPost, HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> Tag(int pageIndex = 0, int pageSize = 10, string keyword = null)
        {
            var getArticles = await InfoArticleViewModel.Repository.GetModelListByAsync(
               cate => cate.Specificulture == CurrentLanguage
                   && cate.Status != (int)SWStatus.Deleted
                   && (string.IsNullOrEmpty(keyword) || cate.Tags.Contains(keyword)),
               "CreatedDateTime", OrderByDirection.Descending,
               pageSize, pageIndex);
            var getProducts = await InfoProductViewModel.Repository.GetModelListByAsync(
               Product => Product.Specificulture == CurrentLanguage
                   && Product.Status != (int)SWStatus.Deleted
                   && (
                        string.IsNullOrEmpty(keyword) || Product.Tags.Contains(keyword)
                        ),
               "CreatedDateTime", OrderByDirection.Descending,
               pageSize, pageIndex);
            ViewData["Products"] = getProducts.Data;
            return View(getArticles.Data);
        }

        [HttpGet]
        [Route("article/{SeoName}")]
        [Route("article/{CateSeoName}/{SeoName}")]
        public IActionResult ArticleDetails(string SeoName, string CateSeoName = null)
        {
            var getArticle = FEArticleViewModel.Repository.GetSingleModel(
                a => a.SeoName == SeoName && a.Specificulture == CurrentLanguage);
            ViewData["CateSeoName"] = CateSeoName;
            if (getArticle.IsSucceed)
            {
                return View(getArticle.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", CurrentLanguage));
            }
        }

        [HttpGet]
        [Route("product/{SeoName}")]
        [Route("product/{CateSeoName}/{SeoName}")]
        public IActionResult ProductDetails(string SeoName, string CateSeoName = null)
        {
            var getProduct = FEProductViewModel.Repository.GetSingleModel(
                a => a.SeoName == SeoName && a.Specificulture == CurrentLanguage);
            ViewData["CateSeoName"] = CateSeoName;
            if (getProduct.IsSucceed)
            {
                return View(getProduct.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", CurrentLanguage));
            }
        }

    }
}
