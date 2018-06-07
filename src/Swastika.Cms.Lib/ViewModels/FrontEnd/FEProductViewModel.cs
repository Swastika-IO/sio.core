// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Common.Helper;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [JsonIgnore]
        [JsonProperty("extraProperties")]
        public string ExtraProperties { get; set; } = "[]";

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

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [Required]
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("totalSaled")]
        public int TotalSaled { get; set; }

        [JsonProperty("dealPrice")]
        public double? DealPrice { get; set; }

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("importPrice")]
        public double ImportPrice { get; set; }

        [JsonProperty("material")]
        public string Material { get; set; }

        [JsonProperty("normalPrice")]
        public double NormalPrice { get; set; }

        [JsonProperty("packageCount")]
        public int PackageCount { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
        #endregion Models

        #region Views

        [JsonProperty("view")]
        public InfoTemplateViewModel View { get; set; }

        [JsonProperty("modules")]
        public List<FEModuleViewModel> Modules { get; set; }

        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }

        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
                {
                    return SwCmsHelper.GetFullPath(new string[] {
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
                if (!string.IsNullOrEmpty(Thumbnail))
                {
                    if (Thumbnail.IndexOf("http") == -1)
                    {
                        return SwCmsHelper.GetFullPath(new string[] {
                            Domain,  Thumbnail

                        });
                    }
                    else
                    {
                        return Thumbnail;
                    }

                }
                else
                {
                    return ImageUrl;
                }
            }
        }

        public string TemplatePath
        {
            get
            {
                return SwCmsHelper.GetFullPath(new string[]
                {
                    ""
                    , SWCmsConstants.Parameters.TemplatesFolder
                    , GlobalConfigurationService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, Specificulture, SWCmsConstants.Default.DefaultTemplateFolder)
                    , Template
                });
            }
        }

        [JsonProperty("properties")]
        public List<ExtraProperty> Properties { get; set; }

        [JsonProperty("mediaNavs")]
        public List<NavProductMediaViewModel> MediaNavs { get; set; }

        [JsonProperty("productNavs")]
        public List<NavRelatedProductViewModel> ProductNavs { get; set; }


        [JsonProperty("strNormalPrice")]
        public string StrNormalPrice
        {
            get
            {
                return SwCmsHelper.FormatPrice(NormalPrice);
            }
        }

        [JsonProperty("strDealPrice")]
        public string StrDealPrice
        {
            get
            {
                return SwCmsHelper.FormatPrice(DealPrice);
            }
        }

        [JsonProperty("strImportPrice")]
        public string StrImportPrice
        {
            get
            {
                return SwCmsHelper.FormatPrice(ImportPrice);
            }
        }

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public FEProductViewModel() : base()
        {
        }

        public FEProductViewModel(SiocProduct model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.View = InfoTemplateViewModel.GetTemplateByPath(Template, Specificulture, _context, _transaction).Data;
            var getModulesResult = NavProductModuleViewModel.Repository.GetModelListBy(
                m => m.ProductId == Id && m.Specificulture == Specificulture
                , _context, _transaction);
            Properties = new List<ExtraProperty>();
            if (!string.IsNullOrEmpty(ExtraProperties))
            {
                JArray arr = JArray.Parse(ExtraProperties);
                foreach (JObject item in arr)
                {
                    Properties.Add(item.ToObject<ExtraProperty>());
                }
            }
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

            var getProductMedia = NavProductMediaViewModel.Repository.GetModelListBy(n => n.ProductId == Id && n.Specificulture == Specificulture, _context, _transaction);
            if (getProductMedia.IsSucceed)
            {
                MediaNavs = getProductMedia.Data.OrderBy(p => p.Priority).ToList();
                MediaNavs.ForEach(n => n.IsActived = true);
            }

            var getRelatedProduct = NavRelatedProductViewModel.Repository.GetModelListBy(n => n.SourceProductId == Id && n.Specificulture == Specificulture, _context, _transaction);
            if (getRelatedProduct.IsSucceed)
            {
                ProductNavs = getRelatedProduct.Data.OrderBy(p => p.Priority).ToList();
                ProductNavs.ForEach(n => n.IsActived = true);
            }
        }

        #endregion Overrides

        #region Expands

        private void GenerateSEO()
        {
            if (string.IsNullOrEmpty(this.SeoName))
            {
                this.SeoName = SeoHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoTitle))
            {
                this.SeoTitle = SeoHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoDescription))
            {
                this.SeoDescription = SeoHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoKeywords))
            {
                this.SeoKeywords = SeoHelper.GetSEOString(this.Title);
            }
        }

        #endregion Expands
    }
}
