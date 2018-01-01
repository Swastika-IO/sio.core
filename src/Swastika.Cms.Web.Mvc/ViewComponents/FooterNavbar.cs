using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using System.Collections.Generic;
using System.Linq;
namespace Swastika.Cms.Mvc.ViewComponents
{
    public class FooterNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string culture = ViewBag.culture;
            var topCates = new List<InfoCategoryViewModel>();
                //Swastika.Cms.Lib.ViewModels.Info.InfoCategoryViewModel.Repository.GetModelListBy
                //(c => c.Specificulture == culture && c.TtsCategoryPosition.Count(
                //    p => p.Position == (int)Constants.CatePosition.Footer) > 0

                //);
            return View(topCates.OrderBy(c => c.Priority).ToList());
        }
    }
}
