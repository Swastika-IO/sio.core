using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.Services;

namespace Swastika.Cms.Mvc.Controllers
{

    //[ServiceFilter(typeof(Lib.Attributes.LanguageActionFilter))]
    [ResponseCache(CacheProfileName = "Default")]
    [Route("{culture}")]
    public class HomeController : BaseController<HomeController>
    {
        
        //private readonly string lang;
        //private readonly IStringLocalizer<HomeController> _homeLocalizer;
        //private readonly IStringLocalizer<SharedResource> _localizer;
        //private readonly GlobalConfigurationService _appService;
        public HomeController(IHostingEnvironment env
            //, IStringLocalizer<HomeController> homeLocalizer
            //, IStringLocalizer<SharedResource> localizer
            //, GlobalConfigurationService service
            )
            : base(env)
        {
            //_localizer = localizer;
            //_homeLocalizer = homeLocalizer;
            //_appService = service;
           
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        [Route("")]
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
                //CategoryViewModel page = CategoryRepository.GetInstance().GetFEHomeModel(p => p.Type == (int)SWCmsConstants.CateType.Home && p.Specificulture == _lang);
                var getPage = FECategoryViewModel.Repository.GetSingleModel(p => p.Type == (int)SWCmsConstants.CateType.Home && p.Specificulture == _lang);
                if (getPage.IsSucceed && getPage.Data.View!=null)
                {
                    ViewBag.pageClass = getPage.Data.CssClass;
                    return View(getPage.Data);
                }
                else
                {
                    return RedirectToAction("Index", "Portal", new { culture = _lang});
                }                
            }
            else
            {
                var getPage = FECategoryViewModel.Repository.GetSingleModel(
                    p => p.SeoName == pageName && p.Specificulture == _lang);
                if (getPage.IsSucceed && getPage.Data.View != null)
                {
                    ViewBag.pageClass = getPage.Data.CssClass;
                    return View(getPage.Data);
                }
                else
                {
                    return Redirect(string.Format("/{0}", _lang));
                }
                
            }

        }

        [Route("List/{pageName}")]
        [Route("List/{pageName}/{pageIndex:int?}")]
        [Route("List/{pageName}/{pageSize:int?}/{pageIndex:int?}")]
        public IActionResult List(string pageName, int pageIndex = 0, int pageSize = 10)
        {
            var getPage = FECategoryViewModel.Repository.GetSingleModel(
                p => p.Type == (int)SWCmsConstants.CateType.Home && p.Specificulture == _lang);
            //= CategoryRepository.GetInstance().GetFEListModel(p => p.SeoTitle == pageName && p.Specificulture == _lang, _lang, pageSize, pageIndex);
            if (getPage.IsSucceed)
            {
                return View(getPage.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", _lang));
            }
            
        }
        [Route("Search")]
        [Route("Search/{keyword}")]
        [Route("Search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [HttpPost, HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> Search(int pageIndex = 0, int pageSize = 10, string keyword = null)
        {
            //List<FECategoryViewModel> categories = new List<FECategoryViewModel>();
            //if (pageIndex == 0)
            //{
            //    categories = await FECategoryViewModel.Repository.GetModelListByAsync(
            //        cate => cate.Specificulture == _lang
            //       && !cate.IsDeleted
            //       && cate.Type== (int)SWCmsConstants.CateType.Article
            //       && (string.IsNullOrEmpty(keyword) || cate.Title.Contains(keyword) || cate.FullContent.Contains(keyword))
            //        );
            //}
            var getArticles = await InfoArticleViewModel.Repository.GetModelListByAsync(
               article => article.Specificulture == _lang
                   && !article.IsDeleted
                   && ( 
                        string.IsNullOrEmpty(keyword) || article.Title.Contains(keyword) 
                        || (article.Excerpt !=null &&  article.Excerpt.Contains(keyword))
                        ),
               "CreatedDateTime", OrderByDirection.Descending,
               pageSize, pageIndex);
            //ViewData["Categories"] = categories;
            return View(getArticles.Data);
        }

        [Route("Tag/{keyword}")]
        [Route("Tag/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [HttpPost, HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> Tag(int pageIndex = 0, int pageSize = 10, string keyword = null)
        {
            //List<FECategoryViewModel> categories = new List<FECategoryViewModel>();
            //if (pageIndex == 0)
            //{
            //    categories = await FECategoryViewModel.Repository.GetModelListByAsync(
            //        cate => cate.Specificulture == _lang
            //       && !cate.IsDeleted
            //       && (string.IsNullOrEmpty(keyword) || cate.Tags.Contains(keyword))
            //        );
            //}
            var getArticles = await InfoArticleViewModel.Repository.GetModelListByAsync(
               cate => cate.Specificulture == _lang
                   && !cate.IsDeleted
                   && (string.IsNullOrEmpty(keyword) || cate.Tags.Contains(keyword)),
               "CreatedDateTime", OrderByDirection.Descending,
               pageSize, pageIndex);
            //ViewData["Categories"] = categories;
            return View(getArticles.Data);
        }

        [Route("page/{pageName}")]
        public IActionResult Article(string pageName)
        {
            var getPage = FECategoryViewModel.Repository.GetSingleModel(
                p => p.Type == (int)SWCmsConstants.CateType.Home && p.Specificulture == _lang);
            //CategoryRepository.GetInstance().GetFEHomeModel(p => p.SeoTitle == pageName && p.Specificulture == _lang);
            if (getPage.IsSucceed)
            {
                return View(getPage.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", _lang));
            }
        }

        [Route("article/{SeoName}")]
        public IActionResult ArticleDetails(string SeoName)
        {
            var getArticle = FEArticleViewModel.Repository.GetSingleModel(
                a => a.SeoName == SeoName && a.Specificulture == _lang);
            //ArticleRepository.GetInstance().GetSingleModel(a => a.Id == id && a.Specificulture == _lang, SWCmsConstants.ViewModelType.FrontEnd);
            if (getArticle.IsSucceed)
            {
                return View(getArticle.Data);
            }
            else
            {
                return Redirect(string.Format("/{0}", _lang));
            }            
        }

    }
}
