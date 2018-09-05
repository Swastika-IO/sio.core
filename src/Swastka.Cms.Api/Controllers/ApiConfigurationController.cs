// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/{culture}/configuration")]
    public class ApiConfigurationController :
        BaseApiController
    {
        public ApiConfigurationController()
        {
        }

        #region Get

        // GET api/configurations/id
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{keyword}")]
        [Route("details/{viewType}")]
        public async Task<JObject> Details(string viewType, string keyword = null)
        {
            switch (viewType)
            {
                default:
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        var feResult = await BEConfigurationViewModel.Repository.GetSingleModelAsync(
                        model => model.Keyword == keyword && model.Specificulture == _lang).ConfigureAwait(false);
                        return JObject.FromObject(feResult);
                    }
                    else
                    {
                        var configuration = new SiocConfiguration()
                        {
                            Specificulture = _lang
                        };

                        var result = new RepositoryResponse<BEConfigurationViewModel>()
                        {
                            IsSucceed = true,
                            Data = (await BEConfigurationViewModel.InitViewAsync(configuration))
                        };
                        return JObject.FromObject(result);
                    }

            }
        }

        // GET api/configurations/id
        [HttpGet, HttpOptions]
        [Route("delete/{keyword}")]
        public async Task<RepositoryResponse<SiocConfiguration>> Delete(string keyword)
        {
            var getConfiguration = BEConfigurationViewModel.Repository.GetSingleModel(a => a.Keyword == keyword && a.Specificulture == _lang);
            if (getConfiguration.IsSucceed)
            {
                return await getConfiguration.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            else
            {
                return new RepositoryResponse<SiocConfiguration>() { IsSucceed = false };
            }
        }

        // GET api/configurations/id
        [HttpGet, HttpOptions]
        [Route("configurations/{category}")]
        public async Task<RepositoryResponse<List<ApiConfigurationViewModel>>> GetSiteConfigurations(string category)
        {
            var result = await ApiConfigurationViewModel.Repository.GetModelListByAsync(a => a.Category == category && a.Specificulture == _lang);
            return result;
        }

        // GET api/configurations
        [HttpGet, HttpOptions]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<BEConfigurationViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , int direction = 0)
        {
            var data = await BEConfigurationViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            return data;
        }

        // GET api/configurations
        [HttpGet, HttpOptions]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<BEConfigurationViewModel>>> Search(
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , int direction = 0)
        {
            Expression<Func<SiocConfiguration, bool>> predicate = model =>
            model.Specificulture == _lang
            && (
            string.IsNullOrWhiteSpace(keyword)
                || model.Keyword.Contains(keyword)
                || model.Description.Contains(keyword)
                || model.Value.Contains(keyword)
                );
            var data = await BEConfigurationViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);

            return data;
        }

        #endregion Get

        #region Post

        // POST api/configurations
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<BEConfigurationViewModel>> Post([FromBody]BEConfigurationViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);

                return result;
            }
            return new RepositoryResponse<BEConfigurationViewModel>();
        }

        // GET api/configurations
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<BEConfigurationViewModel>>> GetList([FromBody]RequestPaging request)
        {
            ParseRequestPagingDate(request);
            string[] cates = { "Site", "System" };
            Expression<Func<SiocConfiguration, bool>> predicate = model =>
                model.Specificulture == _lang
                && (!request.Status.HasValue || model.Category == cates[request.Status.Value])
                && (string.IsNullOrWhiteSpace(request.Keyword)
                || (model.Description.Contains(request.Keyword)
                || model.Value.Contains(request.Keyword)
                || model.Keyword.Contains(request.Keyword)));

            var data = await BEConfigurationViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return data;
        }
        #endregion Post

    }
}
