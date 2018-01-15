using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Swastika.Domain.Core.ViewModels;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.Models.Cms;

namespace Swastka.Cms.Api.Controllers
{
    [Route("api/{culture}/moduleData")]
    public class ModuleDataController :
        BaseApiController<SiocCmsContext, SiocModule>
    {

        [HttpPost]
        [Route("save")]
        public async Task<RepositoryResponse<InfoModuleDataViewModel>> Save([FromBody]JObject data)
        {
            var model = data["model"].ToObject<SiocModuleData>();
            List<ModuleFieldViewModel> cols = data["columns"].ToObject<List<ModuleFieldViewModel>>();
            JObject val = new JObject();
            foreach (JProperty prop in data.Properties())
            {
                if (prop.Name != "model" && prop.Name != "columns")
                {
                    var col = cols.FirstOrDefault(c => c.Name == prop.Name);
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
            return await vmData.SaveModelAsync();
        }

        // GET api/articles/id
        [HttpGet]
        [Route("details/{id}")]
        public async Task<RepositoryResponse<InfoModuleDataViewModel>> Details(string id)
        {
            return await InfoModuleDataViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
        }

        // GET api/articles/id
        [HttpGet]
        [Route("edit/{id}")]
        public async Task<RepositoryResponse<InfoModuleDataViewModel>> Edit(string id)
        {
            return await InfoModuleDataViewModel.Repository.GetSingleModelAsync(model => model.Id == id && model.Specificulture == _lang); //base.GetAsync(model => model.Id == id);
        }

        // GET api/articles/id
        [HttpGet]
        [Route("create")]
        public RepositoryResponse<InfoModuleDataViewModel> Create()
        {
            SiocModuleData article = new SiocModuleData()
            {
                Specificulture = _lang
            };
            return new RepositoryResponse<InfoModuleDataViewModel>()
            {
                IsSucceed = true,
                Data = new InfoModuleDataViewModel(article)
            };
        }


        // GET api/articles/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> Delete(string id)
        {
            return await InfoModuleDataViewModel.Repository.RemoveModelAsync(model => model.Id == id && model.Specificulture== _lang);
        }

        // GET api/articles
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
                m => m.ModuleId == moduleId && m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

        // GET api/articles
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
                orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }



        // GET api/articles
        [HttpGet]
        [Route("{moduleId}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{moduleId}/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>> Search(
             int moduleId,
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocModuleData, bool>> predicate = model =>
             model.ModuleId == moduleId &&
            model.Specificulture == _lang &&
            (
            string.IsNullOrWhiteSpace(keyword)
                || (model.Fields.Contains(keyword) || model.Fields.Contains(keyword))
                );
            var result = await InfoModuleDataViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);
            result.Data.JsonItems = new List<Newtonsoft.Json.Linq.JObject>();
            result.Data.Items.ForEach(i => result.Data.JsonItems.Add(i.ParseJson()));
            return result;
        }

    }
}
