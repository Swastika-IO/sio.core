// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.ViewModels.Info;
using System.Linq;

namespace Swastika.Cms.Mvc.ViewComponents
{
    public class HeaderNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string culture = ViewBag.culture;
            var topCates = InfoCategoryViewModel.Repository.GetModelListBy
                (c => c.Specificulture == culture && c.SiocCategoryPosition.Any(p => p.PositionId == (int)SWCmsConstants.CatePosition.Top)
                );
            var data = topCates.Data ?? new System.Collections.Generic.List<InfoCategoryViewModel>();
            return View(data);
        }
    }
}