// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.IO.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{culture}/template")]
    public class ApiTemplateController :
        BaseApiController
    {
        public ApiTemplateController()
        {
        }
        #region Get

        // GET api/template/id
        [HttpGet]
        [Route("details/{id}")]
        public Task<RepositoryResponse<FETemplateViewModel>> Details(int id)
        {
            return FETemplateViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id);
        }

        // GET api/template/id
        [HttpGet]
        [Route("details/backend/{id}")]
        public Task<RepositoryResponse<BETemplateViewModel>> BEDetails(int id)
        {
            return BETemplateViewModel.Repository.GetSingleModelAsync(
                model => model.Id == id);
        }


        // GET api/Template
        [HttpGet]
        [Route("list")]
        [Route("list/{PageSize:int?}/{PageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{PageSize:int?}/{PageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoTemplateViewModel>>> Get(
            int? PageSize = 15, int? PageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await InfoTemplateViewModel.Repository.GetModelListAsync(orderBy, direction, PageSize, PageIndex).ConfigureAwait(false);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            return data;
        }

        // GET api/Template
        [HttpGet]
        [Route("search/{keyword}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{keyword}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{keyword}/{description}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        [Route("search/{PageSize:int?}/{PageIndex:int?}/{orderBy}/{direction}/{keyword}/{description}")]
        public Task<RepositoryResponse<PaginationModel<InfoTemplateViewModel>>> Search(
            string keyword = null,
            string description = null,
            int? PageSize = null, int? PageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocTemplate, bool>> predicate = model =>
            (string.IsNullOrWhiteSpace(keyword) || (model.FileName.Contains(keyword)))
            && (string.IsNullOrWhiteSpace(description) || (model.FileFolder.Contains(description)));
            return InfoTemplateViewModel
                .Repository
                .GetModelListByAsync(predicate, orderBy, direction, PageSize, PageIndex); // base.Search(predicate, orderBy, direction, PageSize, PageIndex, keyword);
        }

        #endregion Get

        #region Post

        // POST api/template
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<BETemplateViewModel>> Post(BETemplateViewModel model)
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

                    return result;
                }
            }
            return new RepositoryResponse<bool>();
        }

        // GET api/template
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<BETemplateViewModel>>> GetList(RequestPaging request)
        {
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            int.TryParse(request.Key, out int themeId);
            Expression<Func<SiocTemplate, bool>> predicate = model =>
                model.TemplateId == themeId &&
                (string.IsNullOrWhiteSpace(request.Keyword)
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
