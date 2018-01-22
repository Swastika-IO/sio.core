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
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib;

namespace Swastka.IO.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{culture}/category")]
    public class ApiCategoryController :
        BaseApiController<SiocCmsContext, SiocArticle>
    {
        #region Get
        // GET api/category/id
        [HttpGet]
        [Route("details/{id}")]
        public async Task<RepositoryResponse<FECategoryViewModel>> Details(int id)
        {
            var result = await FECategoryViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
            return result;
        }

        // GET api/category/id
        [HttpGet]
        [Route("details/backend/{id}")]
        public async Task<RepositoryResponse<BECategoryViewModel>> BEDetails(int id)
        {
            var result = await BECategoryViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
            return result;
        }

        // GET api/category/id
        [HttpGet]
        [Route("byArticle/{id}")]
        [Route("byArticle/{id}/{articleId}")]
        public async Task<RepositoryResponse<FECategoryViewModel>> GetByArticle(int id, string articleId = null)
        {
            var result = await FECategoryViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
            return result;
        }

        // GET api/Category
        [HttpGet]
        [Route("list")]
        [Route("list/{PageSize:int?}/{PageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{PageSize:int?}/{PageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoCategoryViewModel>>> Get(
            int? PageSize = 15, int? PageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await InfoCategoryViewModel.Repository.GetModelListByAsync(m => m.Specificulture == _lang, orderBy, direction, PageSize, PageIndex); //base.Get(orderBy, direction, PageSize, PageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            //data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", domain, this.Url.Action("Details", "Category", new { id = d.Id })));
            //data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", domain, this.Url.Action("Edit", "Category", new { id = d.Id })));
            return data;
        }

        // GET api/Category
        [HttpGet]
        [Route("search/{keyword}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{keyword}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{keyword}/{description}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{orderBy}/{direction}/{keyword}/{description}")]
        public async Task<RepositoryResponse<PaginationModel<InfoCategoryViewModel>>> Search(
            string keyword = null,
            string description = null,
            int? PageSize = null, int? PageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocCategory, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(keyword) || (model.Title.Contains(keyword)))
            && (string.IsNullOrWhiteSpace(description) || (model.Excerpt.Contains(description)));
            return await InfoCategoryViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, PageSize, PageIndex); // base.Search(predicate, orderBy, direction, PageSize, PageIndex, keyword);
        }
        #endregion

        #region Post

        // POST api/category
        [HttpPost]
        [Route("save")]
        public async Task<RepositoryResponse<BECategoryViewModel>> Post([FromBody]BECategoryViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true);
                if (result.IsSucceed)
                {
                    result.Data.Domain = this._domain;
                }
                return result;
            }
            return new RepositoryResponse<BECategoryViewModel>();

        }

        // GET api/category
        [HttpPost]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<InfoCategoryViewModel>>> GetList(RequestPaging request)
        {
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            if (string.IsNullOrEmpty(request.Keyword))
            {

                var data = await InfoCategoryViewModel.Repository.GetModelListByAsync(
                m => !m.IsDeleted && m.Specificulture == _lang, request.OrderBy, request.Direction, request.PageSize, request.PageIndex);
                if (data.IsSucceed)
                {
                    data.Data.Items.ForEach(a =>
                    {
                        a.DetailsUrl = SWCmsHelper.GetRouterUrl(
                            "Page", new { a.SeoName }, Request, Url);
                        a.Domain = domain;

                    }
                    );


                }
                return data;

            }
            else
            {
                Expression<Func<SiocCategory, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(request.Keyword) ||
                (
                    model.Title.Contains(request.Keyword)
                    || model.Excerpt.Contains(request.Keyword)
                )
                );
                var data = await InfoCategoryViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex);
                if (data.IsSucceed)
                {
                    data.Data.Items.ForEach(a =>
                    {
                        a.DetailsUrl = SWCmsHelper.GetRouterUrl(
                            "Page", new { a.SeoName }, Request, Url);
                        a.Domain = domain;

                    }
                    );
                }
                return data;
            }

        }
        #endregion
    }
}