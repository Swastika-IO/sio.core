// Licensed to the Sio I/O Foundation under one or more agreements.
// The Sio I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sio.Cms.Lib.Repositories;
using Sio.Cms.Lib.Services;
using Sio.Cms.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sio.Identity.Models;
using Sio.Domain.Core.ViewModels;
using Sio.Cms.Lib;
using static Sio.Cms.Lib.SioEnums;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.ViewModels.Account;
using Sio.Cms.Lib.ViewModels.SioInit;

namespace Sio.Cms.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/portal")]
    public class ApiPortalController :
        BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApiPortalController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
            Microsoft.AspNetCore.SignalR.IHubContext<Hub.PortalHub> hubContext
            )
            : base(hubContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region Get

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("{culture}/settings")]
        [Route("settings")]
        public RepositoryResponse<GlobalSettingsViewModel> Settings()
        {
            var cultures = CommonRepository.Instance.LoadCultures();
            var culture = cultures.FirstOrDefault(c => c.Specificulture == _lang);
            GlobalSettingsViewModel settings = new GlobalSettingsViewModel()
            {
                Lang = _lang,
                ThemeId = SioService.GetConfig<int>(SioConstants.ConfigurationKeyword.ThemeId, _lang),
                Cultures = cultures,
                PageTypes = Enum.GetNames(typeof(SioPageType)).ToList(),
                Statuses = Enum.GetNames(typeof(SioContentStatus)).ToList()

            };
            settings.LangIcon = culture?.Icon ?? SioService.GetConfig<string>("Language");
            return new RepositoryResponse<GlobalSettingsViewModel>()
            {
                IsSucceed = true,
                Data = settings
            };
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("{culture}/all-settings")]
        [Route("all-settings")]
        public RepositoryResponse<JObject> AllSettingsAsync()
        {
            var cultures = CommonRepository.Instance.LoadCultures();
            var culture = cultures.FirstOrDefault(c => c.Specificulture == _lang);

            // Get Settings
            GlobalSettingsViewModel configurations = new GlobalSettingsViewModel()
            {
                Lang = _lang,
                ThemeId = SioService.GetConfig<int>(SioConstants.ConfigurationKeyword.ThemeId, _lang),
                ApiEncryptKey = SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ApiEncryptKey),
                ApiEncryptIV = SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ApiEncryptIV),
                IsEncryptApi = SioService.GetConfig<bool>(SioConstants.ConfigurationKeyword.IsEncryptApi),
                Cultures = cultures,
                PageTypes = Enum.GetNames(typeof(SioPageType)).ToList(),
                Statuses = Enum.GetNames(typeof(SioContentStatus)).ToList()
            };

            configurations.LangIcon = culture?.Icon ?? SioService.GetConfig<string>("Language");

            // Get translator
            var translator = new JObject()
            {
                new JProperty("lang",_lang),
                new JProperty("data", SioService.GetTranslator(_lang))
            };

            // Get Configurations
            var settings = new JObject()
            {
                new JProperty("lang",_lang),
                new JProperty("data", SioService.GetLocalSettings(_lang))
            };
            JObject result = new JObject()
            {
                new JProperty("globalSettings", JObject.FromObject(configurations)),
                new JProperty("translator", translator),
                new JProperty("settings", JObject.FromObject(settings))
            };

            return new RepositoryResponse<JObject>()
            {
                IsSucceed = true,
                Data = result
            };
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("{culture}/translator")]
        [Route("translator")]
        public RepositoryResponse<JObject> Languages()
        {
            return new RepositoryResponse<JObject>()
            {
                IsSucceed = true,
                Data = SioService.GetTranslator(_lang)
            };
        }

        // GET api/configurations/id
        [HttpGet, HttpOptions]
        [Route("{culture}/global-settings")]
        [Route("global-settings")]
        public RepositoryResponse<JObject> GetGlobalSettings()
        {
            var cultures = CommonRepository.Instance.LoadCultures();
            var culture = cultures.FirstOrDefault(c => c.Specificulture == _lang);

            // Get Settings
            GlobalSettingsViewModel configurations = new GlobalSettingsViewModel()
            {
                Lang = _lang,
                ThemeId = SioService.GetConfig<int>(SioConstants.ConfigurationKeyword.ThemeId, _lang),
                ApiEncryptKey = SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ApiEncryptKey),
                ApiEncryptIV = SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ApiEncryptIV),
                IsEncryptApi = SioService.GetConfig<bool>(SioConstants.ConfigurationKeyword.IsEncryptApi),
                Cultures = cultures,
                PageTypes = Enum.GetNames(typeof(SioPageType)).ToList(),
                Statuses = Enum.GetNames(typeof(SioContentStatus)).ToList()

            };

            configurations.LangIcon = culture?.Icon ?? SioService.GetConfig<string>("Language");
            return new RepositoryResponse<JObject>()
            {
                IsSucceed = true,
                Data = JObject.FromObject(configurations)
            };
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("dashboard")]
        public RepositoryResponse<DashboardViewModel> Dashboard(int id)
        {
            return new RepositoryResponse<DashboardViewModel>()
            {
                IsSucceed = true,
                Data = new DashboardViewModel()
            };
        }

        #endregion Get

        #region Post

        // GET 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpGet, HttpOptions]
        [Route("app-settings/details")]
        public RepositoryResponse<JObject> LoadAppSettings()
        {
            return new RepositoryResponse<JObject>() { IsSucceed = true, Data = SioService.GetGlobalSetting() };
        }

        // POST api/category
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("app-settings/save")]
        public RepositoryResponse<JObject> SaveAppSettings([FromBody]JObject model)
        {
            var settings = FileRepository.Instance.GetFile("appsettings", ".json", string.Empty, true, "{}");
            if (model != null)
            {
                settings.Content = model.ToString();
                FileRepository.Instance.SaveFile(settings);
                //SioCmsService.Instance.RefreshConfigurations();
            }
            return new RepositoryResponse<JObject>() { IsSucceed = model != null, Data = model };
        }

        // POST api/category
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("import/{type}")]
        [Route("{culture}/import/{type}")]
        public async Task<RepositoryResponse<bool>> SaveAppSettingsAsync(string type, [FromBody]FileViewModel model)
        {
            var result = FileRepository.Instance.SaveWebFile(model);
            if (result)
            {
                var fileContent = FileRepository.Instance.GetWebFile($"{model.Filename}{model.Extension}", model.FileFolder);
                var obj = JObject.Parse(fileContent.Content);
                switch (type)
                {
                    case "Language":
                        var arrLanguage = obj["data"].ToObject<List<SioLanguage>>();
                        return await Lib.ViewModels.SioLanguages.ReadMvcViewModel.ImportLanguages(arrLanguage, _lang);
                    case "Configuration":
                        var arrConfiguration = obj["data"].ToObject<List<SioConfiguration>>();
                        return await Lib.ViewModels.SioConfigurations.ReadMvcViewModel.ImportConfigurations(arrConfiguration, _lang);

                    default:
                        return new RepositoryResponse<bool>() { IsSucceed = false };
                }
            }
            return new RepositoryResponse<bool>();

        }

        // POST api/category
        [HttpPost, HttpOptions]
        [Route("init-cms")]
        public async Task<RepositoryResponse<bool>> Post([FromBody]InitCmsViewModel model)
        {
            if (model != null)
            {
                var result = await InitCmsAsync(model).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<bool>();
        }

        #endregion Post

        #region Helpers
        private async Task<RepositoryResponse<bool>> InitCmsAsync(InitCmsViewModel model)
        {
            var result = new RepositoryResponse<bool>();

            SioService.SetConnectionString(SioConstants.CONST_CMS_CONNECTION, model.ConnectionString);
            SioService.SetConnectionString(SioConstants.CONST_ACCOUNT_CONNECTION, model.ConnectionString);
            SioService.SetConfig(SioConstants.CONST_SETTING_IS_SQLITE, model.IsSqlite);
            SioService.SetConfig(SioConstants.CONST_SETTING_LANGUAGE, model.Culture.Specificulture);

            InitCmsService sv = new InitCmsService();
            var initResult = await sv.InitCms(model.Culture);
            if (initResult.IsSucceed)
            {
                await InitRolesAsync();
                result.IsSucceed = true;
                SioService.LoadFromDatabase();
                SioService.SetConfig<bool>("IsInit", true);
                SioService.SetConfig<string>("DefaultCulture", model.Culture.Specificulture);
                SioService.Save();
                SioService.Reload();
            }
            else
            {
                SioService.Reload();
                if (initResult.Exception != null)
                {
                    result.Errors.Add(initResult.Exception.Message);
                    result.Exception = initResult.Exception;
                }
                foreach (var item in initResult.Errors)
                {
                    result.Errors.Add(item);
                }
            }
            return result;
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

        #endregion
    }
}
