// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastka.IO.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{culture}/page")]
    [Route("api/{culture}/category")]
    public class ApiCategoryController :
        BaseApiController
    {
        public ApiCategoryController()
        {
        }
        #region Get

        // GET api/category/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> DeleteAsync(int id)
        {
            var getPage =await FECategoryViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
            if (getPage.IsSucceed)
            {

                return await getPage.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = false
                };
            }
        }

        // GET api/pages/id
        [HttpGet]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> BEDetails(string viewType, int? id)
        {
            switch (viewType)
            {
                case "be":
                    if (id.HasValue)
                    {
                        var beResult = await BECategoryViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        if (beResult.IsSucceed)
                        {
                            beResult.Data.DetailsUrl = SwCmsHelper.GetRouterUrl("Page", new { beResult.Data.SeoName }, Request, Url);
                        }
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocCategory() { Specificulture = _lang, Status = (int)SWStatus.Preview };
                        RepositoryResponse<BECategoryViewModel> result = new RepositoryResponse<BECategoryViewModel>()
                        {
                            IsSucceed = true,
                            Data = new BECategoryViewModel(model)
                        };
                        return JObject.FromObject(result);
                    }
                default:
                    if (id.HasValue)
                    {
                        var beResult = await FECategoryViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        if (beResult.IsSucceed)
                        {
                            beResult.Data.DetailsUrl = SwCmsHelper.GetRouterUrl("Page", new { beResult.Data.SeoName }, Request, Url);
                        }
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocCategory();
                        RepositoryResponse<FECategoryViewModel> result = new RepositoryResponse<FECategoryViewModel>()
                        {
                            IsSucceed = true,
                            Data = new FECategoryViewModel(model) { Specificulture = _lang, Status = SWStatus.Preview }
                        };
                        return JObject.FromObject(result);
                    }
            }
        }

        // GET api/category/id
        [HttpGet]
        [Route("byArticle/{id}")]
        [Route("byArticle/{id}/{articleId}")]
        public Task<RepositoryResponse<FECategoryViewModel>> GetByArticle(int id, string articleId = null)
        {
            return FECategoryViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
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
            var data = await InfoCategoryViewModel.Repository.GetModelListByAsync(m => m.Specificulture == _lang, orderBy, direction, PageSize, PageIndex).ConfigureAwait(false); //base.Get(orderBy, direction, PageSize, PageIndex);
            //string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
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
        public Task<RepositoryResponse<PaginationModel<InfoCategoryViewModel>>> Search(
            string keyword = null,
            string description = null,
            int? PageSize = null, int? PageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocCategory, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(keyword) || (model.Title.Contains(keyword)))
            && (string.IsNullOrWhiteSpace(description) || (model.Excerpt.Contains(description)));
            return InfoCategoryViewModel
                .Repository
                .GetModelListByAsync(predicate, orderBy, direction, PageSize, PageIndex); // base.Search(predicate, orderBy, direction, PageSize, PageIndex, keyword);
        }

        #endregion Get

        #region Post

        // POST api/category
        [Authorize]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<BECategoryViewModel>> Post([FromBody]BECategoryViewModel model)
        {
            if (model != null)
            {
                model.CreatedBy = User.Identity.Name;
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<BECategoryViewModel>();
        }

        // POST api/category
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<bool>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<bool>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await InfoCategoryViewModel.Repository.UpdateFieldsAsync(c => c.Id == id && c.Specificulture == _lang, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }
                    
                }
                return result;
            }
            return new RepositoryResponse<bool>();
        }

        // GET api/category
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<RepositoryResponse<PaginationModel<InfoCategoryViewModel>>> GetList([FromBody] RequestPaging request, int? level = 0)
        {
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);

            Expression<Func<SiocCategory, bool>> predicate = model =>
                model.Specificulture == _lang
                && model.Level == level
                && (string.IsNullOrWhiteSpace(request.Keyword)
                    || (model.Title.Contains(request.Keyword)
                    || model.Excerpt.Contains(request.Keyword)))
                && (!request.FromDate.HasValue
                    || (model.CreatedDateTime >= request.FromDate.Value.ToUniversalTime())
                )
                && (!request.ToDate.HasValue
                    || (model.CreatedDateTime <= request.ToDate.Value.ToUniversalTime())
                )
                    ;

            var data = await InfoCategoryViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(a =>
                {
                    a.DetailsUrl = SwCmsHelper.GetRouterUrl(
                        "Page", new { a.SeoName }, Request, Url);
                    a.Childs.ForEach(c =>
                    {
                        c.DetailsUrl = SwCmsHelper.GetRouterUrl(
                            "Page", new { c.SeoName }, Request, Url);
                    }
                );
                }
                );
            }
            return data;
        }

        #endregion Post
    }
}
