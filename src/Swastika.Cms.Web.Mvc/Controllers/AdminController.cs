//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;

//namespace Swastika.Cms.Mvc.Controllers
//{
//    [Route("admin")]
//    public class AdminController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [Route("admin/UpdateLanguage/{culture}")]
//        [HttpGet]
//        public void UpdateLanguage(string culture, string returnUrl = "/")
//        {
//            WriteCookies("culture", culture, false);
//            Response.Redirect(returnUrl);
//        }
//        public void WriteCookies(string setting,
//              string settingValue, bool isPersistent)
//        {
//            if (isPersistent)
//            {
//                CookieOptions options = new CookieOptions()
//                {
//                    Expires = DateTime.Now.AddDays(1)
//                };
//                Response.Cookies.Append(setting, settingValue, options);
//            }
//            else
//            {
//                Response.Cookies.Append(setting, settingValue);
//            }            
//        }
//    }
//}