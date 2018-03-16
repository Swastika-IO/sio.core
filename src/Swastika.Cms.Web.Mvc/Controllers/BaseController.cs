// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Services;
using Swastika.Common.Helper;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Swastika.Cms.Mvc.Controllers
{
    public class BaseController<T> : Controller
    {
        public readonly string ROUTE_CULTURE_NAME = "culture";
        public readonly string ROUTE_DEFAULT_CULTURE = SWCmsConstants.Default.Specificulture;
        protected string _domain;
        protected IConfigurationRoot _configuration;
        protected IHostingEnvironment _env;
        private string _currentLanguage;

        public BaseController(IHostingEnvironment env)
        {
            _env = env;
            string lang = RouteData != null && RouteData.Values[ROUTE_CULTURE_NAME] != null
               ? RouteData.Values[ROUTE_CULTURE_NAME].ToString() : ROUTE_DEFAULT_CULTURE;

            // Set CultureInfo
            var cultureInfo = new CultureInfo(CurrentLanguage);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public BaseController(IHostingEnvironment env, IConfigurationRoot configuration)
        {
            _configuration = configuration;
            _env = env;
            string lang = RouteData != null && RouteData.Values[ROUTE_CULTURE_NAME] != null
               ? RouteData.Values[ROUTE_CULTURE_NAME].ToString() : ROUTE_DEFAULT_CULTURE;

            // Set CultureInfo
            var cultureInfo = new CultureInfo(CurrentLanguage);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public ViewContext ViewContext { get; set; }

        protected string CurrentLanguage {
            get {
                _currentLanguage = RouteData?.Values[ROUTE_CULTURE_NAME] != null
                                    ? RouteData.Values[ROUTE_CULTURE_NAME].ToString().ToLower() : ROUTE_DEFAULT_CULTURE.ToLower();
                return _currentLanguage;
            }
        }

        //public BaseController(IHostingEnvironment env, IStringLocalizer<SharedResource> localizer)
        //{
        //    _env = env;
        //    string lang = RouteData != null && RouteData.Values[CONST_ROUTE_CULTURE_NAME] != null
        //        ? RouteData.Values[CONST_ROUTE_CULTURE_NAME].ToString() : CONST_ROUTE_DEFAULT_CULTURE;
        //    listCultures = listCultures ?? CultureRepository.GetInstance().GetModelList();
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(GlobalConfigurationService.Instance.ConnectionString))
            {
                GetLanguage();
            }
            base.OnActionExecuting(context);
        }

        protected void GetLanguage()
        {
            //_lang = RouteData != null && RouteData.Values[CONST_ROUTE_CULTURE_NAME] != null
            //    ? RouteData.Values[CONST_ROUTE_CULTURE_NAME].ToString() : CONST_ROUTE_DEFAULT_CULTURE;

            _domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);

            ViewBag.culture = CurrentLanguage;

            //ViewBag.currentCulture = listCultures.FirstOrDefault(c => c.Specificulture == _lang);
            //ViewBag.cultures = listCultures;
        }

        protected async Task<string> UploadFileAsync(IFormFile file, string folderPath)
        {
            if (file != null && file.Length > 0)
            {
                string fileName = await CommonHelper.UploadFileAsync(System.IO.Path.Combine(_env.WebRootPath, folderPath), file);
                if (!string.IsNullOrEmpty(fileName))
                {
                    string filePath = string.Format("{0}/{1}", folderPath, fileName);
                    return filePath;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        protected async Task<List<string>> UploadListFileAsync(string folderPath)
        {
            List<string> result = new List<string>();
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                string fileName = await UploadFileAsync(file, folderPath);
                if (!string.IsNullOrEmpty(fileName))
                {
                    result.Add(fileName);
                }
            }
            return result;
        }
    }
}
