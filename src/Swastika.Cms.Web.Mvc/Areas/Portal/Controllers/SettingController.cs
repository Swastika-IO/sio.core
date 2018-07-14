// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Mvc.Controllers;
using Swastika.Domain.Core.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/setting")]
    public class SettingController : BaseController
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

        [HttpGet]
        [Route("")]
        [Route("Configurations")]
        [Route("generals")]
        public IActionResult Configurations()
        {
            PaginationModel<ConfigurationViewModel> pagingPages = new PaginationModel<ConfigurationViewModel>()
            {
                Items = GlobalConfigurationService.Instance.CmsConfigurations.ListConfiguration.Where(m => m.Specificulture == CurrentLanguage).ToList(),
                PageIndex = 0,
                PageSize = GlobalConfigurationService.Instance.CmsConfigurations.ListConfiguration.Count(m => m.Specificulture == CurrentLanguage),
                TotalItems = GlobalConfigurationService.Instance.CmsConfigurations.ListConfiguration.Count(m => m.Specificulture == CurrentLanguage),
                TotalPage = 1
            };
            return View(pagingPages);
        }

        // GET: Configuration/Create
        [HttpGet]
        [Route("Configurations/Create")]
        public IActionResult CreateConfiguration()
        {
            ConfigurationViewModel ttsConfiguration = new ConfigurationViewModel(
                new SiocConfiguration()
                {
                    //Id = ConfigurationRepository.GetInstance().GetNextId()
                    Specificulture = CurrentLanguage
                });
            return View(ttsConfiguration);
        }

        // POST: Configuration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Configurations/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfiguration(ConfigurationViewModel configuration)
        {
            if (ModelState.IsValid)
            {
                var result = await configuration.SaveModelAsync().ConfigureAwait(false);// ConfigurationViewModel.Repository.CreateModelAsync(ttsConfiguration);
                if (result.IsSucceed)
                {
                    GlobalConfigurationService.Instance.Refresh();
                    return RedirectToAction("Configurations");
                }
                else
                {
                    return View(configuration);
                }
            }
            else
            {
                return View(configuration);
            }
        }

        // GET: Configuration/Edit/5
        [HttpGet]
        [Route("Configurations/Edit/{id}")]
        public async Task<IActionResult> EditConfiguration(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsConfiguration = await ConfigurationViewModel.Repository.GetSingleModelAsync(
                m => m.Keyword == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
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
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await ttsConfiguration.SaveModelAsync().ConfigureAwait(false); //_repo.EditModelAsync(ttsConfiguration.ParseModel());
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

        [HttpGet]
        [Route("Configurations/Delete/{id}")]
        public async Task<IActionResult> DeleteConfiguration(string id)
        {
            var result = await ConfigurationViewModel.Repository.RemoveModelAsync(m => m.Keyword == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.Refresh();
            }
            return RedirectToAction("Configurations");
        }

        #endregion Configurations
    }
}
