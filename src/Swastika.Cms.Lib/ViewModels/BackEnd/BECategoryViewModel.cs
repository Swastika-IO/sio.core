using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.Repositories;
using Swastika.IO.Domain.Core.ViewModels;
using Swastika.Common.Helper;
using System.Threading.Tasks;
using Swastika.Domain.Core.Models;
using Swastika.Cms.Lib.ViewModels.Info;
using Microsoft.EntityFrameworkCore;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BECategoryViewModel
        : ViewModelBase<SiocCmsContext, SiocCategory, BECategoryViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("template")]
        public string Template { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
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
        [JsonProperty("updatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public string UpdatedBy { get; set; }
        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
        [JsonProperty("staticUrl")]
        public string StaticUrl { get; set; }
        [JsonProperty("level")]
        public int? Level { get; set; }
        #endregion

        #region Views
        [JsonProperty("moduleNavs")]
        public List<CategoryModuleViewModel> ModuleNavs { get; set; } // Parent to Modules
        [JsonProperty("positionNavs")]
        public List<CategoryPositionViewModel> PositionNavs { get; set; } // Parent to Modules
        [JsonProperty("parentNavs")]
        public List<CategoryCategoryViewModel> ParentNavs { get; set; } // Parent to  Parent
        [JsonProperty("childNavs")]
        public List<CategoryCategoryViewModel> ChildNavs { get; set; } // Parent to  Parent
        [JsonProperty("listTag")]
        public JArray ListTag { get; set; } = new JArray();
        [JsonProperty("view")]
        public InfoTemplateFileViewModel View { get; set; }
        [JsonProperty("templates")]
        public List<InfoTemplateFileViewModel> Templates { get; set; }// Article Templates
        [JsonProperty("imageFileStream")]
        public FileStreamViewModel ImageFileStream { get; set; }
        
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

        [JsonIgnore]
        public string ActivedTemplate
        {
            get
            {
                return ApplicationConfigService.Instance.GetLocalString("Template", Specificulture, SWCmsConstants.Default.DefaultTemplateFolder);
            }
        }
        [JsonIgnore]
        public string TemplateFolderType { get { return SWCmsConstants.TemplateFolderEnum.Pages.ToString(); } }
        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , ActivedTemplate
                    , TemplateFolderType
                }
            );
            }
        }
        #endregion

        #endregion

        #region Contructors

        public BECategoryViewModel() : base()
        {
        }

        public BECategoryViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override SiocCategory ParseModel()
        {
            GenerateSEO();
            if (View != null)
            {
                //TemplateRepository.Instance.SaveTemplate(View);
                View.SaveModel();
            }
            Template = View != null ? string.Format(@"/{0}/{1}{2}", View.FileFolder, View.FileName, View.Extension) : Template;
            if (Id == 0)
            {
                Id = CategoryFEViewModel.Repository.Count().Data + 1;
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel();
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = ApplicationConfigService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported =
           (Id == 0 && c.Specificulture == Specificulture)
           || Repository.CheckIsExists(a => a.Id == Id && a.Specificulture == c.Specificulture, _context, _transaction)
           );

            if (!string.IsNullOrEmpty(this.Tags))
            {
                ListTag = JArray.Parse(this.Tags);
            }

            this.Templates = this.Templates ?? InfoTemplateFileViewModel.Repository.GetModelListBy(
                t => t.Template.Name == ActivedTemplate && t.FolderType == this.TemplateFolderType).Data;
            this.View = Templates.FirstOrDefault(t => !string.IsNullOrEmpty(this.Template) && this.Template.Contains(t.FileName + t.Extension));
            if (this.View == null)
            {
                this.View = new InfoTemplateFileViewModel()
                {
                    Extension = SWCmsConstants.Parameters.TemplateExtension,
                    FileFolder = this.TemplateFolder,
                    FileName = string.Format("{0}{1}", SWCmsConstants.Default.DefaultTemplate, SWCmsConstants.Parameters.TemplateExtension),
                    Content = "<div></div>"
                };
                this.Template = SWCmsHelper.GetFullPath(new string[]
                {
                    this.View?.FileFolder
                    , this.View?.FileName
                });
            }

            this.ModuleNavs = GetModuleNavs(_context, _transaction);
            this.ParentNavs = GetParentNavs(_context, _transaction);
            this.ChildNavs = GetChildNavs(_context, _transaction);
            this.PositionNavs = GetPositionNavs(_context, _transaction);
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

        public List<CategoryPositionViewModel> GetPositionNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SiocPosition
                  .Include(cp => cp.SiocCategoryPosition)
                  //.Where(p => p.Specificulture == Specificulture)
                  .Select(p => new CategoryPositionViewModel()
                  {
                      CategoryId = Id,
                      PositionId = p.Id,
                      Specificulture = Specificulture,
                      Description = p.Description,
                      IsActived = CategoryPositionViewModel.Repository.CheckIsExists(
                          m => m.CategoryId == Id && m.PositionId == p.Id && m.Specificulture == Specificulture, context, transaction)
                  });

            return query.OrderBy(m => m.Priority).ToList();
        }

        public List<CategoryModuleViewModel> GetModuleNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SiocModule
                .Include(cp => cp.SiocCategoryModule)
                .Where(Module => Module.Specificulture == Specificulture)
                .Select(Module => new CategoryModuleViewModel()
                {
                    CategoryId = Id,
                    ModuleId = Module.Id,
                    Specificulture = Specificulture,
                    Description = Module.Title,
                    IsActived = CategoryModuleViewModel.Repository.CheckIsExists(
                        m => m.ModuleId == Module.Id && m.CategoryId == Id && m.Specificulture == Specificulture, context, transaction)
                });

            var result = query.OrderBy(m => m.Priority).ToList();

            return result;
        }

        public List<CategoryCategoryViewModel> GetParentNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {

            var query = context.SiocCategory
                .Include(cp => cp.SiocCategoryCategorySiocCategory)
                .Where(Category => Category.Specificulture == Specificulture && Category.Id != Id)
                .Select(Category => new CategoryCategoryViewModel()
                {
                    Id = Id,
                    ParentId = Category.Id,
                    Specificulture = Specificulture,
                    Description = Category.Title,
                    IsActived = CategoryCategoryViewModel.Repository.CheckIsExists(
                        m => m.ParentId == Category.Id && m.Id == Id && m.Specificulture == Specificulture, context, transaction)
                });

            var result = query.OrderBy(m => m.Priority).ToList();

            return result;
        }

        public List<CategoryCategoryViewModel> GetChildNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {

            var query = context.SiocCategory
                .Include(cp => cp.SiocCategoryCategorySiocCategory)
                .Where(Category => Category.Specificulture == Specificulture && Category.Id != Id)
                .Select(Category => new CategoryCategoryViewModel()
                {
                    Id = Category.Id,
                    ParentId = Id,
                    Specificulture = Specificulture,
                    Description = Category.Title,
                    IsActived = CategoryCategoryViewModel.Repository.CheckIsExists(
                        m => m.ParentId == Id && m.Id == Category.Id && m.Specificulture == Specificulture, context, transaction)
                });

            var result = query.OrderBy(m => m.Priority).ToList();

            return result;
        }

        #endregion

    }
}
