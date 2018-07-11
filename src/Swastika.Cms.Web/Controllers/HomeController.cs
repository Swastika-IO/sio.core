using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Web.Models;
using Swastika.Cms.Lib.Services;
using Microsoft.AspNetCore.Identity;
using Swastika.Identity.Models;
using Microsoft.AspNetCore.Hosting;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib.ViewModels.Info;
using static Swastika.Common.Utility.Enums;
using Swastika.Cms.Lib;

namespace Swastika.Cms.Web.Controllers
{
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
        [Route("")]
        [Route("{culture}")]
        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(GlobalConfigurationService.Instance.GetConfigConnectionKey()))
            {
                return RedirectToAction("Init", "Portal");
            }
            else
            {
                var superAdmin = await _userManager.GetUsersInRoleAsync("SuperAdmin");
                if (superAdmin.Count == 0)
                {
                    return Redirect($"/{ROUTE_DEFAULT_CULTURE}/Portal/Auth/RegisterSuperAdmin");
                }
                else
                {
                    GlobalConfigurationService.Instance.IsInit = true;
                    GlobalConfigurationService.Instance.Refresh();
                    return Redirect($"/{ROUTE_DEFAULT_CULTURE}/Home");
                }
            }
        }

        [HttpGet]
        [Route("Home")]
        [Route("{pageName}")]
        //[Route("Index")]
        //[Route("{pageName}")]
        [Route("{pageName}/{pageIndex:int?}")]
        [Route("{pageName}/{pageSize:int?}/{pageIndex:int?}")]
        public IActionResult Home(string pageName, int pageIndex, int pageSize = 10)
        {
            // Home Page
            if (string.IsNullOrEmpty(pageName) || pageName == "Home")
            {
                var getPage = FECategoryViewModel.Repository.GetSingleModel(p => p.Type == (int)SWCmsConstants.CateType.Home && p.Specificulture == CurrentLanguage);
                if (getPage.IsSucceed && getPage.Data.View != null)
                {
                    ViewBag.pageClass = getPage.Data.CssClass;
                    return View(getPage.Data);
                }
                else
                {
                    return RedirectToAction("Index", "Portal", new { culture = CurrentLanguage });
                }
            }
            else
            {
                var getPage = FECategoryViewModel.Repository.GetSingleModel(
                    p => p.SeoName == pageName && p.Specificulture == CurrentLanguage);
                if (getPage.IsSucceed && getPage.Data.View != null)
                {
                    if (getPage.Data.Type == SWCmsConstants.CateType.List)
                    {
                        getPage.Data.Articles.Items.ForEach(a =>
                        {
                            a.Article.DetailsUrl = SwCmsHelper.GetRouterUrl("Article", new { a.Article.SeoName }, Request, Url);
                        });
                    }
                    if (getPage.Data.Type == SWCmsConstants.CateType.ListProduct)
                    {
                        getPage.Data.Products.Items.ForEach(p =>
                        {
                            p.Product.DetailsUrl = SwCmsHelper.GetRouterUrl("Product", new { p.Product.SeoName }, Request, Url);
                        });
                    }
                    ViewBag.pageClass = getPage.Data.CssClass;
                    return View(getPage.Data);
                }
                else
                {
                    return Redirect(string.Format("/{0}", CurrentLanguage));
                }
            }
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
        [Route("page/{pageName}")]
        public IActionResult Article(string pageName)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
