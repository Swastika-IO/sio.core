// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/{culture}/language")]
    public class ApiLanguageController :
        BaseApiController
    {
        public ApiLanguageController()
        {
        }

        #region Get

        // GET api/languages/id
        [HttpGet]
        [Route("details/{viewType}/{keyword}")]
        [Route("details/{viewType}")]
        public async Task<JObject> Details(string viewType, string keyword = null)
        {
            switch (viewType)
            {
                default:
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        var feResult = await ApiLanguageViewModel.Repository.GetSingleModelAsync(
                        model => model.Keyword == keyword && model.Specificulture == _lang).ConfigureAwait(false);
                        return JObject.FromObject(feResult);
                    }
                    else
                    {
                        var language = new SiocLanguage()
                        {
                            Specificulture = _lang
                        };
                        var result = new RepositoryResponse<ApiLanguageViewModel>()
                        { 
                            IsSucceed = true,
                            Data = (await ApiLanguageViewModel.InitViewAsync(language))
                        };
                        return JObject.FromObject(result);
                    }

            }
        }

        // GET api/languages/id
        [HttpGet]
        [Route("delete/{keyword}")]
        public async Task<RepositoryResponse<SiocLanguage>> Delete(string keyword)
        {
            var getLanguage = ApiLanguageViewModel.Repository.GetSingleModel(a => a.Keyword == keyword && a.Specificulture == _lang);
            if (getLanguage.IsSucceed)
            {
                var result =  await getLanguage.Data.RemoveModelAsync(true).ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    GlobalConfigurationService.Instance.RefreshAll();
                }
                return result;
            }
            else
            {
                return new RepositoryResponse<SiocLanguage>() { IsSucceed = false };
            }
        }

        // GET api/languages
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<ApiLanguageViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await ApiLanguageViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            return data;
        }

        // GET api/languages
        [HttpGet]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<ApiLanguageViewModel>>> Search(
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocLanguage, bool>> predicate = model =>
            model.Specificulture == _lang
            && (
            string.IsNullOrWhiteSpace(keyword)
                || model.Keyword.Contains(keyword)
                || model.Description.Contains(keyword)
                || model.Value.Contains(keyword)
                );
            var data = await ApiLanguageViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);

            return data;
        }

        #endregion Get

        #region Post

        // POST api/languages
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiLanguageViewModel>> Post([FromBody]ApiLanguageViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    GlobalConfigurationService.Instance.RefreshAll();
                }
                return result;
            }
            return new RepositoryResponse<ApiLanguageViewModel>();
        }

        // GET api/languages

        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<ApiLanguageViewModel>>> GetList([FromBody]RequestPaging request)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocLanguage, bool>> predicate = model =>
                model.Specificulture == _lang
                && (string.IsNullOrWhiteSpace(request.Keyword)
                || (model.Description.Contains(request.Keyword)
                || model.Value.Contains(request.Keyword)
                || model.Keyword.Contains(request.Keyword)));
            
            var data = await ApiLanguageViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return data;
        }
        #endregion Post

    }
}
