// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoCategoryViewModel
       : ViewModelBase<SiocCmsContext, SiocCategory, InfoCategoryViewModel>
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
        public SWCmsConstants.CateType Type { get; set; }

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

        //[JsonProperty("content")]
        //public string Content { get; set; }
        //[JsonProperty("views")]
        //public int? Views { get; set; }
        [JsonProperty("seoName")]
        public string SeoName { get; set; }

        //[JsonProperty("seoTitle")]
        //public string SeoTitle { get; set; }
        //[JsonProperty("seoDescription")]
        //public string SeoDescription { get; set; }
        //[JsonProperty("seoKeywords")]
        //public string SeoKeywords { get; set; }
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

        [JsonProperty("childs")]
        public List<InfoCategoryViewModel> Childs { get; set; }

        [JsonProperty("totalArticle")]
        public int TotalArticle { get; set; }

        [JsonProperty("totalProduct")]
        public int TotalProduct { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public InfoCategoryViewModel() : base()
        {
        }

        public InfoCategoryViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getChilds = Repository.GetModelListBy
                (p => p.SiocCategoryCategorySiocCategory.Count(c => c.ParentId == Id
                && c.Specificulture == Specificulture) > 0
                );
            if (getChilds.IsSucceed)
            {
                Childs = getChilds.Data;
            }
            var countArticle = NavCategoryArticleViewModel.Repository.Count(c => c.CategoryId == Id && c.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction);

            if (countArticle.IsSucceed)
            {
                TotalArticle = countArticle.Data;
            }

            var countProduct = NavCategoryProductViewModel.Repository.Count(c => c.CategoryId == Id && c.Specificulture == Specificulture
               , _context: _context, _transaction: _transaction);

            if (countProduct.IsSucceed)
            {
                TotalProduct = countProduct.Data;
            }
        }

        #endregion Overrides
    }
}
