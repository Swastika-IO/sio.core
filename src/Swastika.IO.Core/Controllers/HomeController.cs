using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.IO.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Swastika.IO.Core.Controllers
{   
    public class HomeController : Controller
    {
        const string SessionKeyIsApp = "_IsApp";
        const string RequestQueryIsApp = "app";

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
            //string AppType = HttpContext.Request.Query["isapp"].ToString();
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
