// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

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
