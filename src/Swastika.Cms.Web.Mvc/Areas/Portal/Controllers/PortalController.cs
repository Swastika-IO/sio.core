// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Account;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Mvc.Controllers;
using Swastika.Identity.Models;
using System;
using System.Threading.Tasks;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Area("Portal")]
    [Route("Portal")]
    [Route("Admin")]
    public class PortalController : BaseController<PortalController>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PortalController(IHostingEnvironment env, IConfigurationRoot configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
            : base(env, configuration)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("", "Dashboard", new { culture = CurrentLanguage });
            //return View();
        }

        [HttpGet]
        [Route("init")]
        public IActionResult Init()
        {
            var model = new InitCmsViewModel()
            {
                LocalDbName = "aspnet-swastika.Cms.Db",
                LocalDbConnectionString = $"Server=(localdb)\\mssqllocaldb;Database=aspnet-swastika.Cms.Db;Trusted_Connection=True;MultipleActiveResultSets=true"
            };
            return View(model);
        }

        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> Init(InitCmsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string cnnString = string.Empty;
                if (!model.IsUseLocal)
                {
                    cnnString = string.Format("Server={0};Database={1};UID={2};Pwd={3};MultipleActiveResultSets=true;"
                       , model.DataBaseServer, model.DataBaseName, model.DataBaseUser, model.DataBasePassword);
                }
                else
                {
                    cnnString = model.LocalDbConnectionString;
                }
                var settings = FileRepository.Instance.GetFile("appsettings", ".json", string.Empty, true, "{}");
                if (settings != null)
                {
                    JObject jsonSettings = JObject.Parse(settings.Content);
                    jsonSettings["ConnectionStrings"][SWCmsConstants.CONST_DEFAULT_CONNECTION] = cnnString;
                    // Set connection string for identity ApplicationDbContext
                    jsonSettings["ConnectionStrings"]["AccountConnection"] = cnnString;
                    settings.Content = jsonSettings.ToString();
                    FileRepository.Instance.SaveFile(settings);
                }
                GlobalConfigurationService.Instance.ConnectionString = cnnString;
                var initResult = await GlobalConfigurationService.Instance.InitSWCms(_userManager, _roleManager);
                if (initResult.IsSucceed)
                {


                    await InitRolesAsync();
                    return RedirectToAction("RegisterSuperAdmin", "Auth", new { culture = SWCmsConstants.Default.Specificulture });
                }
                else
                {
                    settings = FileRepository.Instance.GetFile("appsettings", ".json", string.Empty);
                    JObject jsonSettings = JObject.Parse(settings.Content);
                    jsonSettings["ConnectionStrings"][SWCmsConstants.CONST_DEFAULT_CONNECTION] = null;
                    jsonSettings["ConnectionStrings"]["AccountConnection"] = null;
                    settings.Content = jsonSettings.ToString();
                    FileRepository.Instance.SaveFile(settings);
                    if (initResult.Exception != null)
                    {
                        ModelState.AddModelError("", initResult.Exception.Message);
                    }
                    foreach (var item in initResult.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }
                }
            }
            return View(model);
        }

        private async Task<bool> InitRolesAsync()
        {
            bool isSucceed = true;
            var getRoles = await RoleViewModel.Repository.GetModelListAsync();
            if (getRoles.IsSucceed && getRoles.Data.Count == 0)
            {
                var saveResult = await _roleManager.CreateAsync(new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "SuperAdmin"
                });
                isSucceed = saveResult.Succeeded;
            }
            return isSucceed;
        }

        /// <summary>
        /// Searches the specified keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="searchType">Type of the search Ex: All / Article / Module / Page .</param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search(string keyword, SWCmsConstants.SearchType searchType)
        {
            switch (searchType)
            {
                case SWCmsConstants.SearchType.All:
                    ViewData["Articles"] = (await InfoArticleViewModel.Repository.GetModelListByAsync(
                        c => c.Specificulture == CurrentLanguage && (c.Title.Contains(keyword) || c.Excerpt.Contains(keyword) || c.Content.Contains(keyword))).ConfigureAwait(false)
                        ).Data;
                    ViewData["Pages"] = (InfoCategoryViewModel.Repository.GetModelListBy(
                        c => c.Specificulture == CurrentLanguage
                        && (c.Title.Contains(keyword) || c.Excerpt.Contains(keyword)))
                        ).Data;
                    ViewData["Modules"] = (InfoModuleViewModel.Repository.GetModelListBy(
                        c => c.Specificulture == CurrentLanguage && (c.Title.Contains(keyword)
                        || c.Description.Contains(keyword)))
                        ).Data;
                    break;

                case SWCmsConstants.SearchType.Article:
                    ViewData["Articles"] = (await InfoArticleViewModel.Repository.GetModelListByAsync(
                        c => c.Specificulture == CurrentLanguage && (c.Title.Contains(keyword) || c.Excerpt.Contains(keyword) || c.Content.Contains(keyword))).ConfigureAwait(false)
                        ).Data;
                    break;

                case SWCmsConstants.SearchType.Module:
                    ViewData["Modules"] = (InfoModuleViewModel.Repository.GetModelListBy(
                        c => c.Specificulture == CurrentLanguage && (c.Title.Contains(keyword) || c.Description.Contains(keyword)))
                        ).Data;
                    break;

                case SWCmsConstants.SearchType.Page:
                    ViewData["Pages"] = (InfoCategoryViewModel.Repository.GetModelListBy(
                        c => c.Specificulture == CurrentLanguage
                        && (c.Title.Contains(keyword) || c.Excerpt.Contains(keyword)))
                        ).Data;
                    break;

                default:
                    break;
            }
            ViewBag.searchType = searchType;
            return View();
        }
    }
}
