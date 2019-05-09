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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Sio.Cms.Lib.Helpers;

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
            IHostingEnvironment env,
            IMemoryCache memoryCache
            )
            : base(memoryCache, hubContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appLifetime = appLifetime;
            _env = env;
        }
        public void ShutdownSite()
        {
            _appLifetime.StopApplication();
        }
        #region Get

        // GET api/category/id
        [AllowAnonymous]
        [HttpGet, HttpOptions]
        [Route("{culture}/settings")]
        [Route("settings")]
        public RepositoryResponse<GlobalSettingsViewModel> Settings()
        {
            var cultures = CommonRepository.Instance.LoadCultures();
            var culture = cultures.FirstOrDefault(c => c.Specificulture == _lang);
            GlobalSettingsViewModel settings = new GlobalSettingsViewModel()
            {
                Domain = SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.Domain),
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
        [AllowAnonymous]
        [HttpGet, HttpOptions]
        [Route("{culture}/all-settings")]
        [Route("all-settings")]
        public RepositoryResponse<JObject> AllSettingsAsync()
        {
            return getAllSettings();
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
        [AllowAnonymous]
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
                Domain = SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.Domain),
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

        // GET api/v1/portal/check-config
        [AllowAnonymous]
        [HttpGet, HttpOptions]
        [Route("check-config/{lastSync}")]
        public RepositoryResponse<JObject> checkConfig(DateTime lastSync)
        {
            var lastUpdate = SioService.GetConfig<DateTime>("LastUpdateConfiguration");
            if(lastSync.ToUniversalTime() < lastUpdate){
                return getAllSettings();
            }
            else{
                return new RepositoryResponse<JObject>()
                {
                    IsSucceed = true,                
                };
            }
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("sitemap")]
        public RepositoryResponse<FileViewModel> SiteMap()
        {
            try
            {
                XNamespace aw = "http://www.sitemaps.org/schemas/sitemap/0.9";
                var root = new XElement(aw + "urlset");
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

        // GET 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpGet, HttpOptions]
        [Route("app-settings/details")]
        public RepositoryResponse<JObject> LoadAppSettings()
        {
            var settings = FileRepository.Instance.GetFile("appsettings", ".json", string.Empty, true, "{}");
            return new RepositoryResponse<JObject>() { IsSucceed = true, Data = JObject.Parse(settings.Content) };
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("translate-url/{culture}/{type}/{id}")]
        public async Task<RepositoryResponse<string>> TranslateUrlAsync(string culture, string type, int id)
        {
            switch (type)
            {
                case "Article":
                    var getArticle = await Lib.ViewModels.SioArticles.ReadListItemViewModel.Repository.GetSingleModelAsync(
                        a => a.Id == id && a.Specificulture == culture);
                    if (getArticle.IsSucceed)
                    {
                        return new RepositoryResponse<string>()
                        {
                            IsSucceed = getArticle.IsSucceed,
                            Data = SioCmsHelper.GetRouterUrl("Article", new { id = getArticle.Data.Id, getArticle.Data.SeoName }, Request, Url)
                        };
                    }
                    else
                    {
                        return new RepositoryResponse<string>()
                        {
                            IsSucceed = getArticle.IsSucceed,
                            Data = $"/{culture}"
                        };
                    }

                case "Page":
                    var getPage = await Lib.ViewModels.SioPages.ReadListItemViewModel.Repository.GetSingleModelAsync(
                        a => a.Id == id && a.Specificulture == culture);
                    if (getPage.IsSucceed)
                    {
                        return new RepositoryResponse<string>()
                        {
                            IsSucceed = getPage.IsSucceed,
                            Data = SioCmsHelper.GetRouterUrl("Page", new { getPage.Data.SeoName }, Request, Url)
                        };
                    
                    }
                    else
                    {
                        return new RepositoryResponse<string>()
                        {
                            IsSucceed = true,
                            Data = $"/{culture}"
                        };
                    }
                default:
                    return new RepositoryResponse<string>()
                    {
                        IsSucceed = true,
                        Data = $"/{culture}"
                    };
            }
        }

        #endregion Get

        #region Post

        [AllowAnonymous]
        [HttpPost, HttpOptions]
        [Route("encrypt-rsa")]
        public RepositoryResponse<string> EncryptRsa([FromBody]JObject model)
        {
            string data = model.GetValue("data").Value<string>();
            return new RepositoryResponse<string>()
            {

                Data = RSAEncryptionHelper.GetEncryptedText(data)
            };
        }

        [AllowAnonymous]
        [HttpPost, HttpOptions]
        [Route("decrypt-rsa")]
        public RepositoryResponse<string> DecryptRsa([FromBody]JObject model)
        {
            string data = model.GetValue("data").Value<string>();
            return new RepositoryResponse<string>()
            {

                Data = RSAEncryptionHelper.GetDecryptedText(data)
            };
        }

        [AllowAnonymous]
        [HttpPost, HttpOptions]
        [Route("encrypt")]
        public RepositoryResponse<CryptoViewModel<string>> Encrypt([FromBody]JObject model)
        {
            string data = model.GetValue("data").Value<string>();
            var encrypted = new JObject(new JProperty("encrypted", data));
            return new RepositoryResponse<CryptoViewModel<string>>() {
                
                Data = AesEncryptionHelper.EncryptStringToBytes_Aes(encrypted)
            };
        }
        [AllowAnonymous]
        [HttpPost, HttpOptions]
        [Route("decrypt")]
        public RepositoryResponse<CryptoViewModel<JObject>> Decrypt([FromBody]JObject model)
        {
            string data = model.GetValue("data").Value<string>();
            string key = model.GetValue("key").Value<string>();
            string iv = model.GetValue("iv").Value<string>();
            return new RepositoryResponse<CryptoViewModel<JObject>>() {
                
                Data = AesEncryptionHelper.DecryptStringFromBytes_Aes(data, key, iv)
            };
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
                SioService.SetConfig("LastUpdateConfiguration", DateTime.UtcNow);
            
            }
            return new RepositoryResponse<JObject>() { IsSucceed = model != null, Data = model };
        }
        
        // POST api/category
        [HttpGet, HttpOptions]
        [Route("app-settings/save-default")]
        public RepositoryResponse<bool> SaveDefaultAppSettings()
        {
            return new RepositoryResponse<bool>() { IsSucceed = true, Data = SioService.SaveSettings() };
        }

        [AllowAnonymous]
        [HttpPost, HttpOptions]
        [Route("sendmail")]
        public void SendMail([FromBody]JObject model)
        {
            SioService.SendMail(model.Value<string>("subject"), model.Value<string>("body"), SioService.GetConfig<string>("ContactEmail", _lang));
        }

        // POST api/category
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("import")]
        [Route("{culture}/import")]
        public async Task<RepositoryResponse<bool>> ImportAsync([FromForm]IFormFile assets)
        {
            string importFolder = $"Imports/Structures/{_lang}";
            var result = new RepositoryResponse<bool>();
            var model = FileRepository.Instance.SaveWebFile(assets, importFolder);
            if (model != null)
            {
                var fileContent = FileRepository.Instance.GetWebFile($"{model.Filename}{model.Extension}", model.FileFolder);
                var obj = JObject.Parse(fileContent.Content);
                switch (obj["type"].Value<string>())
                {
                    case "Language":
                        var arrLanguage = obj["data"].ToObject<List<SioLanguage>>();
                        result = await Lib.ViewModels.SioLanguages.ReadMvcViewModel.ImportLanguages(arrLanguage, _lang);
                        if (result.IsSucceed)
                        {
                            base.RemoveCache();
                        }
                        return result;
                    case "Configuration":
                        var arrConfiguration = obj["data"].ToObject<List<SioConfiguration>>();
                        result = await Lib.ViewModels.SioConfigurations.ReadMvcViewModel.ImportConfigurations(arrConfiguration, _lang);
                        if (result.IsSucceed)
                        {
                            base.RemoveCache();
                        }
                        return result;
                    case "Module":
                        var arrModule = obj["data"].ToObject<List<SioModule>>();
                        result = await Lib.ViewModels.SioModules.Helper.Import(arrModule, _lang);
                        if (result.IsSucceed)
                        {
                            base.RemoveCache();
                        }
                        return result;
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
        private RepositoryResponse<JObject> getAllSettings(){
            var cultures = CommonRepository.Instance.LoadCultures();
            var culture = cultures.FirstOrDefault(c => c.Specificulture == _lang);

            // Get Settings
            GlobalSettingsViewModel configurations = new GlobalSettingsViewModel()
            {
                Domain = SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.Domain),
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
                new JProperty("langIcon",configurations.LangIcon),
                
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

        private async Task<RepositoryResponse<bool>> InitCmsAsync(InitCmsViewModel model)
        {
            var result = new RepositoryResponse<bool>();

            SioService.SetConnectionString(SioConstants.CONST_CMS_CONNECTION, model.ConnectionString);
            SioService.SetConnectionString(SioConstants.CONST_MESSENGER_CONNECTION, model.ConnectionString);
            SioService.SetConnectionString(SioConstants.CONST_ACCOUNT_CONNECTION, model.ConnectionString);
            SioService.SetConfig(SioConstants.CONST_SETTING_IS_MYSQL, model.IsMysql);
            SioService.SetConfig(SioConstants.CONST_SETTING_DATABASE_PROVIDER, model.DatabaseProvider);
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
                SioService.SaveSettings();
                SioService.Reload();
            }
            else
            {
                // if cannot init cms 
                //  => reload from default settings
                //  => save to appSettings
                SioService.Reload();
                SioService.SaveSettings();
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
