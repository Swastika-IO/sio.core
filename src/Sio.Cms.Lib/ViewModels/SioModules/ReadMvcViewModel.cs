using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Common.Helper;
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

        [JsonProperty("formTemplate")]
        public string FormTemplate { get; set; }

        [JsonProperty("edmTemplate")]
        public string EdmTemplate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fields")]
        public string Fields { get; set; }

        [JsonProperty("type")]
        public SioModuleType Type { get; set; }
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
        [JsonProperty("domain")]
        public string Domain { get { return SioService.GetConfig<string>("Domain"); } }

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Image) && (Image.IndexOf("http") == -1) && Image[0] != '/')
                {
                    return CommonHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
                }
                else
                {
                    return Image;
                }
            }
        }

        [JsonProperty("columns")]
        public List<ModuleFieldViewModel> Columns
        {
            get { return Fields == null ? null : JsonConvert.DeserializeObject<List<ModuleFieldViewModel>>(Fields); }
            set { Fields = JsonConvert.SerializeObject(value); }
        }

        [JsonProperty("view")]
        public SioTemplates.ReadViewModel View { get; set; }
        [JsonProperty("formView")]
        public SioTemplates.ReadViewModel FormView { get; set; }

        [JsonProperty("edmView")]
        public SioTemplates.ReadViewModel EdmView { get; set; }
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

        public int? ArticleId { get; set; }
        public int? CategoryId { get; set; }

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
            this.FormView = SioTemplates.ReadViewModel.GetTemplateByPath(FormTemplate, Specificulture, _context, _transaction).Data;
            this.View = SioTemplates.ReadViewModel.GetTemplateByPath(EdmTemplate, Specificulture, _context, _transaction).Data;
            // call load data from controller for padding parameter (articleId, productId, ...)
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
                result.Data.ArticleId = articleId;
                result.Data.CategoryId = categoryId;
                result.Data.LoadData();
            }
            return result;
        }

        public void LoadData(int? articleId = null, int? productId = null, int? categoryId = null
            , int? pageSize = null, int? pageIndex = 0
            , SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            UnitOfWorkHelper<SioCmsContext>.InitTransaction(_context, _transaction, out SioCmsContext context, out IDbContextTransaction transaction, out bool isRoot);
            try
            {
                pageSize = pageSize > 0 ? PageSize : PageSize;
                pageIndex = pageIndex ?? 0;
                Expression<Func<SioModuleData, bool>> dataExp = null;
                Expression<Func<SioModuleArticle, bool>> articleExp = null;
                Expression<Func<SioModuleProduct, bool>> productExp = null;
                switch (Type)
                {
                    case SioModuleType.Content:
                    case SioModuleType.Data:
                        dataExp = m => m.ModuleId == Id && m.Specificulture == Specificulture;
                        //articleExp = n => n.ModuleId == Id && n.Specificulture == Specificulture;
                        //productExp = m => m.ModuleId == Id && m.Specificulture == Specificulture;
                        break;

                    case SioModuleType.SubPage:
                        dataExp = m => m.ModuleId == Id && m.Specificulture == Specificulture && (m.CategoryId == categoryId);
                        articleExp = n => n.ModuleId == Id && n.Specificulture == Specificulture;
                        productExp = m => m.ModuleId == Id && m.Specificulture == Specificulture;
                        break;

                    case SioModuleType.SubArticle:
                        dataExp = m => m.ModuleId == Id && m.Specificulture == Specificulture && (m.ArticleId == articleId);
                        break;
                    case SioModuleType.SubProduct:
                        dataExp = m => m.ModuleId == Id && m.Specificulture == Specificulture && (m.ProductId == productId);
                        break;
                    case SioModuleType.ListArticle:
                        articleExp = n => n.ModuleId == Id && n.Specificulture == Specificulture;
                        break;
                    case SioModuleType.ListProduct:
                        productExp = n => n.ModuleId == Id && n.Specificulture == Specificulture;
                        break;
                    default:
                        dataExp = m => m.ModuleId == Id && m.Specificulture == Specificulture;
                        articleExp = n => n.ModuleId == Id && n.Specificulture == Specificulture;
                        productExp = m => m.ModuleId == Id && m.Specificulture == Specificulture;
                        break;
                }

                if (dataExp != null)
                {
                    var getDataResult = SioModuleDatas.ReadViewModel.Repository
                    .GetModelListBy(
                        dataExp
                        , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
                        , pageSize, pageIndex
                        , _context: context, _transaction: transaction);
                    if (getDataResult.IsSucceed)
                    {
                        getDataResult.Data.JsonItems = new List<JObject>();
                        getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                        Data = getDataResult.Data;
                    }
                }
                if (articleExp != null)
                {
                    var getArticles = SioModuleArticles.ReadViewModel.Repository
                    .GetModelListBy(articleExp
                    , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
                    , pageSize, pageIndex
                    , _context: context, _transaction: transaction);
                    if (getArticles.IsSucceed)
                    {
                        Articles = getArticles.Data;
                    }
                }
                if (productExp != null)
                {
                    var getProducts = SioModuleProducts.ReadViewModel.Repository
                    .GetModelListBy(productExp
                    , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
                    , PageSize, pageIndex
                    , _context: context, _transaction: transaction);
                    if (getProducts.IsSucceed)
                    {
                        Products = getProducts.Data;
                    }
                }
            }
            catch (Exception ex)
            {
                UnitOfWorkHelper<SioCmsContext>.HandleException<PaginationModel<ReadMvcViewModel>>(ex, isRoot, transaction);
            }
            finally
            {
                if (isRoot)
                {
                    //if current Context is Root
                    context.Dispose();
                }
            }
        }

        #endregion Expand
    }
}
