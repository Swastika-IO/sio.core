// Licensed to the Sio I/O Foundation under one or more agreements.
// The Sio I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sio.Domain.Core.ViewModels;
using Sio.Cms.Lib.Models.Cms;
using static Sio.Cms.Lib.SioEnums;
using System.Linq.Expressions;
using System.Web;
using Sio.Cms.Lib.ViewModels.SioOrders;
using Microsoft.Extensions.Caching.Memory;
using Sio.Cms.Lib;
using Sio.Cms.Lib.Services;
using System.Linq;

namespace Sio.Cms.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/{culture}/order")]
    public class ApiOrderController :
        BaseGenericApiController<SioCmsContext, SioOrder>
    {
        public ApiOrderController(IMemoryCache memoryCache, Microsoft.AspNetCore.SignalR.IHubContext<Hub.PortalHub> hubContext) : base(memoryCache, hubContext)
        {
        }

        #region Get

        // GET api/order/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SioOrder>> DeleteAsync(int id)
        {
            return await base.DeleteAsync<UpdateViewModel>(
                model => model.Id == id && model.Specificulture == _lang, true);
        }

        // GET api/orders/id
        [HttpGet, HttpOptions]
        [Route("details/{id}/{viewType}")]
        [Route("details/{viewType}")]
        public async Task<ActionResult<JObject>> Details(string viewType, int? id)
        {
            string msg = string.Empty;
            switch (viewType)
            {
                case "portal":
                    if (id.HasValue)
                    {
                        Expression<Func<SioOrder, bool>> predicate = model => model.Id == id && model.Specificulture == _lang;
                        var portalResult = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_{id}", predicate);
                        if (portalResult.IsSucceed)
                        {
                            portalResult.Data.DetailsUrl = SioCmsHelper.GetRouterUrl("Order", new { portalResult.Data.Id }, Request, Url);
                        }

                        return Ok(JObject.FromObject(portalResult));
                    }
                    else
                    {
                        var model = new SioOrder()
                        {
                            Specificulture = _lang,
                            Status = SioService.GetConfig<int>("DefaultStatus")
                        };

                        RepositoryResponse<UpdateViewModel> result = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_default", null, model);
                        return Ok(JObject.FromObject(result));
                    }
                default:
                    if (id.HasValue)
                    {
                        var beResult = await ReadViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        if (beResult.IsSucceed)
                        {
                            beResult.Data.DetailsUrl = SioCmsHelper.GetRouterUrl("Order", new { beResult.Data.Id }, Request, Url);
                        }
                        return Ok(JObject.FromObject(beResult));
                    }
                    else
                    {
                        var model = new SioOrder();
                        RepositoryResponse<ReadViewModel> result = new RepositoryResponse<ReadViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ReadViewModel(model)
                            {
                                Specificulture = _lang,
                                Status = SioOrderStatus.Preview,
                            }
                        };
                        return Ok(JObject.FromObject(result));
                    }
            }
        }


        #endregion Get

        #region Post

        // POST api/order
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<UpdateViewModel>> Save([FromBody]UpdateViewModel model)
        {
            if (model != null)
            {
                model.CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;
                var result = await base.SaveAsync<UpdateViewModel>(model, true);
                return result;
            }
            return new RepositoryResponse<UpdateViewModel>() { Status = 501 };
        }

        // POST api/order
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SioOrder>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SioOrder>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await ReadListItemViewModel.Repository.UpdateFieldsAsync(c => c.Id == id && c.Specificulture == _lang, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }

                }
                return result;
            }
            return new RepositoryResponse<SioOrder>();
        }

        // GET api/order
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<ActionResult<JObject>> GetList(
            [FromBody] RequestPaging request)
        {
            var parsed = HttpUtility.ParseQueryString(request.Query ?? "");
            bool isLevel = int.TryParse(parsed.Get("level"), out int level);
            ParseRequestPagingDate(request);
            Expression<Func<SioOrder, bool>> predicate = model =>
                        model.Specificulture == _lang
                        && (!request.Status.HasValue || model.Status == request.Status.Value)
                        && (string.IsNullOrWhiteSpace(request.Keyword)
                            )
                        && (!request.FromDate.HasValue
                            || (model.CreatedDateTime >= request.FromDate.Value)
                        )
                        && (!request.ToDate.HasValue
                            || (model.CreatedDateTime <= request.ToDate.Value)
                        );
            string key = $"{request.Key}_{request.PageSize}_{request.PageIndex}";
            switch (request.Key)
            {
                case "mvc":
                    var mvcResult = await base.GetListAsync<ReadViewModel>(key, request, predicate);
                    if (mvcResult.IsSucceed)
                    {
                        mvcResult.Data.Items.ForEach(a =>
                        {
                            a.DetailsUrl = SioCmsHelper.GetRouterUrl(
                                "order", new { seoName = a.Id }, Request, Url);
                        });
                    }

                    return Ok(JObject.FromObject(mvcResult));
                case "portal":
                    var portalResult = await base.GetListAsync<UpdateViewModel>(key, request, predicate);
                    if (portalResult.IsSucceed)
                    {
                        portalResult.Data.Items.ForEach(a =>
                        {
                            a.DetailsUrl = SioCmsHelper.GetRouterUrl(
                                "order", new { seoName = a.Id }, Request, Url);
                        });
                    }

                    return Ok(JObject.FromObject(portalResult));
                default:

                    var listItemResult = await base.GetListAsync<ReadListItemViewModel>(key, request, predicate);
                    if (listItemResult.IsSucceed)
                    {
                        listItemResult.Data.Items.ForEach((Action<ReadListItemViewModel>)(a =>
                        {
                            a.DetailsUrl = SioCmsHelper.GetRouterUrl(
                                "order", new { seoName = a.Id }, Request, Url);
                        }));
                    }

                    return JObject.FromObject(listItemResult);
            }
        }

        #endregion Post
    }
}
