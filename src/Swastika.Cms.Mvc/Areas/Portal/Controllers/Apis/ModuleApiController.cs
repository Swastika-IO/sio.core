using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TTS.Web.Areas.Portal.Controllers.Apis
{
    [Route("api/{culture}/Portal/Module")]
    public class ModuleApiController : Controller
    {
        [Route("AjaxAddModuleData/{moduleId}")]
        public async Task<ModuleViewModel> AjaxAddModuleData(int moduleId)
        {
            string _lang = RouteData.Values["culture"].ToString();
            var module = await ModuleRepository.GetInstance().GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang, Constants.ViewModelType.BackEnd);
            if (module != null)
            {
                var ModuleData = new ModuleDataViewModel(_lang, module.Columns)
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ModuleId = moduleId,
                    Specificulture = _lang,
                    Fields = module.Fields
                };
                return module;
            }
            else
            {
                return null;
            }
        }

        
    }
}
