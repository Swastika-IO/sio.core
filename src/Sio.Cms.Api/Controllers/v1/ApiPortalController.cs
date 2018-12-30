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
using System.Xml.Linq;
using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Hosting;

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
        private readonly IApplicationLifetime _appLifetime;
        private readonly IHostingEnvironment _env;
        public ApiPortalController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
            Microsoft.AspNetCore.SignalR.IHubContext<Hub.PortalHub> hubContext,
            IApplicationLifetime appLifetime,
            IHostingEnvironment env
            )
            : base(hubContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appLifetime = appLifetime;
        }

        public async Task ShutdownSite()
        {
            _appLifetime.StopApplication();
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
                ModuleTypes = Enum.GetNames(typeof(SioModuleType)).ToList(),
                DataTypes = Enum.GetNames(typeof(SioDataType)).ToList(),
                Statuses = Enum.GetNames(typeof(SioContentStatus)).ToList(),
                LastUpdateConfiguration = SioService.GetConfig<DateTime?>("LastUpdateConfiguration")

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
                ModuleTypes = Enum.GetNames(typeof(SioModuleType)).ToList(),
                DataTypes = Enum.GetNames(typeof(SioDataType)).ToList(),
                Statuses = Enum.GetNames(typeof(SioContentStatus)).ToList(),
                LastUpdateConfiguration = SioService.GetConfig<DateTime?>("LastUpdateConfiguration")
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
                ModuleTypes = Enum.GetNames(typeof(SioModuleType)).ToList(),
                DataTypes = Enum.GetNames(typeof(SioDataType)).ToList(),
                Statuses = Enum.GetNames(typeof(SioContentStatus)).ToList(),
                LastUpdateConfiguration = SioService.GetConfig<DateTime?>("LastUpdateConfiguration")
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

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("sitemap")]
        public RepositoryResponse<FileViewModel> SiteMap()
        {
            try
            {
                var root = new XElement("urlset",
                new XAttribute("xlmns", @"http://www.sitemaps.org/schemas/sitemap/0.9")
                );
                var pages = Lib.ViewModels.SioPages.ReadListItemViewModel.Repository.GetModelList();
                List<int> handledPageId = new List<int>();
                foreach (var page in pages.Data)
                {
                        page.DetailsUrl = SioCmsHelper.GetRouterUrl(
                                        "page", new { seoName = page.SeoName, culture = page.Specificulture }, Request, Url);
                    var otherLanguages = pages.Data.Where(p => p.Id == page.Id && p.Specificulture != page.Specificulture);
                    var lstOther = new List<SitemapLanguage>();
                    foreach (var item in otherLanguages)
                    {
                        lstOther.Add(new SitemapLanguage() {
                            HrefLang = item.Specificulture,
                            Href= SioCmsHelper.GetRouterUrl(
                                        "page", new { seoName = page.SeoName, culture = item.Specificulture }, Request, Url)
                        } );
                    }
                    
                    var sitemap = new SiteMap()
                    {
                        ChangeFreq = "monthly",
                        LastMod = DateTime.UtcNow,
                        Loc = page.DetailsUrl,
                        Priority = 0.3,
                        OtherLanguages = lstOther
                    };
                    root.Add(sitemap.ParseXElement());
                }

                var articles = Lib.ViewModels.SioArticles.ReadListItemViewModel.Repository.GetModelList();
                foreach (var article in articles.Data)
                {
                    article.DetailsUrl = SioCmsHelper.GetRouterUrl(
                                    "article", new { seoName = article.SeoName, culture = article.Specificulture }, Request, Url);
                    var otherLanguages = pages.Data.Where(p => p.Id == article.Id && p.Specificulture != article.Specificulture);
                    var lstOther = new List<SitemapLanguage>();
                    foreach (var item in otherLanguages)
                    {
                        lstOther.Add(new SitemapLanguage()
                        {
                            HrefLang = item.Specificulture,
                            Href = SioCmsHelper.GetRouterUrl(
                                        "page", new { seoName = article.SeoName, culture = item.Specificulture }, Request, Url)
                        });
                    }
                    var sitemap = new SiteMap()
                    {
                        ChangeFreq = "monthly",
                        LastMod = DateTime.UtcNow,
                        Loc = article.DetailsUrl,
                        OtherLanguages = lstOther,
                        Priority = 0.3
                    };
                    root.Add(sitemap.ParseXElement());
                }

                string folder = $"Sitemaps";
                FileRepository.Instance.CreateDirectoryIfNotExist(folder);
                string filename = $"sitemap";
                string filePath = $"wwwroot/{folder}/{filename}.xml";
                root.Save(filePath);
                return new RepositoryResponse<FileViewModel>()
                {
                    IsSucceed = true,
                    Data = new FileViewModel()
                    {
                        Extension = ".xml",
                        Filename = filename,
                        FileFolder = folder
                    }
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<FileViewModel>() { Exception = ex };
            }
        }

        #endregion Get

        #region Post

        // GET 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpGet, HttpOptions]
        [Route("app-settings/details")]
        public RepositoryResponse<JObject> LoadAppSettings()
        {
            var settings = FileRepository.Instance.GetFile("appsettings", ".json", string.Empty, true, "{}");
            return new RepositoryResponse<JObject>() { IsSucceed = true, Data = JObject.Parse(settings.Content) };
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
                //if (!_env.IsDevelopment())
                //{
                //    _appLifetime.StopApplication();
                //}
            }
            return new RepositoryResponse<JObject>() { IsSucceed = model != null, Data = model };
        }

        [HttpPost, HttpOptions]
        [Route("sendmail")]
        public void SendMail([FromBody]JObject model)
        {
            SioService.SendMail(model.Value<string>("subject"), model.Value<string>("body"), SioService.GetConfig<string>("ContactEmail", _lang));
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
            SioService.SetConnectionString(SioConstants.CONST_MESSENGER_CONNECTION, model.ConnectionString);
            SioService.SetConnectionString(SioConstants.CONST_ACCOUNT_CONNECTION, model.ConnectionString);
            SioService.SetConfig(SioConstants.CONST_SETTING_IS_SQLITE, model.IsSqlite);
            SioService.SetConfig(SioConstants.CONST_SETTING_LANGUAGE, model.Culture.Specificulture);

            InitCmsService sv = new InitCmsService();
            var initResult = await sv.InitCms(model.SiteName, model.Culture);
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
