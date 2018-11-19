using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioModules
{
    public class ReadMvcViewModel
        : ViewModelBase<SioCmsContext, SioModule, ReadMvcViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fields")]
        public string Fields { get; set; }

        [JsonProperty("type")]
        public ModuleType Type { get; set; }
          [JsonProperty("status")]
        public SioContentStatus Status { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }
        #endregion Models

        #region Views

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }

        [JsonProperty("columns")]
        public List<ModuleFieldViewModel> Columns
        {
            get { return Fields == null ? null : JsonConvert.DeserializeObject<List<ModuleFieldViewModel>>(Fields); }
            set { Fields = JsonConvert.SerializeObject(value); }
        }

        [JsonProperty("view")]
        public SioTemplates.ReadViewModel View { get; set; }

        [JsonProperty("data")]
        public PaginationModel<ViewModels.SioModuleDatas.ReadViewModel> Data { get; set; } = new PaginationModel<ViewModels.SioModuleDatas.ReadViewModel>();

        [JsonProperty("articles")]
        public PaginationModel<SioModuleArticles.ReadViewModel> Articles { get; set; } = new PaginationModel<SioModuleArticles.ReadViewModel>();

        [JsonProperty("products")]
        public PaginationModel<SioModuleProducts.ReadViewModel> Products { get; set; } = new PaginationModel<SioModuleProducts.ReadViewModel>();

        public string TemplatePath
        {
            get
            {
                return string.Format("../{0}", Template);
            }
        }

        #endregion Views

        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        #endregion Properties

        #region Contructors

        public ReadMvcViewModel() : base()
        {
        }

        public ReadMvcViewModel(SioModule model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = SioTemplates.ReadViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;

            var getDataResult = SioModuleDatas.ReadViewModel.Repository
                .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
                , null, null
                , _context, _transaction);
            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }

            var getArticles = SioModuleArticles.ReadViewModel.Repository.GetModelListBy(n => n.ModuleId == Id && n.Specificulture == Specificulture
            , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
                , 4, 0
                , _context: _context, _transaction: _transaction
                );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }

            var getProducts = SioModuleProducts.ReadViewModel.Repository.GetModelListBy(
                m => m.ModuleId == Id && m.Specificulture == Specificulture
            , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
            , null, null
                , _context: _context, _transaction: _transaction
                );
            if (getProducts.IsSucceed)
            {
                Products = getProducts.Data;
            }
        }

        #endregion Overrides

        #region Expand

        public static RepositoryResponse<ReadMvcViewModel> GetBy(
            Expression<Func<SioModule, bool>> predicate, int? articleId = null, int? productid = null, int categoryId = 0
             , SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = Repository.GetSingleModel(predicate, _context, _transaction);
            if (result.IsSucceed)
            {
                result.Data.ArticleId = articleId.Value;
                result.Data.CategoryId = categoryId;
                result.Data.LoadData();
            }
            return result;
        }

        public void LoadData(int? articleId = null, int? categoryId = null
            , int? pageSize = null, int? pageIndex = 0
            , SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<PaginationModel<SioModuleDatas.ReadViewModel>> getDataResult = new RepositoryResponse<PaginationModel<SioModuleDatas.ReadViewModel>>();

            switch (Type)
            {
                case ModuleType.Root:
                    getDataResult = SioModuleDatas.ReadViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case ModuleType.SubPage:
                    getDataResult = SioModuleDatas.ReadViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.CategoryId == categoryId)
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case ModuleType.SubArticle:
                    getDataResult = SioModuleDatas.ReadViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.ArticleId == articleId)
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                default:
                    break;
            }

            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }
        }

        #endregion Expand
    }
}
