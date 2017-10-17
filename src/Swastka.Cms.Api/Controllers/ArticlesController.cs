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
    [Route("api/[controller]")]
    public class ArticlesController : 
        BaseAPIController<Stag_swastika_ioContext, SiocArticle, DisplayArticleViewModel>
    {

        

        // POST api/articles
        [HttpPost]
        public async Task<RepositoryResponse<DisplayArticleViewModel>> Post([FromBody]DisplayArticleViewModel model)
        {
            return await base.PostAsync(model);
        }

        // GET api/articles/id
        [HttpGet]
        [Route("{id}")]
        public async Task<RepositoryResponse<DisplayArticleViewModel>> Get(string id)
        {
            return await base.GetAsync(model => model.Id == id);
        }

        // GET api/articles/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> Delete(string id)
        {
            return await base.DeleteAsync(model => model.Id == id);
        }

        // GET api/articles
        [HttpGet]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<DisplayArticleViewModel>>> Get(
            int? pageSize, int pageIndex, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {            
            return await base.Get(orderBy, direction, pageSize, pageIndex);
        }



        // GET api/articles
        [HttpGet]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<DisplayArticleViewModel>>> Search(
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocArticle, bool>> predicate = model => string.IsNullOrWhiteSpace(keyword)
                || (model.Title.Contains(keyword) || model.Content.Contains(keyword) 
                );
            return await base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
        }

    }
}
