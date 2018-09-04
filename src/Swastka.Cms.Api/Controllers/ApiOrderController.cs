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
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
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
    [Route("api/{culture}/order")]
    public class ApiOrderController :
        BaseApiController
    {
        public ApiOrderController()
        {
        }
        #region Get

        // GET api/order/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocOrder>> DeleteAsync(int id)
        {
            var getPage = await ApiOrderViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
            if (getPage.IsSucceed)
            {

                return await getPage.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<SiocOrder>()
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
                case "be":
                    if (id.HasValue)
                    {
                        var beResult = await ApiOrderViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);

                        return Ok(JObject.FromObject(beResult));
                    }
                    else
                    {
                        var model = new SiocOrder()
                        {
                            Specificulture = _lang,
                            Status = GlobalConfigurationService.Instance.CmsConfigurations.DefaultStatus
                        };

                        RepositoryResponse<ApiOrderViewModel> result = new RepositoryResponse<ApiOrderViewModel>()
                        {
                            IsSucceed = true,
                            Data = await ApiOrderViewModel.InitViewAsync(model)
                        };
                        return JObject.FromObject(result);
                    }
                default:
                    if (id.HasValue)
                    {
                        var beResult = await ApiOrderViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocOrder();
                        RepositoryResponse<ApiOrderViewModel> result = new RepositoryResponse<ApiOrderViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ApiOrderViewModel(model)
                            {
                                Specificulture = _lang,
                                Status = (int)SWStatus.Preview
                            }
                        };
                        return JObject.FromObject(result);
                    }
            }
        }

        // GET api/order/id
        [HttpGet, HttpOptions]
        [Route("byArticle/{id}")]
        [Route("byArticle/{id}/{articleId}")]
        public Task<RepositoryResponse<ApiOrderViewModel>> GetByArticle(int id, string articleId = null)
        {
            return ApiOrderViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id && model.Specificulture == _lang);
        }

        // GET api/Order
        [HttpGet, HttpOptions]
        [Route("list")]
        [Route("list/{PageSize:int?}/{PageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{PageSize:int?}/{PageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoOrderViewModel>>> Get(
            int? PageSize = 15, int? PageIndex = 0, string orderBy = "Id"
            , int direction = 0)
        {
            var data = await InfoOrderViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, orderBy, direction, PageSize, PageIndex).ConfigureAwait(false);
            return data;
        }

        #endregion Get

        #region Post

        // POST api/order
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiOrderViewModel>> Post([FromBody]ApiOrderViewModel model)
        {
            if (model != null)
            {
                model.CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<ApiOrderViewModel>();
        }

        // POST api/order
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SiocOrder>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SiocOrder>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await InfoOrderViewModel.Repository.UpdateFieldsAsync(c => c.Id == id && c.Specificulture == _lang, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }

                }
                return result;
            }
            return new RepositoryResponse<SiocOrder>();
        }

        // GET api/order
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<JObject> GetList(
            [FromBody] RequestPaging request)
        {
            if (!request.FromDate.HasValue)
            {
                request.FromDate = DateTime.Now;
            }
            ParseRequestPagingDate(request);
            Expression<Func<SiocOrder, bool>> predicate;
            predicate = model =>
                model.Specificulture == _lang
                 && model.Status == request.Status
                && (string.IsNullOrWhiteSpace(request.Keyword)
                    || (model.SiocCustomer.FullName.Contains(request.Keyword)
                    || model.SiocCustomer.PhoneNumber.Contains(request.Keyword))
                    )
                && (
                    (!request.FromDate.HasValue)
                    || (model.CreatedDateTime >= request.FromDate.Value)
                )
                && (
                    (!request.ToDate.HasValue)
                    || (model.CreatedDateTime <= request.ToDate.Value)
                );
            var fedata = await ApiOrderViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return JObject.FromObject(fedata);
        }

        #endregion Post
    }
}
