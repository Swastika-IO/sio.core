// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastka.Cms.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
        Roles = "SuperAdmin, Admin")]
    [Produces("application/json")]
    [Route("api/culture")]
    public class ApiCultureController :
        BaseApiController
    {
        public ApiCultureController()
        {
        }

        #region Get

        // GET api/culture/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocCulture>> DeleteAsync(int id)
        {
            var getPage = await ApiCultureViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id);
            if (getPage.IsSucceed)
            {

                return await getPage.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<SiocCulture>()
                {
                    IsSucceed = false
                };
            }
        }

        // GET api/culture/id
        [HttpGet, HttpOptions]
        [Route("sync/{id}")]
        public async Task<RepositoryResponse<List<ApiTemplateViewModel>>> Sync(int id)
        {

            var getTemplate = await ApiTemplateViewModel.Repository.GetModelListByAsync(
                 template => template.TemplateId == id).ConfigureAwait(false);
            foreach (var item in getTemplate.Data)
            {
                await item.SaveModelAsync(true).ConfigureAwait(false);
            }
            return getTemplate;            
        }

        // GET api/cultures/id
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> BEDetails(string viewType, int? id)
        {
            switch (viewType)
            {
                case "be":
                    if (id.HasValue)
                    {
                        var beResult = await ApiCultureViewModel.Repository.GetSingleModelAsync(model => model.Id == id).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocCulture() { Status = (int)SWStatus.Preview };

                        RepositoryResponse<ApiCultureViewModel> result = new RepositoryResponse<ApiCultureViewModel>()
                        {
                            IsSucceed = true,
                            Data = await ApiCultureViewModel.InitViewAsync(model)
                        };
                        return JObject.FromObject(result);
                    }
                default:
                    if (id.HasValue)
                    {
                        var beResult = await ApiCultureViewModel.Repository.GetSingleModelAsync(model => model.Id == id).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocCulture();
                        RepositoryResponse<ApiCultureViewModel> result = new RepositoryResponse<ApiCultureViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ApiCultureViewModel(model) { Status = SWStatus.Preview }
                        };
                        return JObject.FromObject(result);
                    }
            }
        }
        #endregion Get

        #region Post

        // POST api/culture
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiCultureViewModel>> Save([FromBody]ApiCultureViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    GlobalConfigurationService.Instance.RefreshAll();
                }
                return result;
            }
            return new RepositoryResponse<ApiCultureViewModel>();
        }
        // GET api/culture
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<RepositoryResponse<PaginationModel<ApiCultureViewModel>>> GetList([FromBody] RequestPaging request, int? level = 0)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocCulture, bool>> predicate = model =>
                string.IsNullOrWhiteSpace(request.Keyword)
                    || (model.FullName.Contains(request.Keyword)
                    );

            var data = await ApiCultureViewModel.Repository.GetModelListByAsync(
                predicate, request.OrderBy, request.Direction, 
                request.PageSize, request.PageIndex).ConfigureAwait(false);
            return data;
        }

        #endregion Post
    }
}
