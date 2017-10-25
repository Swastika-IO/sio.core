using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Common.Helper;
using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    [Route("api/{culture}/moduleData")]
    public class ModuleDataController :
        BaseAPIController<SiocCmsContext, SiocArticle>
    {


        // GET api/articles/id
        [HttpGet]
        [Route("{id}")]
        public async Task<RepositoryResponse<FEModuleContentData>> Details(string id)
        {
            return await FEModuleContentData.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
        }

        // GET api/articles/id
        [HttpGet]
        [Route("edit/{id}")]
        public async Task<RepositoryResponse<FEModuleContentData>> Edit(string id)
        {
            return await FEModuleContentData.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
        }

        // GET api/articles/id
        [HttpGet]
        [Route("create")]
        public RepositoryResponse<FEModuleContentData> Create()
        {
            SiocModuleData article = new SiocModuleData()
            {
                Specificulture = _lang
            };
            return new RepositoryResponse<FEModuleContentData>()
            {
                IsSucceed = true,
                Data = new FEModuleContentData(article)
            };
        }


        // GET api/articles/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> Delete(string id)
        {
            return await FEModuleContentData.Repository.RemoveModelAsync(model => model.Id == id);
        }

        // GET api/articles
        [HttpGet]
        [Route("{moduleId}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("{moduleId}/{orderBy}/{direction}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<FEModuleContentData>>> Get(
            int moduleId,
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "moduleId"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var result = await FEModuleContentData.Repository.GetModelListByAsync(
                m => m.ModuleId == moduleId && m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }



        // GET api/articles
        [HttpGet]
        [Route("{moduleId}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<FEModuleContentData>>> Search(
             int moduleId,
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocModuleData, bool>> predicate = model =>
             model.ModuleId == moduleId &&
            model.Specificulture == _lang &&
            (
            string.IsNullOrWhiteSpace(keyword)
                || (model.Fields.Contains(keyword) || model.Fields.Contains(keyword))
                );
            var result = await FEModuleContentData.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

    }
}
