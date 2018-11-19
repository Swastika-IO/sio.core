// Licensed to the Sio I/O Foundation under one or more agreements.
// The Sio I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sio.Domain.Core.ViewModels;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using static Sio.Cms.Lib.SioEnums;
using System.Linq.Expressions;
using System.Web;
using Sio.Cms.Lib.ViewModels.SioLanguages;
using Microsoft.Extensions.Caching.Memory;

namespace Sio.Cms.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/{culture}/language")]
    public class ApiLanguageController :
         BaseGenericApiController<SioCmsContext, SioLanguage>
    {
        public ApiLanguageController(IMemoryCache memoryCache, Microsoft.AspNetCore.SignalR.IHubContext<Hub.PortalHub> hubContext) : base(memoryCache, hubContext)
        {
        }

        #region Get

        // GET api/language/keyword
        [HttpGet, HttpOptions]
        [Route("delete/{keyword}")]
        public async Task<RepositoryResponse<SioLanguage>> DeleteAsync(string keyword)
        {
            return await base.DeleteAsync<UpdateViewModel>(
                model => model.Keyword == keyword && model.Specificulture == _lang, true);
        }

        // GET api/languages/keyword
        [HttpGet, HttpOptions]
        [Route("details/{keyword}/{viewType}")]
        [Route("details/{viewType}")]
        public async Task<ActionResult<JObject>> Details(string viewType, string keyword)
        {
            string msg = string.Empty;
            switch (viewType)
            {
                case "portal":
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        Expression<Func<SioLanguage, bool>> predicate = model => model.Keyword == keyword && model.Specificulture == _lang;
                        var portalResult = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_{keyword}", predicate);
                        return Ok(JObject.FromObject(portalResult));
                    }
                    else
                    {
                        var model = new SioLanguage()
                        {
                            Specificulture = _lang,
                            Status = SioService.GetConfig<int>("DefaultStatus"),
                            Priority = UpdateViewModel.Repository.Max(a => a.Priority).Data + 1
                        };

                        RepositoryResponse<UpdateViewModel> result = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_default", null, model);
                        return Ok(JObject.FromObject(result));
                    }
                default:
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        var beResult = await ReadMvcViewModel.Repository.GetSingleModelAsync(model => model.Keyword == keyword && model.Specificulture == _lang).ConfigureAwait(false);
                        return Ok(JObject.FromObject(beResult));
                    }
                    else
                    {
                        var model = new SioLanguage();
                        RepositoryResponse<ReadMvcViewModel> result = new RepositoryResponse<ReadMvcViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ReadMvcViewModel(model)
                            {
                                Specificulture = _lang,
                                Status = SioContentStatus.Preview,
                            }
                        };
                        return Ok(JObject.FromObject(result));
                    }
            }
        }


        #endregion Get

        #region Post

        // POST api/language
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

        // GET api/language
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<ActionResult<JObject>> GetList(
            [FromBody] RequestPaging request)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SioLanguage, bool>> predicate = model =>
                        model.Specificulture == _lang
                        //&& (!request.Status.HasValue || model.Status == request.Status.Value)
                        && (string.IsNullOrWhiteSpace(request.Keyword)
                            || (model.Keyword.Contains(request.Keyword)
                            || model.Description.Contains(request.Keyword)))
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
                    var mvcResult = await base.GetListAsync<ReadMvcViewModel>(key, request, predicate);
                 
                    return Ok(JObject.FromObject(mvcResult));
                case "portal":
                    var portalResult = await base.GetListAsync<UpdateViewModel>(key, request, predicate);
                   
                    return Ok(JObject.FromObject(portalResult));
                default:

                    var listItemResult = await base.GetListAsync<ReadMvcViewModel>(key, request, predicate);
                    return JObject.FromObject(listItemResult);
            }
        }

        #endregion Post
    }
}
