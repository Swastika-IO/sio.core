// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
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
    [Route("api/{culture}/module")]
    public class ApiModuleController :
        BaseApiController
    {
        public ApiModuleController()
        {
        }


        #region Get

        // GET api/module/details/spa/1
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> DetailsByType(string viewType, int? id = null)
        {
            switch (viewType)
            {
                case "spa":
                    if (id.HasValue)
                    {
                        var spaResult = await SpaModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        return JObject.FromObject(spaResult);
                    }
                    else
                    {
                        var model = new SiocModule() { Specificulture = _lang, Status = GlobalConfigurationService.Instance.CmsConfigurations.DefaultStatus, };

                        RepositoryResponse<SpaModuleViewModel> result = new RepositoryResponse<SpaModuleViewModel>()
                        {
                            IsSucceed = true,
                            Data = await SpaModuleViewModel.InitViewAsync(model)
                        };
                        return JObject.FromObject(result);
                    }
                case "be":
                    if (id.HasValue)
                    {
                        var beResult = await ApiModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocModule()
                        {
                            Specificulture = _lang,
                            Status = GlobalConfigurationService.Instance.CmsConfigurations.DefaultStatus
                        ,
                            Priority = ApiModuleViewModel.Repository.Max(a => a.Priority).Data + 1
                        };

                        RepositoryResponse<ApiModuleViewModel> result = new RepositoryResponse<ApiModuleViewModel>()
                        {
                            IsSucceed = true,
                            Data = await ApiModuleViewModel.InitViewAsync(model)
                        };
                        return JObject.FromObject(result);
                    }
                default:
                    if (id.HasValue)
                    {
                        var beResult = await FEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocModule();
                        RepositoryResponse<FEModuleViewModel> result = new RepositoryResponse<FEModuleViewModel>()
                        {
                            IsSucceed = true,
                            Data = new FEModuleViewModel(model) { Specificulture = _lang, Status = SWStatus.Preview }
                        };
                        return JObject.FromObject(result);
                    }
            }
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocModule>> DeleteAsync(int id)
        {
            var getModule = await FEModuleViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
            if (getModule.IsSucceed)
            {

                return await getModule.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<SiocModule>()
                {
                    IsSucceed = false
                };
            }
        }


        // GET api/articles/id
        [HttpGet, HttpOptions]
        [Route("byArticle/{id}")]
        [Route("byArticle/{id}/{articleId}")]
        public async Task<RepositoryResponse<FEModuleViewModel>> GetByArticle(int id, string articleId = null)
        {
            var result = await FEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
            return result;
        }

        // GET api/modules
        [HttpGet, HttpOptions]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , int direction = 0)
        {
            var data = await InfoModuleViewModel.Repository.GetModelListByAsync(m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            return data;
        }

        // GET api/modules
        [HttpGet, HttpOptions]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}/{description}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}/{description}")]
        public Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> Search(
            string keyword = null,
            string description = null,
            int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , int direction = 0)
        {
            Expression<Func<SiocModule, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(keyword) || (model.Title.Contains(keyword)))
            && (string.IsNullOrWhiteSpace(description) || (model.Description.Contains(description)));
            return InfoModuleViewModel
                .Repository
                .GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex);
        }

        #endregion Get

        #region Post

        // POST api/module
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiModuleViewModel>> Post([FromBody]ApiModuleViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<ApiModuleViewModel>();
        }

        // POST api/module
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SiocModule>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SiocModule>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await InfoModuleViewModel.Repository.UpdateFieldsAsync(c => c.Id == id && c.Specificulture == _lang, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }

                }
                return result;
            }
            return new RepositoryResponse<SiocModule>();
        }

        // GET api/module
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> GetList([FromBody] RequestPaging request, int? level = 0)
        {

            Expression<Func<SiocModule, bool>> predicate = model =>
                model.Specificulture == _lang
                && (!request.Status.HasValue || model.Status == request.Status.Value)
                && (string.IsNullOrWhiteSpace(request.Keyword)
                    || (model.Title.Contains(request.Keyword)
                    || model.Description.Contains(request.Keyword)))
                && (!request.FromDate.HasValue
                    || (model.LastModified >= request.FromDate.Value.ToUniversalTime())
                )
                && (!request.ToDate.HasValue
                    || (model.LastModified <= request.ToDate.Value.ToUniversalTime())
                )
                    ;

            var data = await InfoModuleViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
            return data;
        }

        #endregion Post
    }
}
