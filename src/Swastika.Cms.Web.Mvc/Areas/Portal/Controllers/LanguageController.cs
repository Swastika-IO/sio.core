using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;

namespace Swastika.Cms.Web.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/language")]
    public class LanguageController : BaseController<LanguageController>
    {
        //private readonly GlobalConfigurationService _appService;
        public LanguageController(IHostingEnvironment env
            //, IStringLocalizer<SharedResource> localizer
            //, GlobalConfigurationService service
            )
            : base(env)
        {
            //_appService = service;
        }


        #region Languages
        [HttpGet]
        [Route("")]
        [Route("Languages")]
        [Route("generals")]
        public IActionResult Languages()
        {
            PaginationModel<BELanguageViewModel> pagingPages = new PaginationModel<BELanguageViewModel>()
            {
                Items = GlobalLanguageService.ListLanguage.Where(m => m.Specificulture == _lang).ToList(),
                PageIndex = 0,
                PageSize = GlobalLanguageService.ListLanguage.Count(m => m.Specificulture == _lang),
                TotalItems = GlobalLanguageService.ListLanguage.Count(m => m.Specificulture == _lang),
                TotalPage = 1
            };
            //  await LanguageRepository.GetInstance().GetModelListByAsync(m=> m.Specificulture == _lang,
            //cate => cate.Description, "desc",
            //pageSize, pageIndex, Swastika.Cms.Lib.SWCmsConstants.ViewModelType.FrontEnd);
            return View(pagingPages);
        }
        // GET: Language/Create
        [HttpGet]
        [Route("Languages/Create")]
        public IActionResult CreateLanguage()
        {
            BELanguageViewModel ttsLanguage = new BELanguageViewModel(
                new SiocLanguage()
                {
                    //Id = LanguageRepository.GetInstance().GetNextId()
                    Specificulture = _lang
                });
            return View(ttsLanguage);
        }

        // POST: Language/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Languages/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLanguage(BELanguageViewModel ttsLanguage)
        {
            if (ModelState.IsValid)
            {
                var result = await ttsLanguage.SaveModelAsync();// BELanguageViewModel.Repository.CreateModelAsync(ttsLanguage);
                if (result.IsSucceed)
                {
                    GlobalLanguageService.Instance.Refresh();
                    return RedirectToAction("Languages");
                }
                else
                {
                    return View(ttsLanguage);
                }
            }
            else
            {
                return View(ttsLanguage);
            }
        }

        // GET: Language/Edit/5
        [HttpGet]
        [Route("Languages/Edit/{id}")]
        public async Task<IActionResult> EditLanguage(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsLanguage = await BELanguageViewModel.Repository.GetSingleModelAsync(
                m => m.Keyword == id && m.Specificulture == _lang);
            if (ttsLanguage == null)
            {
                return NotFound();
            }
            return View(ttsLanguage.Data);
        }

        // POST: Language/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Languages/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLanguage(string id, BELanguageViewModel ttsLanguage)
        {
            if (id != ttsLanguage.Keyword)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var result = await ttsLanguage.SaveModelAsync(); //_repo.EditModelAsync(ttsLanguage.ParseModel());
                    if (result.IsSucceed)
                    {
                        GlobalLanguageService.Instance.Refresh();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BELanguageViewModel.Repository.CheckIsExists(c => c.Specificulture == ttsLanguage.Specificulture))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Languages");
            }
            return View(ttsLanguage);
        }

        [HttpGet]
        [Route("Languages/Delete/{id}")]
        public async Task<IActionResult> DeleteLanguage(string id)
        {
            var result = await BELanguageViewModel.Repository.RemoveModelAsync(m => m.Keyword == id && m.Specificulture == _lang);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return RedirectToAction("Languages");
        }
        #endregion
    }
}