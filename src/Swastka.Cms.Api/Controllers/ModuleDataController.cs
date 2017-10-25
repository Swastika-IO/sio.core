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
    [Route("api/{culture}/[controller]")]
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
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("{orderBy}/{direction}")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<FEModuleContentData>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await FEModuleContentData.Repository.GetModelListByAsync(m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            return data;
        }



        // GET api/articles
        [HttpGet]
        [Route("{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<FEModuleContentData>>> Search(
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocModuleData, bool>> predicate = model =>
            model.Specificulture == _lang &&
            (
            string.IsNullOrWhiteSpace(keyword)
                || (model.Fields.Contains(keyword) || model.Fields.Contains(keyword))
                );
            return await FEModuleContentData.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
        }

    }
}
