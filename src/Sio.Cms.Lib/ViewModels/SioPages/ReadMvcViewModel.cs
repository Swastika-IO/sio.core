using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioPages
{
    public class ReadMvcViewModel: ViewModelBase<SioCmsContext, SioPage, ReadMvcViewModel>
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
        public SioEnums.SioPageType Type { get; set; }

        [JsonProperty("status")]
        public SioEnums.SioContentStatus Status { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("cssClass")]
        public string CssClass { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

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

        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }
        #endregion Models

        #region Views

        [JsonProperty("details")]
        public string DetailsUrl { get; set; }

        [JsonProperty("domain")]
        public string Domain { get { return SioService.GetConfig<string>("Domain") ?? "/"; } }

        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
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

        [JsonProperty("view")]
        public SioTemplates.ReadViewModel View { get; set; }

        [JsonProperty("articles")]
        public PaginationModel<SioPageArticles.ReadViewModel> Articles { get; set; } = new PaginationModel<SioPageArticles.ReadViewModel>();

        [JsonProperty("products")]
        public PaginationModel<SioPageProducts.ReadViewModel> Products { get; set; } = new PaginationModel<SioPageProducts.ReadViewModel>();

        [JsonProperty("modules")]
        public List<SioPageModules.ReadMvcViewModel> Modules { get; set; } = new List<SioPageModules.ReadMvcViewModel>(); // Get All Module

        public string TemplatePath
        {
            get
            {
                return CommonHelper.GetFullPath(new string[]
                {
                    ""
                    , SioConstants.Folder.TemplatesFolder
                    , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ThemeName, Specificulture)??  SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultTemplateFolder)
                    , Template
                });
            }
        }

        #endregion Views

        #endregion Properties

        #region Contructors

        public ReadMvcViewModel() : base()
        {
        }

        public ReadMvcViewModel(SioPage model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = SioTemplates.ReadViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;
            if (View != null)
            {
                switch (Type)
                {
                    case SioPageType.Home:
                        GetSubModules(_context, _transaction);
                        break;

                    case SioPageType.Blank:
                        break;

                    case SioPageType.Article:
                        break;

                    case SioPageType.Modules:
                        GetSubModules(_context, _transaction);
                        break;

                    case SioPageType.ListArticle:
                        GetSubArticles(_context, _transaction);
                        break;

                    case SioPageType.ListProduct:
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

        private void GetSubModules(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getNavs = SioPageModules.ReadMvcViewModel.Repository.GetModelListBy(
                m => m.CategoryId == Id && m.Specificulture == Specificulture
                , _context, _transaction);
            if (getNavs.IsSucceed)
            {
                Modules = getNavs.Data;
                StringBuilder scripts = new StringBuilder();
                StringBuilder styles = new StringBuilder();
                foreach (var nav in getNavs.Data.OrderBy(n => n.Priority).ToList())
                {
                    scripts.Append(nav.Module.View.Scripts);
                    styles.Append(nav.Module.View.Styles);
                }
                View.Scripts = scripts.ToString();
                View.Styles = styles.ToString();
            }
        }

        private void GetSubArticles(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getArticles = SioPageArticles.ReadViewModel.Repository.GetModelListBy(
                n => n.CategoryId == Id && n.Specificulture == Specificulture,
                SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
                , 4, 0
               , _context: _context, _transaction: _transaction
               );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }
        }

        private void GetSubProducts(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getProducts = SioPageProducts.ReadViewModel.Repository.GetModelListBy(
               m => m.CategoryId == Id && m.Specificulture == Specificulture
           , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.OrderBy), 0
           , PageSize, 0
               , _context: _context, _transaction: _transaction
               );
            if (getProducts.IsSucceed)
            {
                Products = getProducts.Data;
            }
        }

        #endregion Sync

        public SioModules.ReadMvcViewModel GetModule(string name)
        {
            return Modules.FirstOrDefault(m => m.Module.Name == name)?.Module;
        }

        #endregion Expands
    }
}
