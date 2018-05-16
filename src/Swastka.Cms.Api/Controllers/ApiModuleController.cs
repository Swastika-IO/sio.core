// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
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
    [Route("api/{culture}/module")]
    public class ApiModuleController :
        BaseApiController
    {
        public ApiModuleController()
        {
        }

        #region Get

        // GET api/articles/id
        [HttpGet]
        [Route("details/{id}")]
        public async Task<RepositoryResponse<FEModuleViewModel>> Details(int id)
        {
            var result = await FEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
            if (result.IsSucceed)
            {
                result.Data.LoadData();
            }
            return result;
        }

        // GET api/module/details/spa/1
        [HttpGet]
        [Route("details/{viewType}/{id}")]
        public async Task<JObject> DetailsByType(string viewType, int id)
        {
            switch (viewType)
            {
                case "spa":
                    var spaResult = await SpaModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                    return JObject.FromObject(spaResult);

                case "be":
                    var beResult = await BEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                    return JObject.FromObject(beResult);

                default:
                    var feResult = await FEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                    return JObject.FromObject(feResult);
            }
        }

        // GET api/articles/id
        [HttpGet]
        [Route("byArticle/{id}")]
        [Route("byArticle/{id}/{articleId}")]
        public async Task<RepositoryResponse<FEModuleViewModel>> GetByArticle(int id, string articleId = null)
        {
            var result = await FEModuleViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
            return result;
        }

        // GET api/modules
        [HttpGet]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await InfoModuleViewModel.Repository.GetModelListByAsync(m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            //data.Data.Items.ForEach(d => d.DetailsUrl = string.Format("{0}{1}", domain, this.Url.Action("Details", "modules", new { id = d.Id })));
            //data.Data.Items.ForEach(d => d.EditUrl = string.Format("{0}{1}", domain, this.Url.Action("Edit", "modules", new { id = d.Id })));
            return data;
        }

        // GET api/modules
        [HttpGet]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}/{description}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}/{description}")]
        public Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> Search(
            string keyword = null,
            string description = null,
            int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocModule, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(keyword) || (model.Title.Contains(keyword)))
            && (string.IsNullOrWhiteSpace(description) || (model.Description.Contains(description)));
            return InfoModuleViewModel
                .Repository
                .GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
        }

        #endregion Get

        #region Post

        // POST api/module
        [Authorize]
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<BEModuleViewModel>> Post([FromBody]BEModuleViewModel model)
        {
            if (model != null)
            {
                //model.CreatedBy = User.Identity.Name;
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<BEModuleViewModel>();
        }

        // POST api/module
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<bool>> SaveFields(int id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                var result = new RepositoryResponse<bool>() { IsSucceed = true };
                foreach (var property in fields)
                {
                    if (result.IsSucceed)
                    {
                        result = await InfoModuleViewModel.Repository.UpdateFieldsAsync(c => c.Id == id && c.Specificulture == _lang, fields).ConfigureAwait(false);
                    }
                    else
                    {
                        break;
                    }

                }
                return result;
            }
            return new RepositoryResponse<bool>();
        }

        // GET api/module
        [HttpPost, HttpOptions]
        [Route("list")]
        [Route("list/{level}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleViewModel>>> GetList([FromBody] RequestPaging request, int? level = 0)
        {
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);

            Expression<Func<SiocModule, bool>> predicate = model =>
                model.Specificulture == _lang
                && (string.IsNullOrWhiteSpace(request.Keyword)
                    || (model.Title.Contains(request.Keyword)
                    || model.Description.Contains(request.Keyword)))
                && (!request.FromDate.HasValue
                    || (model.LastModified >= request.FromDate.Value.ToUniversalTime())
                )
                && (!request.ToDate.HasValue
                    || (model.LastModified <= request.ToDate.Value.ToUniversalTime())
                )
                    ;

            var data = await InfoModuleViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
            //if (data.IsSucceed)
            //{
            //    data.Data.Items.ForEach(a =>
            //    {
            //        a.DetailsUrl = SwCmsHelper.GetRouterUrl(
            //            "Page", new { a.SeoName }, Request, Url);
            //        a.Childs.ForEach(c =>
            //        {
            //            c.DetailsUrl = SwCmsHelper.GetRouterUrl(
            //                "Page", new { c.SeoName }, Request, Url);
            //        }
            //    );
            //    }
            //    );
            //}
            return data;
        }

        #endregion Post
    }
}
