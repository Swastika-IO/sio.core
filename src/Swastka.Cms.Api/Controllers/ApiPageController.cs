// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastka.Cms.Api.Controllers
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
        public async Task<RepositoryResponse<SiocCategory>> DeleteAsync(int id)
        {
            var getPage = await FECategoryViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
            if (getPage.IsSucceed)
            {

                return await getPage.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<SiocCategory>()
                {
                    IsSucceed = false
                };
            }
        }

        // GET api/pages/id
        [HttpGet]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<ActionResult<JObject>> Details(string viewType, int? id)
        {
            switch (viewType)
            {
                case "be":
                    if (id.HasValue)
                    {
                        var beResult = await ApiCategoryViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        if (beResult.IsSucceed)
                        {
                            beResult.Data.DetailsUrl = SwCmsHelper.GetRouterUrl("Page", new { beResult.Data.SeoName }, Request, Url);
                        }
                        return Ok(JObject.FromObject(beResult));
                    }
                    else
                    {
                        var model = new SiocCategory()
                        {
                            Specificulture = _lang,
                            Status = (int)SWStatus.Preview,
                            PageSize = 20
                            ,
                            Priority = ApiCategoryViewModel.Repository.Max(a => a.Priority).Data + 1
                        };

                        RepositoryResponse<ApiCategoryViewModel> result = new RepositoryResponse<ApiCategoryViewModel>()
                        {
                            IsSucceed = true,
                            Data = await ApiCategoryViewModel.InitAsync(model)
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
                            Data = new FECategoryViewModel(model)
                            {
                                Specificulture = _lang,
                                Status = SWStatus.Preview,
                                PageSize = 20
                            }
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
            var data = await InfoCategoryViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, orderBy, direction, PageSize, PageIndex).ConfigureAwait(false);
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
                .GetModelListByAsync(predicate, orderBy, direction, PageSize, PageIndex);
        }

        #endregion Get

        #region Post

        // POST api/category
        [Authorize]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiCategoryViewModel>> Post([FromBody]ApiCategoryViewModel model)
        {
            if (model != null)
            {
                model.CreatedBy = User.Identity.Name;
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<ApiCategoryViewModel>();
        }

        // POST api/category
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SiocCategory>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SiocCategory>() { IsSucceed = true };
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
            return new RepositoryResponse<SiocCategory>();
        }

        // GET api/category
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<JObject> GetList(
            [FromBody] RequestPaging request, int? level = 0)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocCategory, bool>> predicate = model =>
                        model.Specificulture == _lang
                        && (string.IsNullOrWhiteSpace(request.Keyword)
                            || (model.Title.Contains(request.Keyword)
                            || model.Excerpt.Contains(request.Keyword)))
                        && (!request.FromDate.HasValue
                            || (model.CreatedDateTime >= request.FromDate.Value)
                        )
                        && (!request.ToDate.HasValue
                            || (model.CreatedDateTime <= request.ToDate.Value)
                        );
            switch (request.Key)
            {
                case "fe":
                    var fedata = await FECategoryViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
                    if (fedata.IsSucceed)
                    {
                        fedata.Data.Items.ForEach(a =>
                        {
                            a.DetailsUrl = SwCmsHelper.GetRouterUrl(
                                "Page", new { a.SeoName }, Request, Url);
                        });
                    }
                    return JObject.FromObject(fedata);
                case "be":
                    
                    var bedata = await ApiCategoryViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
                    if (bedata.IsSucceed)
                    {
                        bedata.Data.Items.ForEach(a =>
                        {
                            a.DetailsUrl = SwCmsHelper.GetRouterUrl(
                                "Page", new { a.SeoName }, Request, Url);
                        });
                    }
                    return JObject.FromObject(bedata);
                default:
                   
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
                            });
                        });
                    }
                    return JObject.FromObject(data);
            }
        }

        #endregion Post
    }
}
