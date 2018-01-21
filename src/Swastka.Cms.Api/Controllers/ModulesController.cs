using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using System.Linq.Expressions;
using System;
using Swastika.Domain.Core.ViewModels;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.Models.Cms;

namespace Swastka.IO.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{culture}/module")]
    public class ApiModuleController :
        BaseApiController<SiocCmsContext, SiocArticle>
    {
        // GET api/articles/id
        [HttpGet]
        [Route("details/{id}")]
        public async Task<RepositoryResponse<FEModuleViewModel>> Details(int id)
        {
            var result = await FEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang);
            if (result.IsSucceed)
            {
                result.Data.LoadData();
            }
            return result;
        }

        // GET api/articles/id
        [HttpGet]
        [Route("byArticle/{id}")]
        [Route("byArticle/{id}/{articleId}")]
        public async Task<RepositoryResponse<FEModuleViewModel>> GetByArticle(int id, string articleId = null)
        {
            var result = await FEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang);            
            return result;
        }


        // GET api/articles/id
        [HttpPost]
        [Route("addToArticle")]
        public async Task<RepositoryResponse<bool>> AddToArticle([FromBody]FEArticleModuleViewModel view)
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

        // GET api/modules
        [HttpGet]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await InfoModuleViewModel.Repository.GetModelListByAsync(m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            //data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", domain, this.Url.Action("Details", "modules", new { id = d.Id })));
            //data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", domain, this.Url.Action("Edit", "modules", new { id = d.Id })));
            return data;
        }

        // GET api/modules
        [HttpGet]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}/{description}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}/{description}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> Search(
            string keyword = null,
            string description = null,
            int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocModule, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(keyword) || (model.Title.Contains(keyword)))
            && (string.IsNullOrWhiteSpace(description) || (model.Description.Contains(description)));
            return await InfoModuleViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
        }
    }
}