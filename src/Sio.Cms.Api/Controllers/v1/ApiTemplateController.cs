// Licensed to the Sio I/O Foundation under one or more agreements.
// The Sio I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sio.Domain.Core.ViewModels;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using static Sio.Cms.Lib.SioEnums;
using System.Linq.Expressions;
using Microsoft.Extensions.Caching.Memory;
using Sio.Cms.Lib.ViewModels.SioTemplates;
using Sio.Cms.Lib;
using Newtonsoft.Json.Linq;

namespace Sio.Cms.Api.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "SuperAdmin, Admin")]
    [Produces("application/json")]
    [Route("api/v1/{culture}/template")]
    public class ApiTemplateController :
            BaseGenericApiController<SioCmsContext, SioTemplate>
    {
        public ApiTemplateController(IMemoryCache memoryCache, Microsoft.AspNetCore.SignalR.IHubContext<Hub.PortalHub> hubContext) : base(memoryCache, hubContext)
        {
        }
        #region Get
        
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{themeId}/{folderType}/{id}")]
        [Route("details/{viewType}/{themeId}/{folderType}")]
        public async Task<ActionResult<RepositoryResponse<UpdateViewModel>>> DetailsAsync(string viewType, int themeId, string folderType, int? id)
        {

            if (id.HasValue)
            {
                Expression<Func<SioTemplate, bool>> predicate = model => model.Id == id;
                var portalResult = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_{id}", predicate);
                return Ok(JObject.FromObject(portalResult));
            }
            else
            {
                var getTheme = await Lib.ViewModels.SioThemes.ReadViewModel.Repository.GetSingleModelAsync(t => t.Id == themeId);
                if (getTheme.IsSucceed)
                {
                    var model = new SioTemplate()
                    {
                        Status = (int)SioContentStatus.Preview,
                        ThemeId = themeId,
                        ThemeName = getTheme.Data.Name,
                        Extension = SioService.GetConfig<string>("TemplateExtension"),
                        FolderType = folderType
                    };

                    RepositoryResponse<UpdateViewModel> result = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_default", null, model);
                    return Ok(JObject.FromObject(result));
                }
                else
                {
                    return new RepositoryResponse<Lib.ViewModels.SioTemplates.UpdateViewModel>();
                }
            }
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SioTemplate>> DeleteAsync(int id)
        {
            return await base.DeleteAsync<UpdateViewModel>(
                model => model.Id == id, true);
        }


        #endregion Get

        #region Post

        // POST api/template
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<Lib.ViewModels.SioTemplates.UpdateViewModel>> Save(
            [FromBody] Lib.ViewModels.SioTemplates.UpdateViewModel model)
        {
            return await base.SaveAsync<UpdateViewModel>(model, true);
        }

        // GET api/template
        [HttpPost, HttpOptions]
        [Route("list/{themeId}")]
        public async Task<ActionResult<JObject>> GetList(
            int themeId,
            [FromBody]RequestPaging request
            )
        {
            Expression<Func<SioTemplate, bool>> predicate = model =>
                model.ThemeId == themeId
                 && (string.IsNullOrWhiteSpace(request.Key)
                    ||
                    (
                        model.FolderType == (request.Key)
                    ))
                && (string.IsNullOrWhiteSpace(request.Keyword)
                    ||
                    (
                         model.FileName.Contains(request.Keyword)
                        || model.FileFolder.Contains(request.Keyword)
                        || model.FolderType == request.Keyword
                    ));

            string key = $"{request.Key}_{request.PageSize}_{request.PageIndex}";
            switch (request.Key)
            {
                case "mvc":
                    var mvcResult = await base.GetListAsync<ReadViewModel>(key, request, predicate);
                    return Ok(JObject.FromObject(mvcResult));
                case "portal":
                    var portalResult = await base.GetListAsync<UpdateViewModel>(key, request, predicate);
                    return Ok(JObject.FromObject(portalResult));
                default:
                    var listItemResult = await base.GetListAsync<UpdateViewModel>(key, request, predicate);

                    return JObject.FromObject(listItemResult);
            }
        }

        #endregion Post
    }
}
