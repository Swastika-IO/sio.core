using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Data.OData.Query;
using System;
using System.Collections.Generic;

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
        [JsonProperty("isVisible")]
        public bool? IsVisible { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }

        #endregion

        #region Views

        public List<InfoCategoryViewModel> Childs { get; set; }
        public int TotalArticle { get; set; }
        public string Href { get; set; }
        public bool IsActived { get; set; }
        #endregion

        #endregion

        #region Contructors

        public InfoCategoryViewModel() : base()
        {
        }

        public InfoCategoryViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

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
            var getSubArticles = InfoArticleViewModel.GetModelListByCategory(
                Id, Specificulture, SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
                , _context: _context, _transaction: _transaction);
            if (getSubArticles.IsSucceed)
            {
                TotalArticle = getSubArticles.Data.TotalItems;
            }

        }

        #endregion
    }

}
