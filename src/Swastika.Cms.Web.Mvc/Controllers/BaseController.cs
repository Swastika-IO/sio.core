// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
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
    public class BaseController : Controller
    {
        public readonly string ROUTE_CULTURE_NAME = "culture";
        public readonly string ROUTE_DEFAULT_CULTURE = GlobalConfigurationService.Instance.CmsConfigurations?.Language ?? "en-us";
        protected string _domain;
        protected IConfiguration _configuration;
        protected IHostingEnvironment _env;

        public BaseController(IHostingEnvironment env)
        {
            _env = env;
            // Set CultureInfo
            var cultureInfo = new CultureInfo(CurrentLanguage);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public BaseController(IHostingEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
            _env = env;
            // Set CultureInfo
            var cultureInfo = new CultureInfo(CurrentLanguage);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public ViewContext ViewContext { get; set; }

        protected string CurrentLanguage
        {
            get => RouteData?.Values[ROUTE_CULTURE_NAME]?.ToString().ToLower() ?? ROUTE_DEFAULT_CULTURE.ToLower();            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(GlobalConfigurationService.Instance.CmsConfigurations.CmsConnectionString))
            {
                GetLanguage();
            }
            base.OnActionExecuting(context);
        }

        protected void GetLanguage()
        {
            _domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);

            ViewBag.culture = CurrentLanguage;
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
