// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    [Route("api/{culture}/module-data")]
    public class ApiModuleDataController :
        BaseApiController<SiocCmsContext, SiocModule>
    {
        public ApiModuleDataController(IHostingEnvironment env) : base(env)
        {
        }

        [HttpPost]
        [Route("save")]
        public Task<RepositoryResponse<InfoModuleDataViewModel>> Save([FromBody]JObject data)
        {
            var model = data["model"].ToObject<SiocModuleData>();
            List<ModuleFieldViewModel> cols = data["columns"].ToObject<List<ModuleFieldViewModel>>();
            JObject val = new JObject();
            foreach (JProperty prop in data.Properties())
            {
                if (prop.Name != "model" && prop.Name != "columns")
                {
                    var col = cols.Find(c => c.Name == prop.Name);
                    JObject fieldVal = new JObject
                    {
                        new JProperty("dataType", col.DataType),
                        new JProperty("value", prop.Value)
                    };
                    val.Add(new JProperty(prop.Name, fieldVal));
                }
            }
            model.Value = val.ToString(Newtonsoft.Json.Formatting.None);
            var vmData = new InfoModuleDataViewModel(model);
            return vmData.SaveModelAsync();
        }

        // POST api/category
        [HttpPost, HttpOptions]
        [Route("save/{id}")]
        public async Task<RepositoryResponse<bool>> SaveFields(string id, [FromBody]List<EntityField> fields)
        {
            if (fields != null)
            {
                foreach (var property in fields)
                {
                    var result = await InfoModuleDataViewModel.Repository.UpdateFieldsAsync(c => c.Id == id, fields).ConfigureAwait(false);

                    return result;
                }
            }
            return new RepositoryResponse<bool>();
        }

        // GET api/module-data/id
        [HttpGet]
        [Route("details/{id}")]
        public Task<RepositoryResponse<InfoModuleDataViewModel>> Details(string id)
        {
            return InfoModuleDataViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
        }

        // GET api/module-data/id
        [HttpGet]
        [Route("edit/{id}")]
        public Task<RepositoryResponse<InfoModuleDataViewModel>> Edit(string id)
        {
            return InfoModuleDataViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
        }

        // GET api/module-data/create/id
        [HttpGet]
        [Route("create/{moduleId}")]
        public async Task<RepositoryResponse<BEModuleDataViewModel>> CreateAsync(int moduleId)
        {
            var getModule = await InfoModuleViewModel.Repository.GetSingleModelAsync(
                m => m.Id == moduleId && m.Specificulture == _lang).ConfigureAwait(false);
            if (getModule.IsSucceed)
            {
                var ModuleData = new BEModuleDataViewModel(
                    new SiocModuleData()
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        ModuleId = moduleId,
                        Specificulture = _lang,
                        Fields = getModule.Data.Fields
                    });
                return new RepositoryResponse<BEModuleDataViewModel>()
                {
                    IsSucceed = true,
                    Data = ModuleData
                };
            }
            else
            {
                return new RepositoryResponse<BEModuleDataViewModel>()
                {
                    IsSucceed = false,
                    Data = null,
                    Exception = getModule.Exception,
                    Errors = getModule.Errors
                };
            }
        }

        // GET api/module-data/id
        [HttpGet]
        [Route("delete/{id}")]
        public Task<RepositoryResponse<bool>> Delete(string id)
        {
            return InfoModuleDataViewModel.Repository.RemoveModelAsync(model => model.Id == id && model.Specificulture == _lang);
        }

        // GET api/module-data
        [HttpGet]
        [Route("{moduleId}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("{moduleId}/{orderBy}/{direction}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> Get(
            int moduleId,
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "moduleId"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var result = await InfoModuleDataViewModel.Repository.GetModelListByAsync(
                m => m.ModuleId == moduleId && m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

        // GET api/module-data
        [HttpGet]
        [Route("getByArticle/{articleId}/{moduleId}")]
        [Route("getByArticle/{articleId}/{moduleId}/{pageSize:int?}/{pageIndex:int?}")]
        [Route("getByArticle/{articleId}/{moduleId}/{orderBy}/{direction}")]
        [Route("getByArticle/{articleId}/{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> GetByArticle(
            string articleId, int moduleId,
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "moduleId"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var result = await InfoModuleDataViewModel.Repository.GetModelListByAsync(
                m => m.ModuleId == moduleId && m.ArticleId == articleId && m.Specificulture == _lang,
                orderBy, direction, pageSize, pageIndex).ConfigureAwait(false); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

        // GET api/module-data
        [HttpGet]
        [Route("{moduleId}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> Search(int moduleId, string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id", OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocModuleData, bool>> predicate = model =>
                model.ModuleId == moduleId
                && model.Specificulture == _lang
                && (string.IsNullOrWhiteSpace(keyword)
                || (model.Fields.Contains(keyword)
                || model.Fields.Contains(keyword)));

            var result = await InfoModuleDataViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }
    }
}
