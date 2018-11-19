// Licensed to the Sio I/O Foundation under one or more agreements.
// The Sio I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sio.Domain.Core.ViewModels;
using Sio.Cms.Lib.Models.Cms;
using System.Linq.Expressions;
using Sio.Cms.Lib.ViewModels.SioModuleDatas;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Sio.Cms.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/{culture}/module-data")]
    public class ApiModuleDataController :
        BaseGenericApiController<SioCmsContext, SioModuleData>
    {
        public ApiModuleDataController(IMemoryCache memoryCache, Microsoft.AspNetCore.SignalR.IHubContext<Hub.PortalHub> hubContext) : base(memoryCache, hubContext)
        {
        }

        // GET api/module-data/id
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{moduleId}/{id}")]
        [Route("details/{viewType}/{moduleId}")]
        public async Task<RepositoryResponse<UpdateViewModel>> DetailsAsync(string viewType, int moduleId, string id = null)
        {

            if (string.IsNullOrEmpty(id))
            {

                var getModule = await Lib.ViewModels.SioModules.ReadListItemViewModel.Repository.GetSingleModelAsync(
        m => m.Id == moduleId && m.Specificulture == _lang).ConfigureAwait(false);
                if (getModule.IsSucceed)
                {
                    var model = new SioModuleData(
                        )
                    {
                        ModuleId = moduleId,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    };
                    RepositoryResponse<UpdateViewModel> result = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_default", null, model);

                    return result;
                }
                else
                {
                    return new RepositoryResponse<UpdateViewModel>() { IsSucceed = false };
                }
            }
            else
            {
                Expression<Func<SioModuleData, bool>> predicate = model => model.Id == id && model.Specificulture == _lang;
                var portalResult = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_{id}", predicate);
                return portalResult;
            }
        }

        // GET api/module-data/id
        [HttpGet, HttpOptions]
        [Route("edit/{id}")]
        public Task<RepositoryResponse<ReadViewModel>> Edit(string id)
        {
            return base.GetSingleAsync<ReadViewModel>($"read_{id}", model => model.Id == id && model.Specificulture == _lang);
        }

        // GET api/module-data/create/id
        [HttpGet, HttpOptions]
        [Route("create/{moduleId}")]
        public async Task<RepositoryResponse<UpdateViewModel>> CreateAsync(int moduleId)
        {
            var getModule = await Lib.ViewModels.SioModules.ReadListItemViewModel.Repository.GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new UpdateViewModel(
                    new SioModuleData()
                    {
                        ModuleId = moduleId,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    });
                return new RepositoryResponse<UpdateViewModel>()
                {
                    IsSucceed = true,
                    Data = ModuleData
                };
            }
            else
            {
                return new RepositoryResponse<UpdateViewModel>()
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
        public async Task<RepositoryResponse<UpdateViewModel>> InitViewAsync(string moduleName)
        {
            var getModule = await Lib.ViewModels.SioModules.ReadListItemViewModel.Repository.GetSingleModelAsync(
                m => m.Name == moduleName && m.Specificulture == _lang).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new UpdateViewModel(
                    new SioModuleData()
                    {
                        ModuleId = getModule.Data.Id,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    });
                return new RepositoryResponse<UpdateViewModel>()
                {
                    IsSucceed = true,
                    Data = ModuleData
                };
            }
            else
            {
                return new RepositoryResponse<UpdateViewModel>()
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
        public async Task<RepositoryResponse<UpdateViewModel>> InitByIdAsync(int moduleId)
        {
            var getModule = await Lib.ViewModels.SioModules.ReadListItemViewModel.Repository.GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new UpdateViewModel(
                    new SioModuleData()
                    {
                        ModuleId = getModule.Data.Id,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    });
                return new RepositoryResponse<UpdateViewModel>()
                {
                    IsSucceed = true,
                    Data = ModuleData
                };
            }
            else
            {
                return new RepositoryResponse<UpdateViewModel>()
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
        public async Task<RepositoryResponse<SioModuleData>> DeleteAsync(string id)
        {
            return await base.DeleteAsync<ReadViewModel>(model => model.Id == id && model.Specificulture == _lang);
        }

        #region Post

        // POST api/moduleData

        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<UpdateViewModel>> Post([FromBody]UpdateViewModel data)
        {
            return await base.SaveAsync<UpdateViewModel>(data, true);
        }

        // GET api/moduleData
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<ActionResult<RepositoryResponse<PaginationModel<ReadViewModel>>>> GetList(
            [FromBody] RequestPaging request, int? level = 0)
        {
            int.TryParse(request.Key, out int moduleId);
            string key = $"{request.Key}_{request.PageSize}_{request.PageIndex}";
            Expression<Func<SioModuleData, bool>> predicate = model =>
                model.Specificulture == _lang
                && model.ModuleId == moduleId
                && (!request.FromDate.HasValue
                    || (model.CreatedDateTime >= request.FromDate.Value.ToUniversalTime())
                )
                && (!request.ToDate.HasValue
                    || (model.CreatedDateTime <= request.ToDate.Value.ToUniversalTime())
                )
                    ;
            var portalResult = await base.GetListAsync<ReadViewModel>(key, request, predicate);

            return Ok(JObject.FromObject(portalResult));
        }

        #endregion Post
    }
}
