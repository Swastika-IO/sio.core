using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib;
using System.Linq;
namespace Swastika.Cms.Mvc.ViewComponents
{
    public class HeaderNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {            
            string culture = ViewBag.culture;
            var topCates = CategoryListItemViewModel.Repository.GetModelListBy
                (c => c.Specificulture == culture && c.SiocCategoryPosition.Count(p => p.PositionId == (int)SWCmsConstants.CatePosition.Top) > 0

                );
            return View(topCates.Data.OrderBy(c=>c.Priority).ToList());
        }
    }
}
