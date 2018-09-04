// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Spa;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Swastika.Cms.Lib.SWCmsConstants;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
    public class SpaModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocModule, SpaModuleViewModel>
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

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public ModuleType Type { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("view")]
        public SpaTemplateViewModel View { get; set; }

        [JsonProperty("data")]
        public PaginationModel<SpaModuleDataViewModel> Data { get; set; } = new PaginationModel<SpaModuleDataViewModel>();

        [JsonProperty("articles")]
        public PaginationModel<InfoArticleViewModel> Articles { get; set; } = new PaginationModel<InfoArticleViewModel>();

        [JsonProperty("products")]
        public PaginationModel<InfoProductViewModel> Products { get; set; } = new PaginationModel<InfoProductViewModel>();

        #endregion Views

        public string ArticleId { get; set; }
        public int CategoryId { get; set; }

        #endregion Properties

        #region Contructors

        public SpaModuleViewModel() : base()
        {
        }

        public SpaModuleViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = SpaTemplateViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;
            var getDataResult = SpaModuleDataViewModel.Repository
                .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                , "Priority", 0, null, null
                , _context, _transaction);
            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }

            var getArticles = InfoArticleViewModel.GetModelListByModule(Id, Specificulture, SWCmsConstants.Default.OrderBy, 0
                , 4, 0
                , _context: _context, _transaction: _transaction
                );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }

            var getProducts = InfoProductViewModel.GetModelListByModule(Id, Specificulture, SWCmsConstants.Default.OrderBy, 0
               , 4, 0
               , _context: _context, _transaction: _transaction
               );
            if (getProducts.IsSucceed)
            {
                Products = getProducts.Data;
            }
        }

        #endregion Overrides

        #region Expand

        public static RepositoryResponse<SpaModuleViewModel> GetBy(
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
            RepositoryResponse<PaginationModel<SpaModuleDataViewModel>> getDataResult = new RepositoryResponse<PaginationModel<SpaModuleDataViewModel>>();

            switch (Type)
            {
                case SWCmsConstants.ModuleType.Root:
                    getDataResult = SpaModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SWCmsConstants.ModuleType.SubPage:
                    getDataResult = SpaModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.CategoryId == categoryId)
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SWCmsConstants.ModuleType.SubArticle:
                    getDataResult = SpaModuleDataViewModel.Repository
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
