using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swastika.IO.Cms.Lib.Services;
using System;
using System.Diagnostics;

namespace Swastika.IO.Core.Controllers
{
    public class HomeController : Controller
    {
        private const string SessionKeyIsApp = "_IsApp";
        private const string RequestQueryIsApp = "app";
        private readonly ApplicationConfigService _appService;
        public HomeController(ApplicationConfigService service)
        {
            this._appService = service;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(SessionKeyIsApp) == null)
            {
                HttpContext.Session.SetString(SessionKeyIsApp, "false");
            }
            if (HttpContext.Request.Query[RequestQueryIsApp].ToString() != String.Empty)
            {
                HttpContext.Session.SetString(SessionKeyIsApp, HttpContext.Request.Query[RequestQueryIsApp].ToString());
            }

            if (HttpContext.Session.GetString(SessionKeyIsApp).Equals("true"))
            {
                HttpContext.Session.SetString(SessionKeyIsApp, "true");
                return View("SpaIndex");
            }
            else
            {
                HttpContext.Session.SetString(SessionKeyIsApp, "false");
                return View();
            }
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}