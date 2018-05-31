// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Swastika.Cms.Lib.SWCmsConstants;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
    public class FEModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocModule, FEModuleViewModel>
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

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("columns")]
        public List<ModuleFieldViewModel> Columns { get; set; }

        [JsonProperty("view")]
        public FETemplateViewModel View { get; set; }

        [JsonProperty("data")]
        public PaginationModel<BEModuleDataViewModel> Data { get; set; } = new PaginationModel<BEModuleDataViewModel>();

        //[JsonProperty("columns")]
        //public List<ModuleFieldViewModel> Columns { get; set; }
        //[JsonProperty("templates")]
        //public List<TemplateViewModel> Templates { get; set; }
        [JsonProperty("articles")]
        public PaginationModel<NavModuleArticleViewModel> Articles { get; set; } = new PaginationModel<NavModuleArticleViewModel>();

        [JsonProperty("products")]
        public PaginationModel<NavModuleProductViewModel> Products { get; set; } = new PaginationModel<NavModuleProductViewModel>();

        public string TemplatePath {
            get {
                return string.Format("../{0}", Template);
                //return SwCmsHelper.GetFullPath(new string[]
                //{
                //    ""
                //    , SWCmsConstants.Parameters.TemplatesFolder
                //    , ApplicationConfigService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, Specificulture, SWCmsConstants.Default.DefaultTemplateFolder)
                //    , Template
                //});
            }
        }

        #endregion Views

        public string ArticleId { get; set; }
        public int CategoryId { get; set; }

        #endregion Properties

        #region Contructors

        public FEModuleViewModel() : base()
        {
        }

        public FEModuleViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = FETemplateViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;
            Columns = new List<ModuleFieldViewModel>();
            JArray arrField = !string.IsNullOrEmpty(Fields) ? JArray.Parse(Fields) : new JArray();
            foreach (var field in arrField)
            {
                ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["name"].ToString()),
                    Priority = field["priority"] != null ? field["priority"].Value<int>() : 0,
                    DataType = (SWCmsConstants.DataType)(int)field["dataType"],
                    Width = field["width"] != null ? field["width"].Value<int>() : 3,
                    IsDisplay = field["isDisplay"] != null ? field["isDisplay"].Value<bool>() : true
                };
                Columns.Add(thisField);
            }

            //this.Templates = Templates ?? TemplateRepository.Instance.GetTemplates(SWCmsConstants.TemplateFolder.Modules);

            var getDataResult = BEModuleDataViewModel.Repository
                .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                , "Priority", OrderByDirection.Ascending, null, null
                , _context, _transaction);
            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }

            //LoadData(ArticleId, CategoryId, _context: _context, _transaction: _transaction);

            var getArticles = NavModuleArticleViewModel.Repository.GetModelListBy(n => n.ModuleId == Id && n.Specificulture == Specificulture
            , SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
                , 4, 0
                , _context: _context, _transaction: _transaction
                );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }

            var getProducts = NavModuleProductViewModel.Repository.GetModelListBy(
                m => m.ModuleId == Id && m.Specificulture == Specificulture
            , SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
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

        public static RepositoryResponse<FEModuleViewModel> GetBy(
            Expression<Func<SiocModule, bool>> predicate, string articleId = null, string productId = null, int categoryId = 0
             , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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

        public void LoadData(string articleId = null, int? categoryId = null
            , int? pageSize = null, int? pageIndex = 0
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<PaginationModel<BEModuleDataViewModel>> getDataResult = new RepositoryResponse<PaginationModel<BEModuleDataViewModel>>();

            switch (Type)
            {
                case SWCmsConstants.ModuleType.Root:
                    getDataResult = BEModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SWCmsConstants.ModuleType.SubPage:
                    getDataResult = BEModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.CategoryId == categoryId)
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SWCmsConstants.ModuleType.SubArticle:
                    getDataResult = BEModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.ArticleId == articleId)
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
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
