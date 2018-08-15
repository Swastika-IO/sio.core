using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Swastika.Cms.Mvc.Controllers
{
    [Route("backend")]
    public class BackendController : BaseController
    {
        public BackendController(IHostingEnvironment env) : base(env)
        {}

        [HttpGet]
        [Route("")]
        [Route("{pageName}")]
        [Route("{pageName}/{type}")]
        [Route("{pageName}/{type}/{param}")]
        [Route("{pageName}/{type}/{param}/{param1}")]
        [Route("{pageName}/{type}/{param}/{param1}/{param2}")]
        [Route("{pageName}/{type}/{param}/{param1}/{param2}/{param3}")]
        [Route("{pageName}/{type}/{param}/{param1}/{param2}/{param3}/{param4}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("init")]
        public IActionResult Init()
        {
            return View();
        }
    }
}
