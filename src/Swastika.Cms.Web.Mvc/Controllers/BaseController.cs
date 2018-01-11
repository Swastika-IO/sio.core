using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swastika.IO.Common.Helper;
using Swastika.Cms.Lib.Services;

namespace Swastika.Cms.Mvc.Controllers
{
    public class BaseController<T> : Controller
    {
        public ViewContext ViewContext { get; set; }
        protected string _lang;
        protected string _domain;
        protected IHostingEnvironment _env;
        public BaseController(IHostingEnvironment env)
        {
            _env = env;
            string lang = RouteData != null && RouteData.Values["culture"] != null
               ? RouteData.Values["culture"].ToString() : "vi-vn";
        }

        //public BaseController(IHostingEnvironment env, IStringLocalizer<SharedResource> localizer)
        //{
        //    _env = env;
        //    string lang = RouteData != null && RouteData.Values["culture"] != null
        //        ? RouteData.Values["culture"].ToString() : "vi-vn";            
        //    listCultures = listCultures ?? CultureRepository.GetInstance().GetModelList();
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (GlobalConfigurationService.Instance.IsInit)
            {

                GetLanguage();

                base.OnActionExecuting(context);
            }

            
        }
        protected void GetLanguage()
        {

            _lang = RouteData != null && RouteData.Values["culture"] != null
                ? RouteData.Values["culture"].ToString() : "vi-vn";
            _domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            ViewBag.culture = _lang;
            //ViewBag.currentCulture = listCultures.FirstOrDefault(c => c.Specificulture == _lang);
            //ViewBag.cultures = listCultures;
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
    }
}