using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Swastika.IO.Cms.Lib.Models;
using Swastika.IO.Cms.Lib.ViewModels;
using Swastika.Domain.Core.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    [Route("api/{culture}/[controller]")]
    public class ArticlesController :
        BaseAPIController<SiocCmsContext, SiocArticle>
    {
        // POST api/articles
        [HttpPost]
        [Route("save")]
        public async Task<RepositoryResponse<ArticleBEViewModel>> Post([FromBody]ArticleBEViewModel model)
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
            return new RepositoryResponse<ArticleBEViewModel>();

        }

        // GET api/articles/id
        [HttpGet]
        [Route("{id}")]
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
        [Route("edit/{id}")]
        public async Task<RepositoryResponse<ArticleBEViewModel>> Edit(string id)
        {
            var result =  await ArticleBEViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
            if (result.IsSucceed)
            {
                result.Data.Domain = this._domain;
            }
            return result;
        }

        // GET api/articles/id
        [HttpGet]
        [Route("create")]
        public RepositoryResponse<ArticleBEViewModel> Create()
        {
            SiocArticle article = new SiocArticle()
            {
                //Id = Guid.NewGuid().ToString(),                
                Specificulture = _lang
            };
            return new RepositoryResponse<ArticleBEViewModel>()
            {
                IsSucceed = true,
                Data = new ArticleBEViewModel(article) { Domain = this._domain }

            };
        }

        // GET api/articles/id
        [HttpGet]
        [Route("recycle/{id}")]
        public async Task<RepositoryResponse<ArticleListItemViewModel>> Recycle(string id)
        {
            var getArticle = ArticleListItemViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.IsDeleted = true;
                return await data.SaveModelAsync();
            }
            else
            {
                return new RepositoryResponse<ArticleListItemViewModel>() { IsSucceed = false };
            }
        }

        // GET api/articles/id
        [HttpGet]
        [Route("restore/{id}")]
        public async Task<RepositoryResponse<ArticleListItemViewModel>> Restore(string id)
        {
            var getArticle = ArticleListItemViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.IsDeleted = false;
                return await data.SaveModelAsync();
            }
            else
            {
                return new RepositoryResponse<ArticleListItemViewModel>() { IsSucceed = false };
            }
        }


        // GET api/articles/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> Delete(string id)
        {
            var getArticle = ArticleBEViewModel.Repository.GetSingleModel(a => a.Id == id && a.Specificulture == _lang);
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
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("{orderBy}/{direction}")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<ArticleListItemViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await ArticleListItemViewModel.Repository.GetModelListByAsync(
                m => !m.IsDeleted && m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", _domain, this.Url.Action("Details", "articles", new { id = d.Id })));
                data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", _domain, this.Url.Action("Edit", "articles", new { id = d.Id })));
                data.Data.Items.ForEach(d => d.Domain = _domain);
            }            
            return data;
        }

        // GET api/articles
        [HttpGet]
        [Route("{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<ArticleListItemViewModel>>> Search(
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
            var data = await ArticleListItemViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", _domain, this.Url.Action("Details", "articles", new { id = d.Id })));
                data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", _domain, this.Url.Action("Edit", "articles", new { id = d.Id })));
                data.Data.Items.ForEach(d => d.Domain = _domain);
            }
            return data;
        }

        // GET api/articles
        [HttpGet]
        [Route("draft/{keyword}")]
        [Route("draft/{pageSize:int?}/{pageIndex:int?}")]
        [Route("draft/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("draft/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<ArticleListItemViewModel>>> Draft(
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
            var data = await ArticleListItemViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", _domain, this.Url.Action("Details", "articles", new { id = d.Id })));
                data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", _domain, this.Url.Action("Edit", "articles", new { id = d.Id })));
                data.Data.Items.ForEach(d => d.Domain = _domain);
            }
            return data;
        }

    }
}
