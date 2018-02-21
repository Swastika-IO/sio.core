// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static Swastika.Cms.Lib.SWCmsConstants;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
    public class FECategoryViewModel
       : ViewModelBase<SiocCmsContext, SiocCategory, FECategoryViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("fields")]
        public string Fields { get; set; }

        [JsonProperty("type")]
        public CateType Type { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("cssClass")]
        public string CssClass { get; set; }

        [JsonProperty("staticUrl")]
        public string StaticUrl { get; set; }

        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("views")]
        public int? Views { get; set; }

        [JsonProperty("seoName")]
        public string SeoName { get; set; }

        [JsonProperty("seoTitle")]
        public string SeoTitle { get; set; }

        [JsonProperty("seoDescription")]
        public string SeoDescription { get; set; }

        [JsonProperty("seoKeywords")]
        public string SeoKeywords { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("updatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("updatedBy")]
        public string UpdatedBy { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("view")]
        public FETemplateViewModel View { get; set; }

        [JsonProperty("articles")]
        public PaginationModel<NavCategoryArticleViewModel> Articles { get; set; } = new PaginationModel<NavCategoryArticleViewModel>();

        [JsonProperty("products")]
        public PaginationModel<NavCategoryProductViewModel> Products { get; set; } = new PaginationModel<NavCategoryProductViewModel>();

        [JsonProperty("modules")]
        public List<FEModuleViewModel> Modules { get; set; } = new List<FEModuleViewModel>(); // Get All Module

        public string TemplatePath
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    ""
                    , SWCmsConstants.Parameters.TemplatesFolder
                    , GlobalConfigurationService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, Specificulture, SWCmsConstants.Default.DefaultTemplateFolder)
                    , Template
                });
            }
        }

        #endregion Views

        #endregion Properties

        #region Contructors

        public FECategoryViewModel() : base()
        {
        }

        public FECategoryViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = FETemplateViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;
            if (View != null)
            {
                switch (Type)
                {
                    case CateType.Home:
                        GetSubModules(_context, _transaction);
                        break;

                    case CateType.Blank:
                        break;

                    case CateType.Article:
                        break;

                    case CateType.Modules:
                        GetSubModules(_context, _transaction);
                        break;

                    case CateType.List:
                        GetSubArticles(_context, _transaction);
                        break;

                    case CateType.ListProduct:
                        GetSubProducts(_context, _transaction);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion Overrides

        #region Expands

        #region Sync

        private void GetSubModules(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getNavs = CategoryModuleViewModel.Repository.GetModelListBy(
                m => m.CategoryId == Id && m.Specificulture == Specificulture
                , _context, _transaction);
            if (getNavs.IsSucceed)
            {
                Modules = new List<FEModuleViewModel>();
                foreach (var nav in getNavs.Data.OrderBy(n => n.Priority).ToList())
                {
                    var getModule = FEModuleViewModel.Repository.GetSingleModel(
                        m => m.Id == nav.ModuleId && nav.Specificulture == Specificulture
                        , _context, _transaction);
                    if (getModule.IsSucceed)
                    {
                        if (getModule.Data.View != null)
                        {
                            View.Scripts += getModule.Data.View.Scripts;
                            View.Styles += getModule.Data.View.Styles;
                            Modules.Add(getModule.Data);
                        }
                    }
                }
            }
        }

        private void GetSubArticles(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getArticles = NavCategoryArticleViewModel.Repository.GetModelListBy(
                n => n.CategoryId == Id && n.Specificulture == Specificulture, SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
                , 4, 0
               , _context: _context, _transaction: _transaction
               );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }
        }

        private void GetSubProducts(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getProducts = NavCategoryProductViewModel.Repository.GetModelListBy(
               m => m.CategoryId == Id && m.Specificulture == Specificulture
           , SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
           , null, null
               , _context: _context, _transaction: _transaction
               );
            if (getProducts.IsSucceed)
            {
                Products = getProducts.Data;
            }
        }

        #endregion Sync

        public FEModuleViewModel GetModule(string name)
        {
            return Modules.FirstOrDefault(m => m.Name == name);
        }

        #endregion Expands
    }
}