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
using System.Linq.Expressions;
using Sio.Cms.Lib.ViewModels.SioThemes;
using Microsoft.AspNetCore.SignalR;
using Sio.Cms.Hub;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using Sio.Cms.Lib;
using Sio.Cms.Lib.Repositories;

namespace Sio.Cms.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/{culture}/theme")]
    public class ApiThemeController :
        BaseGenericApiController<SioCmsContext, SioTheme>
    {
        public ApiThemeController(IMemoryCache memoryCache, IHubContext<PortalHub> hubContext) : base(memoryCache, hubContext)
        {

        }
        #region Get


        // GET api/theme/id
        [HttpGet, HttpOptions]
        [Route("sync/{id}")]
        public async Task<RepositoryResponse<List<Lib.ViewModels.SioTemplates.UpdateViewModel>>> Sync(int id)
        {

            var getTemplate = await Lib.ViewModels.SioTemplates.UpdateViewModel.Repository.GetModelListByAsync(
                 template => template.ThemeId == id).ConfigureAwait(false);
            foreach (var item in getTemplate.Data)
            {
                await item.SaveModelAsync(true).ConfigureAwait(false);
            }
            return getTemplate;
        }
        
        // GET api/theme/id
        [HttpGet, HttpOptions]
        [Route("export/{id}")]
        public async Task<RepositoryResponse<string>> Export(int id)
        {
            var getTemplate = await ReadViewModel.Repository.GetSingleModelAsync(
                 theme => theme.Id == id).ConfigureAwait(false);
            string exportPath = $"Exports/Themes/{getTemplate.Data.Name}";
            
            // Delete Existing folder
            FileRepository.Instance.DeleteFolder(exportPath);
            // Copy current templates file
            FileRepository.Instance.CopyDirectory($"{getTemplate.Data.TemplateFolder}", $"{exportPath}/Templates");
            // Copy current assets files
            FileRepository.Instance.CopyDirectory($"wwwroot/{getTemplate.Data.AssetFolder}", $"{exportPath}/Assets");
            // Zip to [theme_name].zip
            string filePath = FileRepository.Instance.ZipFolder($"{exportPath}", getTemplate.Data.Name);
            // Delete temp folder
            FileRepository.Instance.DeleteWebFolder($"{exportPath}/Assets");
            FileRepository.Instance.DeleteWebFolder($"{exportPath}/Templates");

            return new RepositoryResponse<string>()
            {
                IsSucceed = !string.IsNullOrEmpty(exportPath),
                Data = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{filePath}"
            };
        }

        // GET api/theme/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SioTheme>> DeleteAsync(int id)
        {
            return await base.DeleteAsync<UpdateViewModel>(
                model => model.Id == id, true);
        }

        // GET api/themes/id
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
                        Expression<Func<SioTheme, bool>> predicate = model => model.Id == id;
                        var portalResult = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_{id}", predicate);
                        if (portalResult.IsSucceed)
                        {
                            portalResult.Data.IsActived = SioService.GetConfig<int>(SioConstants.ConfigurationKeyword.ThemeId, _lang) == portalResult.Data.Id;
                        }
                        return Ok(JObject.FromObject(portalResult));
                    }
                    else
                    {
                        var model = new SioTheme()
                        {
                            Status = SioService.GetConfig<int>("DefaultStatus")
                            ,
                            Priority = UpdateViewModel.Repository.Max(a => a.Priority).Data + 1
                        };

                        RepositoryResponse<UpdateViewModel> result = await base.GetSingleAsync<UpdateViewModel>($"{viewType}_default", null, model);
                        return Ok(JObject.FromObject(result));
                    }
                default:
                    if (id.HasValue)
                    {
                        Expression<Func<SioTheme, bool>> predicate = model => model.Id == id;
                        var result = await base.GetSingleAsync<ReadViewModel>($"{viewType}_{id}", predicate);
                        if (result.IsSucceed)
                        {
                            result.Data.IsActived = SioService.GetConfig<int>(SioConstants.ConfigurationKeyword.ThemeId, _lang) == result.Data.Id;
                        }
                        return Ok(JObject.FromObject(result));
                    }
                    else
                    {
                        var model = new SioTheme()
                        {
                            Status = SioService.GetConfig<int>("DefaultStatus")
                            ,
                            Priority = ReadViewModel.Repository.Max(a => a.Priority).Data + 1
                        };

                        RepositoryResponse<ReadViewModel> result = await base.GetSingleAsync<ReadViewModel>($"{viewType}_default", null, model);
                        return Ok(JObject.FromObject(result));
                    }
            }
        }


        #endregion Get

        #region Post

        // POST api/theme
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<UpdateViewModel>> Save([FromBody]UpdateViewModel model)
        {
            if (model != null)
            {
                model.CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;
                model.Specificulture = _lang;
                var result = await base.SaveAsync<UpdateViewModel>(model, true);
                if (result.IsSucceed)
                {
                    SioService.LoadFromDatabase();
                    SioService.Save();
                }
                return result;
            }
            return new RepositoryResponse<UpdateViewModel>() { Status = 501 };
        }

        // GET api/theme
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<ActionResult<JObject>> GetList(
            [FromBody] RequestPaging request)
        {

            ParseRequestPagingDate(request);
            Expression<Func<SioTheme, bool>> predicate = model =>
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
            string key = $"{request.Key}_{request.PageSize}_{request.PageIndex}";
            switch (request.Key)
            {
                case "portal":
                    var portalResult = await base.GetListAsync<UpdateViewModel>(key, request, predicate);
                    return Ok(JObject.FromObject(portalResult));
                default:

                    var listItemResult = await base.GetListAsync<ReadViewModel>(key, request, predicate);

                    return JObject.FromObject(listItemResult);
            }
        }

        #endregion Post
    }
}
