using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Swastika.Domain.Core.ViewModels;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    [Route("api/{culture}/article")]
    public class ApiArticleController :
        BaseApiController<SiocCmsContext, SiocArticle>
    {
        #region Get
        // GET api/articles/id
        [HttpGet]
        [Route("details/{id}")]
        public async Task<RepositoryResponse<FEArticleViewModel>> Details(string id)
        {
            var result = await FEArticleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
            if (result.IsSucceed)
            {
                result.Data.Domain = this._domain;
            }
            return result;
        }

        // GET api/articles/id
        [HttpGet]
        [Route("details/backend/{id}")]
        public async Task<RepositoryResponse<BEArticleViewModel>> BEDetails(string id)
        {
            var result = await BEArticleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
            if (result.IsSucceed)
            {
                result.Data.Domain = this._domain;
            }
            return result;
        }

        // GET api/articles/id
        [HttpGet]
        [Route("create")]
        public RepositoryResponse<BEArticleViewModel> Create()
        {
            SiocArticle article = new SiocArticle()
            {
                //Id = Guid.NewGuid().ToString(),                
                Specificulture = _lang
            };
            return new RepositoryResponse<BEArticleViewModel>()
            {
                IsSucceed = true,
                Data = new BEArticleViewModel(article) { Domain = this._domain }

            };
        }

        // GET api/articles/id
        [HttpGet]
        [Route("recycle/{id}")]
        public async Task<RepositoryResponse<InfoArticleViewModel>> Recycle(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.IsDeleted = true;
                return await data.SaveModelAsync();
            }
            else
            {
                return new RepositoryResponse<InfoArticleViewModel>() { IsSucceed = false };
            }
        }

        // GET api/articles/id
        [HttpGet]
        [Route("restore/{id}")]
        public async Task<RepositoryResponse<InfoArticleViewModel>> Restore(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.IsDeleted = false;
                return await data.SaveModelAsync();
            }
            else
            {
                return new RepositoryResponse<InfoArticleViewModel>() { IsSucceed = false };
            }
        }


        // GET api/articles/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> Delete(string id)
        {
            var getArticle = BEArticleViewModel.Repository.GetSingleModel(a => a.Id == id && a.Specificulture == _lang);
            if (getArticle.IsSucceed)
            {
                return await getArticle.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<bool>() { IsSucceed = false };
            }
        }

        // GET api/articles
        [HttpGet]
        //[Authorize]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoArticleViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await InfoArticleViewModel.Repository.GetModelListByAsync(
                m => !m.IsDeleted && m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(a =>
                {
                    a.DetailsUrl = SWCmsHelper.GetRouterUrl("Article", new { a.SeoName }, Request, Url);
                    ;
                }
                );


            }
            return data;
        }

        // GET api/articles
        [HttpGet]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<InfoArticleViewModel>>> Search(
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocArticle, bool>> predicate = model =>
            model.Specificulture == _lang
            && !model.IsDeleted
            && (
            string.IsNullOrWhiteSpace(keyword)
                || (model.Title.Contains(keyword) || model.Content.Contains(keyword))
                );
            var data = await InfoArticleViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
            //if (data.IsSucceed)
            //{
            //    data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", _domain, this.Url.Action("Details", "articles", new { id = d.Id })));
            //    data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", _domain, this.Url.Action("Edit", "articles", new { id = d.Id })));
            //    data.Data.Items.ForEach(d => d.Domain = _domain);
            //}
            return data;
        }

        // GET api/articles
        [HttpGet]
        [Route("draft/{keyword}")]
        [Route("draft/{pageSize:int?}/{pageIndex:int?}")]
        [Route("draft/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("draft/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<InfoArticleViewModel>>> Draft(
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocArticle, bool>> predicate = model =>
            model.Specificulture == _lang

            && model.IsDeleted
            && (
            string.IsNullOrWhiteSpace(keyword)
                || (model.Title.Contains(keyword) || model.Content.Contains(keyword))
                );
            var data = await InfoArticleViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
            //if (data.IsSucceed)
            //{
            //    data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", _domain, this.Url.Action("Details", "articles", new { id = d.Id })));
            //    data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", _domain, this.Url.Action("Edit", "articles", new { id = d.Id })));
            //    data.Data.Items.ForEach(d => d.Domain = _domain);
            //}
            return data;
        }
        #endregion

        #region Post

        // POST api/articles
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<BEArticleViewModel>> Post([FromBody]BEArticleViewModel model)
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
            return new RepositoryResponse<BEArticleViewModel>();

        }


        // GET api/articles
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<InfoArticleViewModel>>> GetList(RequestPaging request)
        {
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            if (string.IsNullOrEmpty(request.Keyword))
            {
                
                var data = await InfoArticleViewModel.Repository.GetModelListByAsync(
                m => !m.IsDeleted && m.Specificulture == _lang, request.OrderBy, request.Direction, request.PageSize, request.PageIndex); 
                if (data.IsSucceed)
                {
                    data.Data.Items.ForEach(a =>
                    {
                        a.DetailsUrl = SWCmsHelper.GetRouterUrl(
                            "Article", new { a.SeoName }, Request, Url);
                        a.Domain = domain;
                        
                    }
                    );


                }
                return data;
               
            }
            else
            {
                Expression<Func<SiocArticle, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(request.Keyword) ||
                (
                    model.Title.Contains(request.Keyword)
                    || model.Excerpt.Contains(request.Keyword)
                )
                );
                var data = await InfoArticleViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex);
                if (data.IsSucceed)
                {
                    data.Data.Items.ForEach(a =>
                    {
                        a.DetailsUrl = SWCmsHelper.GetRouterUrl(
                            "Article", new { a.SeoName }, Request, Url);
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
