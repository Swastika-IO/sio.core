// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastka.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/portal-page")]
    public class ApiPortalPageController :
        BaseApiController
    {
        public ApiPortalPageController()
        {
        }
        #region Get

        // GET api/PortalPage/id
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = "SuperAdmin")]
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocPortalPage>> DeleteAsync(int id)
        {
            var getPage = await InfoPortalPageViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id);
            if (getPage.IsSucceed)
            {

                var result =  await getPage.Data.RemoveModelAsync(true);
                return result;
            }
            else
            {
                return new RepositoryResponse<SiocPortalPage>()
                {
                    IsSucceed = false
                };
            }
        }

        // GET api/pages/id
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<ActionResult<JObject>> Details(string viewType, int? id)
        {
            switch (viewType)
            {
                case "fe":
                    if (id.HasValue)
                    {
                        var beResult = await FEPortalPageViewModel.Repository.GetSingleModelAsync(model => model.Id == id).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocPortalPage();
                        RepositoryResponse<FEPortalPageViewModel> result = new RepositoryResponse<FEPortalPageViewModel>()
                        {
                            IsSucceed = true,
                            Data = new FEPortalPageViewModel(model)
                            {
                                Specificulture = _lang,
                                Status = SWStatus.Preview,
                            }
                        };
                        return JObject.FromObject(result);
                    }
                case "be":
                    if (id.HasValue)
                    {
                        var beResult = await ApiPortalPageViewModel.Repository.GetSingleModelAsync(model => model.Id == id).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocPortalPage();
                        RepositoryResponse<ApiPortalPageViewModel> result = new RepositoryResponse<ApiPortalPageViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ApiPortalPageViewModel(model)
                            {
                                Specificulture = _lang,
                                Status = SWStatus.Preview,
                            }
                        };
                        return JObject.FromObject(result);
                    }
                default:
                    if (id.HasValue)
                    {
                        var beResult = await InfoPortalPageViewModel.Repository.GetSingleModelAsync(model => model.Id == id).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocPortalPage();
                        RepositoryResponse<InfoPortalPageViewModel> result = new RepositoryResponse<InfoPortalPageViewModel>()
                        {
                            IsSucceed = true,
                            Data = new InfoPortalPageViewModel(model)
                            {
                                Specificulture = _lang,
                                Status = SWStatus.Preview,
                            }
                        };
                        return JObject.FromObject(result);
                    }
            }
        }

        #endregion Get

        #region Post

        // POST api/PortalPage
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiPortalPageViewModel>> Post([FromBody]ApiPortalPageViewModel model)
        {
            if (model != null)
            {
                model.CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<ApiPortalPageViewModel>();
        }

        // POST api/PortalPage
        [HttpPost, HttpOptions]
        [Route("update-infos")]
        public async Task<RepositoryResponse<List<InfoPortalPageViewModel>>> UpdateInfos([FromBody]List<InfoPortalPageViewModel> models)
        {
            if (models != null)
            {
                return await InfoPortalPageViewModel.UpdateInfosAsync(models);
            }
            else
            {
                return new RepositoryResponse<List<InfoPortalPageViewModel>>();
            }
        }
        
        // POST api/PortalPage
        [HttpPost, HttpOptions]
        [Route("update-child-infos")]
        public async Task<RepositoryResponse<List<NavPortalPageViewModel>>> UpdateNavInfos([FromBody]List<NavPortalPageViewModel> models)
        {
            if (models != null)
            {
                return await NavPortalPageViewModel.UpdateInfosAsync(models);
            }
            else
            {
                return new RepositoryResponse<List<NavPortalPageViewModel>>();
            }
        }

        // GET api/PortalPage
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<JObject> GetList(
            [FromBody] RequestPaging request, int? level = 0)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocPortalPage, bool>> predicate = model =>
                        (!level.HasValue || model.Level == level.Value)
                        && (string.IsNullOrWhiteSpace(request.Keyword)
                            || (model.TextDefault.Contains(request.Keyword)
                            || model.Description.Contains(request.Keyword)))
                        && (!request.FromDate.HasValue
                            || (model.CreatedDateTime >= request.FromDate.Value)
                        )
                        && (!request.ToDate.HasValue
                            || (model.CreatedDateTime <= request.ToDate.Value)
                        );
            switch (request.Key)
            {
                case "fe":
                    var fedata = await FEPortalPageViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
                    return JObject.FromObject(fedata);
                case "be":

                    var bedata = await ApiPortalPageViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
                    return JObject.FromObject(bedata);
                default:

                    var data = await InfoPortalPageViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
                    return JObject.FromObject(data);
            }
        }

        #endregion Post
    }
}
