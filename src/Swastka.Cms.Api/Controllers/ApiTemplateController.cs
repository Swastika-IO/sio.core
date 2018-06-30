// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
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
        Roles = "SuperAdmin")]
    [Produces("application/json")]
    [Route("api/{culture}/template")]
    public class ApiTemplateController :
        BaseApiController
    {

        public ApiTemplateController()
        {
        }
        #region Get

        [HttpGet]
        [Route("details/{viewType}/{themeId}/{folderType}/{id}")]
        [Route("details/{viewType}/{themeId}/{folderType}")]
        public async Task<RepositoryResponse<BETemplateViewModel>> DetailsAsync(string viewType, int themeId, string folderType, int? id)
        {
            if (id.HasValue)
            {
                var beResult = await BETemplateViewModel.Repository.GetSingleModelAsync(
                    model => model.Id == id && model.TemplateId == themeId).ConfigureAwait(false);
                beResult.Data.Specificulture = _lang;
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
                    
                    RepositoryResponse<BETemplateViewModel> result = new RepositoryResponse<BETemplateViewModel>()
                    {
                        IsSucceed = true,
                        Data = await BETemplateViewModel.InitAsync(model)
                    };
                    result.Data.Specificulture = _lang;
                    return result;
                }
                else
                {
                    return new RepositoryResponse<BETemplateViewModel>();
                }
            }
        }

        // GET api/category/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> DeleteAsync(int id)
        {
            var getPage = await BETemplateViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id);
            if (getPage.IsSucceed)
            {

                return await getPage.Data.RemoveModelAsync(true);
            }
            else
            {
                return new RepositoryResponse<bool>()
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
        public async Task<RepositoryResponse<BETemplateViewModel>> Save(
            [FromBody] BETemplateViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<BETemplateViewModel>();
        }

        // POST api/template
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<bool>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                foreach (var property in fields)
                {
                    var result = await InfoTemplateViewModel.Repository.UpdateFieldsAsync(c => c.Id == id, fields).ConfigureAwait(false);
                }
            }
            return new RepositoryResponse<bool>();
        }

        // GET api/template
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{folder}")]
        public async Task<RepositoryResponse<PaginationModel<BETemplateViewModel>>> GetList(
            [FromBody]RequestPaging request,
            [FromRoute] string folder = null
            )
        {
            int.TryParse(request.Key, out int themeId);
            Expression<Func<SiocTemplate, bool>> predicate = model =>
                model.TemplateId == themeId
                && (string.IsNullOrEmpty(folder) || (model.FolderType == folder))
                && (string.IsNullOrWhiteSpace(request.Keyword)
                    ||
                    (
                        model.FileName.Contains(request.Keyword)
                        || model.FileFolder.Contains(request.Keyword)
                        || model.FolderType == request.Keyword
                    ));

            var data = await BETemplateViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return data;
        }

        #endregion Post
    }
}
