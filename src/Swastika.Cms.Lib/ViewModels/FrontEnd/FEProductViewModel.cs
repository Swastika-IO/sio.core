using System;
using System.Collections.Generic;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Common.Helper;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Navigation;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
   
    public class FEProductViewModel
        : ViewModelBase<SiocCmsContext, SiocProduct, FEProductViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("template")]
        public string Template { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("priceUnit")]
        public string PriceUnit { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("seoName")]
        public string SeoName { get; set; }
        [JsonProperty("seoTitle")]
        public string SeoTitle { get; set; }
        [JsonProperty("seoDescription")]
        public string SeoDescription { get; set; }
        [JsonProperty("seoKeywords")]
        public string SeoKeywords { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("views")]
        public int? Views { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }
        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
        #endregion

        #region Views
        [JsonProperty("view")]
        public InfoTemplateViewModel View { get; set; }
        [JsonProperty("modules")]
        public List<FEModuleViewModel> Modules { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; } = "/";
        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (Image != null && Image.IndexOf("http") == -1)
                {
                    return SWCmsHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
                }
                else
                {
                    return Image;
                }

            }
        }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl
        {
            get
            {
                if (Thumbnail != null && Thumbnail.IndexOf("http") == -1)
                {
                    return SWCmsHelper.GetFullPath(new string[] {
                    Domain,  Thumbnail
                });
                }
                else
                {
                    return Thumbnail;
                }

            }
        }
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
        #endregion

        #endregion

        #region Contructors

        public FEProductViewModel() : base()
        {
        }

        public FEProductViewModel(SiocProduct model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = InfoTemplateViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;
            var getModulesResult = NavProductModuleViewModel.Repository.GetModelListBy(
                m => m.ProductId == Id && m.Specificulture == Specificulture
                , _context, _transaction);

            if (getModulesResult.IsSucceed)
            {
                this.Modules = new List<FEModuleViewModel>();
                foreach (var item in getModulesResult.Data)
                {
                    var getModules = FEModuleViewModel.Repository.GetSingleModel(
                        m => m.Id == item.ModuleId && m.Specificulture == item.Specificulture
                        , _context, _transaction);
                    if (getModules.IsSucceed)
                    {
                        this.Modules.Add(getModules.Data);
                    }
                }
                
            }
        }

        #endregion

        #region Expands
        void GenerateSEO()
        {
            if (string.IsNullOrEmpty(this.SeoName))
            {
                this.SeoName = SEOHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoTitle))
            {
                this.SeoTitle = SEOHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoDescription))
            {
                this.SeoDescription = SEOHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoKeywords))
            {
                this.SeoKeywords = SEOHelper.GetSEOString(this.Title);
            }
        }
        #endregion

    }
}
