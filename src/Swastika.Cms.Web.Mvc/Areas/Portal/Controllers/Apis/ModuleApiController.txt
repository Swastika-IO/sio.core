using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TTS.Web.Areas.Portal.Controllers.Apis
{
    [Route("api/{culture}/Portal/Module")]
    public class ModuleApiController : Controller
    {
        [HttpGet]
        [Route("AjaxAddModuleData/{moduleId}")]
        public async Task<InfoModuleDataViewModel> AjaxAddModuleData(int moduleId)
        {
            string _lang = RouteData.Values["culture"].ToString();
            var module = await BEModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang);
            if (module.IsSucceed)
            {
                var ModuleData = new InfoModuleDataViewModel()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ModuleId = moduleId,
                    Specificulture = _lang,

                    Fields = module.Data?.Fields
                };
                return ModuleData;
            }
            else
            {
                return null;
            }
        }

        
    }
}
