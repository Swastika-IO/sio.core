using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastka.Cms.Api.Controllers;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Core.Models;
using Swastika.Cms.Lib.ViewModels;

namespace Swastka.IO.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{culture}/Modules")]
    public class ModulesController :
        BaseAPIController<SiocCmsContext, SiocArticle>
    {
        // GET api/articles/id
        [HttpGet]
        [Route("full/{id}")]
        public async Task<RepositoryResponse<ModuleWithDataViewModel>> FullDetails(int id)
        {
            return await ModuleWithDataViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang);
        }

        // GET api/articles/id
        [HttpPost]
        [Route("addToArticle")]
        public async Task<RepositoryResponse<bool>> AddToArticle([FromBody]ArticleModuleFEViewModel view)
        {
            if (view.IsActived)
            {
                var addResult = await view.SaveModelAsync();
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = addResult.IsSucceed,
                    Data = addResult.IsSucceed
                };
            }
            else
            {
                return await view.RemoveModelAsync();
            }
            
        }
    }
}