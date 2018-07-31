// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.ViewModels.Info;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Mvc.ViewComponents
{
    public class FooterNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var topCates = new List<InfoCategoryViewModel>();
            return View(topCates.OrderBy(c => c.Priority).ToList());
        }
    }
}