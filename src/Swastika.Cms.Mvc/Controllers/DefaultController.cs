using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Swastika.Cms.Mvc.Controllers
{
    [Route("")]
    public class DefaultController : BaseController<DefaultController>
    {
        public DefaultController(IHostingEnvironment env) : base(env)
        {
        }

        public IActionResult Index()
        {
            return RedirectPermanent(string.Format("/{0}", _lang));
        }
    }
}