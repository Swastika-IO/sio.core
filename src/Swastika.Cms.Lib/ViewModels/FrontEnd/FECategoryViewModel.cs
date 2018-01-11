using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using Microsoft.Data.OData.Query;
using System;
using System.Collections.Generic;
using static Swastika.Cms.Lib.SWCmsConstants;
using System.Linq;
using Swastika.Cms.Lib.Services;

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
        [JsonProperty("isVisible")]
        public bool? IsVisible { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }

        #endregion

        #region Views

        [JsonProperty("view")]
        public InfoTemplateViewModel View { get; set; }
        [JsonProperty("articles")]
        public PaginationModel<InfoArticleViewModel> Articles { get; set; } = new PaginationModel<InfoArticleViewModel>();
        [JsonProperty("modules")]
        public List<FEModuleViewModel> Modules { get; set; } = new List<FEModuleViewModel>(); // Get All Module

        public string TemplatePath
        {
            get {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    ""
                    , SWCmsConstants.Parameters.TemplatesFolder
                    , GlobalConfigurationService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, Specificulture, SWCmsConstants.Default.DefaultTemplateFolder)
                    , Template
                });
            }
        }
        #endregion

        #endregion

        #region Contructors

        public FECategoryViewModel() : base()
        {
        }

        public FECategoryViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = InfoTemplateViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;
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

                    default:
                        break;
                }
            }
        }

        #endregion

        #region Expands

        #region Async

        #endregion

        #region Sync

        void GetSubModules(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getNavs = CategoryModuleViewModel.Repository.GetModelListBy(
                m => m.CategoryId == Id && m.Specificulture == Specificulture
                , _context, _transaction);
            if (getNavs.IsSucceed)
            {
                Modules = new List<FEModuleViewModel>();
                foreach (var nav in getNavs.Data)
                {
                    var getModule = FEModuleViewModel.Repository.GetSingleModel(
                        m => m.Id == nav.ModuleId && nav.Specificulture == Specificulture
                        , _context, _transaction);
                    if (getModule.IsSucceed)
                    {
                        if (getModule.Data.View!=null)
                        {
                            View.Scripts += getModule.Data.View.Scripts;
                            View.Styles += getModule.Data.View.Styles;
                            Modules.Add(getModule.Data);
                        }                        
                    }
                }

            }
        }

        void GetSubArticles(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getArticles = InfoArticleViewModel.GetModelListByCategory(Id, Specificulture, SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
                , 4, 0
               , _context: _context, _transaction: _transaction
               );
            if (getArticles.IsSucceed)
            {                
                Articles = getArticles.Data;
            }
        }


        #endregion

        public FEModuleViewModel GetModule(string name)
        {
            return Modules.FirstOrDefault(m => m.Name == name);
        }

        #endregion

    }

}
