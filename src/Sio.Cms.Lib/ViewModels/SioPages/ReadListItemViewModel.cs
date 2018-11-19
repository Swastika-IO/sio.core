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
    public class ReadListItemViewModel
       : ViewModelBase<SioCmsContext, SioPage, ReadListItemViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("fields")]
        public string Fields { get; set; }

        [JsonProperty("type")]
        public SioPageType Type { get; set; }

        [JsonProperty("status")]
        public SioContentStatus Status { get; set; }


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

        [JsonProperty("seoName")]
        public string SeoName { get; set; }

        [JsonProperty("seoDescription")]
        public string SeoDescription { get; set; }

        [JsonProperty("seoKeywords")]
        public string SeoKeywords { get; set; }

        [JsonProperty("seoTitle")]
        public string SeoTitle { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("updatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("updatedBy")]
        public string UpdatedBy { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        #endregion Models

        #region Views

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

        [JsonProperty("childs")]
        public List<ReadListItemViewModel> Childs { get; set; }

        [JsonProperty("totalArticle")]
        public int TotalArticle { get; set; }

        [JsonProperty("totalProduct")]
        public int TotalProduct { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public ReadListItemViewModel() : base()
        {
        }

        public ReadListItemViewModel(SioPage model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getChilds = Repository.GetModelListBy
                (p => p.SioPagePageSioPage.Any(c => c.ParentId == Id
                && c.Specificulture == Specificulture)
                );
            if (getChilds.IsSucceed)
            {
                Childs = getChilds.Data;
            }
            var countArticle = SioPageArticles.ReadViewModel.Repository.Count(c => c.CategoryId == Id && c.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction);

            if (countArticle.IsSucceed)
            {
                TotalArticle = countArticle.Data;
            }

            var countProduct = SioPageProducts.ReadViewModel.Repository.Count(c => c.CategoryId == Id && c.Specificulture == Specificulture
               , _context: _context, _transaction: _transaction);

            if (countProduct.IsSucceed)
            {
                TotalProduct = countProduct.Data;
            }
        }

        #endregion Overrides

        
    }
}
