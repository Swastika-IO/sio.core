using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Swastika.Cms.Mvc.Areas.Portal.ViewComponents
{
    public class Breadcrumbs : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
