// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
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
    [Route("api/{culture}/template")]
    public class ApiTemplateController :
        BaseApiController
    {

        public ApiTemplateController()
        {
        }
        #region Get

        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{themeId}/{folderType}/{id}")]
        [Route("details/{viewType}/{themeId}/{folderType}")]
        public async Task<RepositoryResponse<ApiTemplateViewModel>> DetailsAsync(string viewType, int themeId, string folderType, int? id)
        {
            if (id.HasValue)
            {
                var beResult = await ApiTemplateViewModel.Repository.GetSingleModelAsync(
                    model => model.Id == id && model.TemplateId == themeId).ConfigureAwait(false);                
                return beResult;
            }
            else
            {
                var getTheme = await InfoThemeViewModel.Repository.GetSingleModelAsync(t => t.Id == themeId);
                if (getTheme.IsSucceed)
                {
                    var model = new SiocTemplate()
                    {
                        Status = (int)SWStatus.Preview,
                        TemplateId = themeId,
                        TemplateName = getTheme.Data.Name,
                        Extension = SWCmsConstants.Parameters.TemplateExtension,
                        FolderType = folderType
                    };
                    
                    RepositoryResponse<ApiTemplateViewModel> result = new RepositoryResponse<ApiTemplateViewModel>()
                    {
                        IsSucceed = true,
                        Data = await ApiTemplateViewModel.InitViewAsync(model)
                    };
                    result.Data.Specificulture = _lang;
                    return result;
                }
                else
                {
                    return new RepositoryResponse<ApiTemplateViewModel>();
                }
            }
        }

        // GET api/category/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocTemplate>> DeleteAsync(int id)
        {
            var getPage = await ApiTemplateViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id);
            if (getPage.IsSucceed)
            {

                return await getPage.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<SiocTemplate>()
                {
                    IsSucceed = false
                };
            }
        }


        #endregion Get

        #region Post

        // POST api/template
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiTemplateViewModel>> Save(
            [FromBody] ApiTemplateViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<ApiTemplateViewModel>();
        }

        // POST api/template
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<SiocTemplate>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<SiocTemplate>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await InfoTemplateViewModel.Repository.UpdateFieldsAsync(c => c.Id == id, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }

                }
                return result;
            }
            return new RepositoryResponse<SiocTemplate>();
        }

        // GET api/template
        [HttpPost, HttpOptions]
        [Route("list/{themeId}")]
        public async Task<RepositoryResponse<PaginationModel<ApiTemplateViewModel>>> GetList(
            int themeId,
            [FromBody]RequestPaging request
            )
        {
            Expression<Func<SiocTemplate, bool>> predicate = model =>
                model.TemplateId == themeId
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

            var data = await ApiTemplateViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return data;
        }

        #endregion Post
    }
}
