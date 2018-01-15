using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.Models.Cms;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/setting")]
    public class SettingController : BaseController<SettingController>
    {
        //private readonly GlobalConfigurationService _appService;
        public SettingController(IHostingEnvironment env
            //, IStringLocalizer<SharedResource> localizer
            //, GlobalConfigurationService service
            )
            : base(env)
        {
            //_appService = service;
        }


        #region Configurations
        [Route("")]
        [Route("Configurations")]
        [Route("generals")]
        public IActionResult Configurations()
        {
            PaginationModel<ConfigurationViewModel> pagingPages = new PaginationModel<ConfigurationViewModel>()
            {
                Items = GlobalConfigurationService.ListConfiguration.Where(m => m.Specificulture == _lang).ToList(),
                PageIndex = 0,
                PageSize = GlobalConfigurationService.ListConfiguration.Count(m => m.Specificulture == _lang),
                TotalItems = GlobalConfigurationService.ListConfiguration.Count(m => m.Specificulture == _lang),
                TotalPage = 1
            };
            //  await ConfigurationRepository.GetInstance().GetModelListByAsync(m=> m.Specificulture == _lang,
            //cate => cate.Description, "desc",
            //pageSize, pageIndex, Swastika.Cms.Lib.SWCmsConstants.ViewModelType.FrontEnd);
            return View(pagingPages);
        }
        // GET: Configuration/Create
        [Route("Configurations/Create")]
        public IActionResult CreateConfiguration()
        {
            ConfigurationViewModel ttsConfiguration = new ConfigurationViewModel(
                new SiocConfiguration()
            {
                //Id = ConfigurationRepository.GetInstance().GetNextId()
                Specificulture = _lang
            });
            return View(ttsConfiguration);
        }

        // POST: Configuration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Configurations/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfiguration(ConfigurationViewModel ttsConfiguration)
        {
            if (ModelState.IsValid)
            {
                var result = await ttsConfiguration.SaveModelAsync();// ConfigurationViewModel.Repository.CreateModelAsync(ttsConfiguration);
                if (result.IsSucceed)
                {
                    GlobalConfigurationService.Instance.Refresh();
                    return RedirectToAction("Configurations");
                }
                else
                {
                    return View(ttsConfiguration);
                }
            }
            else
            {
                return View(ttsConfiguration);
            }
        }

        // GET: Configuration/Edit/5
        [Route("Configurations/Edit/{id}")]
        public async Task<IActionResult> EditConfiguration(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsConfiguration = await ConfigurationViewModel.Repository.GetSingleModelAsync(
                m => m.Keyword == id && m.Specificulture == _lang);
            if (ttsConfiguration == null)
            {
                return NotFound();
            }
            return View(ttsConfiguration.Data);
        }

        // POST: Configuration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Configurations/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfiguration(string id, ConfigurationViewModel ttsConfiguration)
        {
            if (id != ttsConfiguration.Keyword)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var result = await ttsConfiguration.SaveModelAsync(); //_repo.EditModelAsync(ttsConfiguration.ParseModel());
                    if (result.IsSucceed)
                    {
                        GlobalConfigurationService.Instance.Refresh();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationViewModel.Repository.CheckIsExists(c => c.Specificulture == ttsConfiguration.Specificulture))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Configurations");
            }
            return View(ttsConfiguration);
        }

        [Route("Configurations/Delete/{id}")]
        public async Task<IActionResult> DeleteConfiguration(string id)
        {
            var result = await ConfigurationViewModel.Repository.RemoveModelAsync(m => m.Keyword == id && m.Specificulture == _lang);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.Refresh();
            }
            return RedirectToAction("Configurations");
        }
        #endregion
    }
}
