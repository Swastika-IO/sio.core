// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.BackEnd;
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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
    [Produces("application/json")]
    [Route("api/{culture}/Article")]
    public class ApiArticleController :
        BaseApiController
    {
        public ApiArticleController()
        {
        }

        #region Get

        // GET api/Articles/id
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> BEDetails(string viewType, string id)
        {
            switch (viewType)
            {
                case "be":
                    if (!string.IsNullOrEmpty(id))
                    {
                        var beResult = await ApiArticleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        if (beResult.IsSucceed)
                        {
                            beResult.Data.DetailsUrl = SwCmsHelper.GetRouterUrl("Article", new { beResult.Data.SeoName }, Request, Url);
                        }
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocArticle()
                        {
                            Specificulture = _lang,
                            Status = GlobalConfigurationService.Instance.CmsConfigurations.DefaultStatus,
                            Priority = ApiArticleViewModel.Repository.Max(a => a.Priority).Data + 1
                        };
                        RepositoryResponse<ApiArticleViewModel> result = new RepositoryResponse<ApiArticleViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ApiArticleViewModel(model)
                        };
                        return JObject.FromObject(result);
                    }
                default:
                    if (!string.IsNullOrEmpty(id))
                    {
                        var beResult = await ApiArticleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        if (beResult.IsSucceed)
                        {
                            beResult.Data.DetailsUrl = SwCmsHelper.GetRouterUrl("Article", new { beResult.Data.SeoName }, Request, Url);
                        }
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocArticle();
                        RepositoryResponse<ApiArticleViewModel> result = new RepositoryResponse<ApiArticleViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ApiArticleViewModel(model) { Specificulture = _lang, Status = SWStatus.Preview }
                        };
                        return JObject.FromObject(result);
                    }
            }
        }

        // GET api/Articles/id
        [HttpGet, HttpOptions]
        [Route("create")]
        public RepositoryResponse<ApiArticleViewModel> Create()
        {
            SiocArticle Article = new SiocArticle()
            {
                //Id = Guid.NewGuid().ToString(),
                Specificulture = _lang

            };
            return new RepositoryResponse<ApiArticleViewModel>()
            {
                IsSucceed = true,
                Data = new ApiArticleViewModel(Article) { Status = SWStatus.Preview }
            };
        }

        // GET api/Articles/id
        [HttpGet, HttpOptions]
        [Route("init/{viewType}")]
        public JObject Init(string viewType)
        {
            SiocArticle Article = new SiocArticle()
            {
                //Id = Guid.NewGuid().ToString(),
                Specificulture = _lang

            };

            switch (viewType)
            {
                case "be":
                    var be = new RepositoryResponse<ApiArticleViewModel>()
                    {
                        IsSucceed = true,
                        Data = new ApiArticleViewModel(Article) { Status = SWStatus.Preview }
                    };
                    return JObject.FromObject(be);
                default:
                    var fe = new RepositoryResponse<ApiArticleViewModel>()
                    {
                        IsSucceed = true,
                        Data = new ApiArticleViewModel(Article) { Status = SWStatus.Preview }
                    };
                    return JObject.FromObject(fe);
            }
        }

        // GET api/Articles/id
        [HttpGet, HttpOptions]
        [Route("recycle/{id}")]
        public async Task<RepositoryResponse<InfoArticleViewModel>> Recycle(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.Status = SWStatus.Deleted;
                return await data.SaveModelAsync().ConfigureAwait(false);
            }
            else
            {
                return new RepositoryResponse<InfoArticleViewModel>() { IsSucceed = false };
            }
        }

        // GET api/Articles/id
        [HttpGet, HttpOptions]
        [Route("restore/{id}")]
        public async Task<RepositoryResponse<InfoArticleViewModel>> Restore(string id)
        {
            var getArticle = InfoArticleViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getArticle.IsSucceed)
            {
                var data = getArticle.Data;
                data.Status = SWStatus.Preview;
                return await data.SaveModelAsync().ConfigureAwait(false);
            }
            else
            {
                return new RepositoryResponse<InfoArticleViewModel>() { IsSucceed = false };
            }
        }

        // GET api/Articles/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocArticle>> Delete(string id)
        {
            var getArticle = ApiArticleViewModel.Repository.GetSingleModel(a => a.Id == id && a.Specificulture == _lang);
            if (getArticle.IsSucceed)
            {
                return await getArticle.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            else
            {
                return new RepositoryResponse<SiocArticle>() { IsSucceed = false };
            }
        }

        // GET api/Articles
        [HttpGet, HttpOptions]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoArticleViewModel>>> Get(int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id", int direction = 0)
        {
            var data = await InfoArticleViewModel.Repository.GetModelListByAsync(
                m => m.Status != (int)SWStatus.Deleted && m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(a => a.DetailsUrl = SwCmsHelper.GetRouterUrl("Article", new { a.SeoName }, Request, Url));
            }
            return data;
        }

        #endregion Get

        #region Post

        // POST api/Articles
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiArticleViewModel>> Save([FromBody] ApiArticleViewModel Article)
        {
            if (Article != null)
            {
                Article.CreatedBy = User.Identity.Name;
                var result = await Article.SaveModelAsync(true).ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    result.Data.DetailsUrl = SwCmsHelper.GetRouterUrl("Article", new { seoName = Article.SeoName }, Request, Url);
                }
                return result;
            }
            return new RepositoryResponse<ApiArticleViewModel>();
        }

        // POST api/category
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SiocArticle>> SaveFields(string id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SiocArticle>();
                foreach (var property in fields)
                {
                     result =  await ApiArticleViewModel.Repository.UpdateFieldsAsync(c => c.Id == id, fields).ConfigureAwait(false);
                }
                return result;
            }
            return new RepositoryResponse<SiocArticle>();
        }

        // GET api/Articles

        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<InfoArticleViewModel>>> GetList([FromBody]RequestPaging request)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocArticle, bool>> predicate = model =>
                model.Specificulture == _lang
                && (!request.Status.HasValue || model.Status == request.Status.Value)
                && (string.IsNullOrWhiteSpace(request.Keyword)
                || (
                    model.Title.Contains(request.Keyword)

                    || model.Excerpt.Contains(request.Keyword)
                    )
                )
                && (!request.FromDate.HasValue
                    || (model.CreatedDateTime >= request.FromDate.Value)
                )
                && (!request.ToDate.HasValue
                    || (model.CreatedDateTime <= request.ToDate.Value)
                );

            var data = await InfoArticleViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(a =>
                {
                    a.DetailsUrl = SwCmsHelper.GetRouterUrl(
                        "Article", new { a.SeoName }, Request, Url);
                });
            }
            return data;
        }

        #endregion Post
    }
}
