// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{culture}/module-data")]
    public class ApiModuleDataController :
        BaseApiController
    {
        public ApiModuleDataController()
        {
        }

        // GET api/module-data/id
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{moduleId}/{id}")]
        [Route("details/{viewType}/{moduleId}")]
        public async Task<RepositoryResponse<ApiModuleDataViewModel>> DetailsAsync(string viewType, int moduleId, string id = null)
        {

            if (string.IsNullOrEmpty(id))
            {
                var getModule = await InfoModuleViewModel.Repository.GetSingleModelAsync(
        m => m.Id == moduleId && m.Specificulture == _lang).ConfigureAwait(false);
                if (getModule.IsSucceed)
                {
                    var model = new SiocModuleData(
                        )
                    {
                        ModuleId = moduleId,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    };
                    return new RepositoryResponse<ApiModuleDataViewModel>() { IsSucceed = true, Data = await ApiModuleDataViewModel.InitViewAsync(model) };
                }
                else
                {
                    return new RepositoryResponse<ApiModuleDataViewModel>() { IsSucceed = false };
                }
            }
            else
            {
                var be = await ApiModuleDataViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang);
                return be;
            }
        }

        // GET api/module-data/id
        [HttpGet, HttpOptions]
        [Route("edit/{id}")]
        public Task<RepositoryResponse<InfoModuleDataViewModel>> Edit(string id)
        {
            return InfoModuleDataViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang);
        }

        // GET api/module-data/create/id
        [HttpGet, HttpOptions]
        [Route("create/{moduleId}")]
        public async Task<RepositoryResponse<BEModuleDataViewModel>> CreateAsync(int moduleId)
        {
            var getModule = await InfoModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new BEModuleDataViewModel(
                    new SiocModuleData()
                    {
                        ModuleId = moduleId,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    });
                return new RepositoryResponse<BEModuleDataViewModel>()
                {
                    IsSucceed = true,
                    Data = ModuleData
                };
            }
            else
            {
                return new RepositoryResponse<BEModuleDataViewModel>()
                {
                    IsSucceed = false,
                    Data = null,
                    Exception = getModule.Exception,
                    Errors = getModule.Errors
                };
            }
        }

        // GET api/module-data/create/id
        [HttpGet, HttpOptions]
        [Route("init-by-name/{moduleName}")]
        public async Task<RepositoryResponse<ApiModuleDataViewModel>> InitViewAsync(string moduleName)
        {
            var getModule = await InfoModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Name == moduleName && m.Specificulture == _lang).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new ApiModuleDataViewModel(
                    new SiocModuleData()
                    {
                        ModuleId = getModule.Data.Id,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    });
                return new RepositoryResponse<ApiModuleDataViewModel>()
                {
                    IsSucceed = true,
                    Data = ModuleData
                };
            }
            else
            {
                return new RepositoryResponse<ApiModuleDataViewModel>()
                {
                    IsSucceed = false,
                    Data = null,
                    Exception = getModule.Exception,
                    Errors = getModule.Errors
                };
            }
        }

        // GET api/module-data/create/id
        [HttpGet, HttpOptions]
        [Route("init/{moduleId}")]
        public async Task<RepositoryResponse<ApiModuleDataViewModel>> InitByIdAsync(int moduleId)
        {
            var getModule = await InfoModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new ApiModuleDataViewModel(
                    new SiocModuleData()
                    {
                        ModuleId = getModule.Data.Id,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    });
                return new RepositoryResponse<ApiModuleDataViewModel>()
                {
                    IsSucceed = true,
                    Data = ModuleData
                };
            }
            else
            {
                return new RepositoryResponse<ApiModuleDataViewModel>()
                {
                    IsSucceed = false,
                    Data = null,
                    Exception = getModule.Exception,
                    Errors = getModule.Errors
                };
            }
        }

        // GET api/module-data/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public Task<RepositoryResponse<SiocModuleData>> Delete(string id)
        {
            return InfoModuleDataViewModel.Repository.RemoveModelAsync(model => model.Id == id && model.Specificulture == _lang);
        }

        // GET api/module-data
        [HttpGet, HttpOptions]
        [Route("{moduleId}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("{moduleId}/{orderBy}/{direction}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> Get(
            int moduleId,
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "moduleId"
            , int direction = 0)
        {
            var result = await InfoModuleDataViewModel.Repository.GetModelListByAsync(
                m => m.ModuleId == moduleId && m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

        // GET api/module-data
        [HttpGet, HttpOptions]
        [Route("getByArticle/{articleId}/{moduleId}")]
        [Route("getByArticle/{articleId}/{moduleId}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("getByArticle/{articleId}/{moduleId}/{orderBy}/{direction}")]
        [Route("getByArticle/{articleId}/{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> GetByArticle(
            string articleId, int moduleId,
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "moduleId"
            , int direction = 0)
        {
            var result = await InfoModuleDataViewModel.Repository.GetModelListByAsync(
                m => m.ModuleId == moduleId && m.ArticleId == articleId && m.Specificulture == _lang,
                orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

        // GET api/module-data
        [HttpGet, HttpOptions]
        [Route("{moduleId}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> Search(int moduleId, 
            string keyword = null, 
            int? pageSize = null, int? pageIndex = null, string orderBy = "Id", 
            int direction = 0)
        {
            Expression<Func<SiocModuleData, bool>> predicate = model =>
                model.ModuleId == moduleId
                && model.Specificulture == _lang
                && (string.IsNullOrWhiteSpace(keyword) || (model.Fields.Contains(keyword)));

            var result = await InfoModuleDataViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

        #region Post

        // POST api/moduleData

        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiModuleDataViewModel>> Post([FromBody]ApiModuleDataViewModel data)
        {
            if (data != null)
            {
                var result = await data.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<ApiModuleDataViewModel>();
        }

        // POST api/module
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SiocModuleData>> SaveFields(string id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SiocModuleData>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await InfoModuleDataViewModel.Repository.UpdateFieldsAsync(c => c.Id == id && c.Specificulture == _lang, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }

                }
                return result;
            }
            return new RepositoryResponse<SiocModuleData>();
        }



        // GET api/moduleData
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> GetList(
            [FromBody] RequestPaging request, int? level = 0)
        {
            int.TryParse(request.Key, out int moduleId);
            Expression<Func<SiocModuleData, bool>> predicate = model =>
                model.Specificulture == _lang
                && model.ModuleId == moduleId
                //&& (string.IsNullOrWhiteSpace(request.Keyword)
                //    || (model.Title.Contains(request.Keyword)
                //    || model.Description.Contains(request.Keyword)))
                && (!request.FromDate.HasValue
                    || (model.CreatedDateTime >= request.FromDate.Value.ToUniversalTime())
                )
                && (!request.ToDate.HasValue
                    || (model.CreatedDateTime <= request.ToDate.Value.ToUniversalTime())
                )
                    ;

            var data = await InfoModuleDataViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return data;
        }

        #endregion Post
    }
}