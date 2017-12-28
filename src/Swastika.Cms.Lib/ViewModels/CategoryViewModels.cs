using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using static Swastika.Cms.Lib.SWCmsConstants;
using Swastika.Domain.Core.Models;
using Microsoft.Data.OData.Query;
using Swastika.Cms.Lib.Services;
using Swastika.Common.Helper;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Swastika.IO.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;

namespace Swastika.Cms.Lib.ViewModels
{
    public class CategoryListItemViewModel : ViewModelBase<SiocCmsContext, SiocCategory, CategoryListItemViewModel>
    {
        #region Properties

        public int Id { get; set; }
        public string Template { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string StaticUrl { get; set; }
        public string Excerpt { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public CateType Type { get; set; }
        public int? Views { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public int? Level { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public string Tags { get; set; }

        //View
        public List<CategoryListItemViewModel> Childs { get; set; }
        public int TotalArticle { get; set; }
        #endregion

        public CategoryListItemViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {

        }

        #region Expands
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

    public class CategoryFEViewModel : ViewModelBase<SiocCmsContext, SiocCategory, CategoryFEViewModel>
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string StaticUrl { get; set; }
        public string Excerpt { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public SWCmsConstants.CateType Type { get; set; }
        public int? Views { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public int? Level { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public string Tags { get; set; }

        //Views
        public List<ModuleWithDataViewModel> Modules { get; set; } // Get All Module
        public PaginationModel<InfoArticleViewModel> Articles { get; set; } // Get Articles with paging

        public CategoryFEViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {

        }


        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Template = string.IsNullOrEmpty(Template) ? "Pages/_Article" : Template;

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
                Modules = new List<ModuleWithDataViewModel>();
                foreach (var nav in getNavs.Data)
                {
                    var getModule = ModuleWithDataViewModel.Repository.GetSingleModel(
                        m => m.Id == nav.ModuleId && nav.Specificulture == Specificulture
                        , _context, _transaction);
                    if (getModule.IsSucceed)
                    {
                        Modules.Add(getModule.Data);
                    }
                }

            }
        }

        void GetSubArticles(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            int pageSize = ApplicationConfigService.GetLocalInt("PageSize_Article", Specificulture);
            var getNavs = CategoryArticleViewModel.Repository.GetModelListBy(
                m => m.CategoryId == Id && m.Specificulture == Specificulture
                , "Priority", OrderByDirection.Ascending, pageSize, PageIndex
                , _context, _transaction);
            if (getNavs.IsSucceed)
            {
                var lstArticles = new List<InfoArticleViewModel>();
                foreach (var nav in getNavs.Data.Items)
                {
                    var getArticle = InfoArticleViewModel.Repository.GetSingleModel(
                        m => m.Id == nav.ArticleId && nav.Specificulture == Specificulture
                        , _context, _transaction);
                    if (getArticle.IsSucceed)
                    {
                        lstArticles.Add(getArticle.Data);
                    }
                }
                Articles = new PaginationModel<InfoArticleViewModel>()
                {
                    PageIndex = getNavs.Data.PageIndex,
                    PageSize = getNavs.Data.PageSize,
                    Items = lstArticles,
                    TotalItems = getNavs.Data.TotalItems,
                    TotalPage = getNavs.Data.TotalPage,
                };

            }
        }


        #endregion

        public ModuleWithDataViewModel GetModule(string name)
        {
            return Modules.FirstOrDefault(m => m.Name == name);
        }

        #endregion
    }

    public class CategoryBEViewModel : ViewModelBase<SiocCmsContext, SiocCategory, CategoryBEViewModel>
    {
        #region Properties

        public int Id { get; set; }
        public string Template { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string StaticUrl { get; set; }
        public string Excerpt { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public int? Views { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public int? Level { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public string Tags { get; set; }

        // View
        public List<CategoryModuleViewModel> ModuleNavs { get; set; } // Parent to Modules
        public List<CategoryPositionViewModel> PositionNavs { get; set; } // Parent to Modules
        public List<CategoryCategoryViewModel> ParentNavs { get; set; } // Parent to  Parent
        public List<CategoryCategoryViewModel> ChildNavs { get; set; } // Parent to  Parent
        public JArray ListTag { get; set; } = new JArray();
        public TemplateViewModel View { get; set; }
        public List<TemplateViewModel> Templates { get; set; }// Article Templates
        public FileStreamViewModel ImageFileStream { get; set; }

        public string TemplateFolder
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , SWCmsConstants.TemplateFolder.Articles.ToString()
                }
            );
            }
        }

        public string Domain { get; set; } = "/";
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

        #endregion

        public CategoryBEViewModel(SiocCategory model
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {

        }
        public CategoryBEViewModel() : base()
        {

        }

        #region Overrides

        public override SiocCategory ParseModel()
        {
            GenerateSEO();
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

            this.Templates = this.Templates ?? TemplateRepository.Instance.GetTemplates(
                SWCmsConstants.TemplateFolder.Pages);

            this.View = Templates.FirstOrDefault(t => !string.IsNullOrEmpty(this.Template) && this.Template.Contains(t.Filename + t.Extension));
            if (this.View == null)
            {
                this.View = Templates.FirstOrDefault();//t => this.Template.Contains(t.Filename + t.Extension)
                this.Template = SWCmsHelper.GetFullPath(new string[]
                {
                    this.View?.FileFolder
                    , this.View?.Filename
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
