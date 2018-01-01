using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib;
using System.Linq;
using Swastika.Cms.Lib.ViewModels.Info;

namespace Swastika.Cms.Mvc.ViewComponents
{
    public class HeaderNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {            
            string culture = ViewBag.culture;
            var topCates = InfoCategoryViewModel.Repository.GetModelListBy
                (c => c.Specificulture == culture && c.SiocCategoryPosition.Count(p => p.PositionId == (int)SWCmsConstants.CatePosition.Top) > 0

                );
            var data = topCates.Data ?? new System.Collections.Generic.List<InfoCategoryViewModel>();
            return View(data);
        }
    }
}
