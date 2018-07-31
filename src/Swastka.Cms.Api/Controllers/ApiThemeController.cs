// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Api;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
        Roles = "SuperAdmin")]
    [Produces("application/json")]
    [Route("api/{culture}/theme")]
    public class ApiThemeController :
        BaseApiController
    {
        public ApiThemeController()
        {
        }

        #region Get

        // GET api/theme/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocTheme>> DeleteAsync(int id)
        {
            var getPage = await ApiThemeViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id);
            if (getPage.IsSucceed)
            {

                return await getPage.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<SiocTheme>()
                {
                    IsSucceed = false
                };
            }
        }

        // GET api/theme/id
        [HttpGet]
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

        // GET api/themes/id
        [HttpGet]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> BEDetails(string viewType, int? id)
        {
            switch (viewType)
            {
                case "be":
                    if (id.HasValue)
                    {
                        var beResult = await ApiThemeViewModel.Repository.GetSingleModelAsync(model => model.Id == id).ConfigureAwait(false);
                        beResult.Data.Specificulture = _lang;
                        beResult.Data.IsActived = GlobalConfigurationService.Instance.GetLocalInt(SWCmsConstants.ConfigurationKeyword.ThemeId, _lang, 0) == beResult.Data.Id;
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocTheme() { Status = (int)SWStatus.Preview };

                        RepositoryResponse<ApiThemeViewModel> result = new RepositoryResponse<ApiThemeViewModel>()
                        {
                            IsSucceed = true,
                            Data = await ApiThemeViewModel.InitAsync(model)
                        };
                        result.Data.Specificulture = _lang;
                        return JObject.FromObject(result);
                    }
                default:
                    if (id.HasValue)
                    {
                        var beResult = await ApiThemeViewModel.Repository.GetSingleModelAsync(model => model.Id == id).ConfigureAwait(false);
                        beResult.Data.Specificulture = _lang;
                        beResult.Data.IsActived = GlobalConfigurationService.Instance.GetLocalInt(SWCmsConstants.ConfigurationKeyword.ThemeId, _lang, 0) == beResult.Data.Id;
                        return JObject.FromObject(beResult);
                    }
                    else
                    {
                        var model = new SiocTheme();
                        RepositoryResponse<ApiThemeViewModel> result = new RepositoryResponse<ApiThemeViewModel>()
                        {
                            IsSucceed = true,
                            Data = new ApiThemeViewModel(model) { Status = SWStatus.Preview }
                        };
                        result.Data.Specificulture = _lang;
                        return JObject.FromObject(result);
                    }
            }
        }
        #endregion Get

        #region Post

        // POST api/theme
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiThemeViewModel>> Save([FromBody]ApiThemeViewModel model)
        {
            if (model != null)
            {
                model.CreatedBy = User.Claims.ToList().Find(c=>c.Type=="Username")?.Value;
                model.Specificulture = _lang;
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<ApiThemeViewModel>();
        }

        // POST api/theme
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SiocTheme>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SiocTheme>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await InfoThemeViewModel.Repository.UpdateFieldsAsync(
                            c => c.Id == id, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }

                }
                return result;
            }
            return new RepositoryResponse<SiocTheme>();
        }

        // GET api/theme
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<RepositoryResponse<PaginationModel<InfoThemeViewModel>>> GetList([FromBody] RequestPaging request, int? level = 0)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocTheme, bool>> predicate = model =>
                string.IsNullOrWhiteSpace(request.Keyword)
                    || (model.Name.Contains(request.Keyword)
                    )
                && (!request.FromDate.HasValue
                    || (model.CreatedDateTime >= request.FromDate.Value)
                )
                && (!request.ToDate.HasValue
                    || (model.CreatedDateTime <= request.ToDate.Value)
                )
                    ;

            var data = await InfoThemeViewModel.Repository.GetModelListByAsync(
                predicate, request.OrderBy, request.Direction, 
                request.PageSize, request.PageIndex).ConfigureAwait(false);
            return data;
        }

        #endregion Post
    }
}
