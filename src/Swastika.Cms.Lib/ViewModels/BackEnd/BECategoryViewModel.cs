// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [JsonProperty("cssClass")]
        public string CssClass { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

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

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("staticUrl")]
        public string StaticUrl { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion Models

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

        #region Template

        [JsonProperty("view")]
        public BETemplateViewModel View { get; set; }

        [JsonProperty("templates")]
        public List<BETemplateViewModel> Templates { get; set; }// Article Templates

        [JsonIgnore]
        public string ActivedTemplate
        {
            get
            {
                return GlobalConfigurationService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, Specificulture, SWCmsConstants.Default.DefaultTemplateFolder);
            }
        }

        [JsonIgnore]
        public string TemplateFolderType
        {
            get
            {
                return SWCmsConstants.TemplateFolderEnum.Pages.ToString();
            }
        }

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

        #endregion Template

        #endregion Views

        #endregion Properties

        #region Contructors

        public BECategoryViewModel() : base()
        {
        }

        public BECategoryViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override SiocCategory ParseModel()
        {
            GenerateSEO();
            //if (View != null)
            //{
            //    //TemplateRepository.Instance.SaveTemplate(View);
            //    View.SaveModel();
            //}
            Template = View != null ? string.Format(@"{0}/{1}{2}", View.FolderType, View.FileName, View.Extension) : Template;
            if (Id == 0)
            {
                Id = FECategoryViewModel.Repository.Max(c => c.Id).Data + 1;
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel();
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported =
           (Id == 0 && c.Specificulture == Specificulture)
           || Repository.CheckIsExists(a => a.Id == Id && a.Specificulture == c.Specificulture, _context, _transaction)
           );

            if (!string.IsNullOrEmpty(this.Tags))
            {
                ListTag = JArray.Parse(this.Tags);
            }

            this.Templates = this.Templates ?? BETemplateViewModel.Repository.GetModelListBy(
                t => t.Template.Name == ActivedTemplate && t.FolderType == this.TemplateFolderType).Data;
            this.View = Templates.FirstOrDefault(t => !string.IsNullOrEmpty(this.Template) && this.Template.Contains(t.FileName + t.Extension));
            this.View = View ?? Templates.FirstOrDefault();
            if (this.View == null)
            {
                this.View = new BETemplateViewModel(new SiocTemplate()
                {
                    Extension = SWCmsConstants.Parameters.TemplateExtension,
                    TemplateId = GlobalConfigurationService.Instance.GetLocalInt(SWCmsConstants.ConfigurationKeyword.ThemeId, Specificulture, 0),
                    TemplateName = ActivedTemplate,
                    FolderType = TemplateFolderType,
                    FileFolder = this.TemplateFolder,
                    FileName = SWCmsConstants.Default.DefaultTemplate,
                    ModifiedBy = ModifiedBy,
                    Content = "<div></div>"
                });
            }
            this.Template = SWCmsHelper.GetFullPath(new string[]
               {
                    this.View?.FileFolder
                    , this.View?.FileName
               });

            this.ModuleNavs = GetModuleNavs(_context, _transaction);
            this.ParentNavs = GetParentNavs(_context, _transaction);
            this.ChildNavs = GetChildNavs(_context, _transaction);
            this.PositionNavs = GetPositionNavs(_context, _transaction);
        }

        #region Sync

        public override RepositoryResponse<bool> SaveSubModels(SiocCategory parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            bool result = true;
            var saveTemplate = View.SaveModel(true, _context, _transaction);
            if (!saveTemplate.IsSucceed)
            {
                Exception = saveTemplate.Exception;
                Errors.AddRange(saveTemplate.Errors);
            }
            result = result && saveTemplate.IsSucceed;

            if (result)
            {
                foreach (var item in ModuleNavs)
                {
                    item.CategoryId = Id;
                    if (item.IsActived)
                    {
                        var saveResult = item.SaveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = item.RemoveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result)
            {
                foreach (var item in PositionNavs)
                {
                    item.CategoryId = Id;
                    if (item.IsActived)
                    {
                        var saveResult = item.SaveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = item.RemoveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result)
            {
                foreach (var item in ParentNavs)
                {
                    item.Id = Id;
                    if (item.IsActived)
                    {
                        var saveResult = item.SaveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = item.RemoveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result)
            {
                foreach (var item in ChildNavs)
                {
                    item.ParentId = Id;
                    if (item.IsActived)
                    {
                        var saveResult = item.SaveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = item.RemoveModel(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result,
                Data = result,
                Errors = Errors,
                Exception = Exception
            };
        }

        #endregion Sync

        #region Async

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocCategory parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            bool result = true;
            var saveTemplate = await View.SaveModelAsync(true, _context, _transaction);
            if (!saveTemplate.IsSucceed)
            {
                Exception = saveTemplate.Exception;
                Errors.AddRange(saveTemplate.Errors);
            }
            result = result && saveTemplate.IsSucceed;

            if (result)
            {
                foreach (var item in ModuleNavs)
                {
                    item.CategoryId = Id;
                    if (item.IsActived)
                    {
                        var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result)
            {
                foreach (var item in PositionNavs)
                {
                    item.CategoryId = Id;
                    if (item.IsActived)
                    {
                        var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result)
            {
                foreach (var item in ParentNavs)
                {
                    item.Id = Id;
                    if (item.IsActived)
                    {
                        var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }

            if (result)
            {
                foreach (var item in ChildNavs)
                {
                    item.ParentId = Id;
                    if (item.IsActived)
                    {
                        var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                    else
                    {
                        var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result = result && saveResult.IsSucceed;
                        if (!result)
                        {
                            Exception = saveResult.Exception;
                            Errors.AddRange(saveResult.Errors);
                        }
                    }
                }
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result,
                Data = result,
                Errors = Errors,
                Exception = Exception
            };
        }

        #endregion Async

        #endregion Overrides

        #region Expands

        private void GenerateSEO()
        {
            if (string.IsNullOrEmpty(this.SeoName))
            {
                this.SeoName = SEOHelper.GetSEOString(this.Title);
            }
            int i = 1;
            string name = SeoName;
            while (InfoCategoryViewModel.Repository.CheckIsExists(a => a.SeoName == name && a.Specificulture == Specificulture && a.Id != Id))
            {
                name = SeoName + "_" + i;
            }
            SeoName = name;

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
                      IsActived = context.SiocCategoryPosition.Count(m => m.CategoryId == Id && m.PositionId == p.Id && m.Specificulture == Specificulture) > 0
                  });

            return query.OrderBy(m => m.Priority).ToList();
        }

        public List<CategoryModuleViewModel> GetModuleNavs(SiocCmsContext context, IDbContextTransaction transaction)
        {
            var query = context.SiocModule
                .Include(cp => cp.SiocCategoryModule)
                .Where(module => module.Specificulture == Specificulture)
                .Select(module => new CategoryModuleViewModel()
                {
                    CategoryId = Id,
                    ModuleId = module.Id,
                    Specificulture = Specificulture,
                    Description = module.Title,
                    Image = module.Image
                });

            var result = query.ToList();
            result.ForEach(nav =>
            {
                var currentNav = context.SiocCategoryModule.FirstOrDefault(
                        m => m.ModuleId == nav.ModuleId && m.CategoryId == Id && m.Specificulture == Specificulture);
                nav.Priority = currentNav?.Priority;
                nav.IsActived = currentNav != null;
            });
            return result.OrderBy(m => m.Priority).ToList();
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
                });

            var result = query.ToList();
            result.ForEach(nav =>
            {
                var currentNav = context.SiocCategoryCategory.FirstOrDefault(
                        m => m.ParentId == nav.Id && m.Id == Id && m.Specificulture == Specificulture);
                nav.Priority = currentNav?.Priority;
                nav.IsActived = currentNav != null;
            });
            return result.OrderBy(m => m.Priority).ToList();
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
                });

            var result = query.ToList();
            result.ForEach(nav =>
            {
                var currentNav = context.SiocCategoryCategory.FirstOrDefault(
                        m => m.ParentId == Id && m.Id == nav.Id && m.Specificulture == Specificulture);
                nav.Priority = currentNav?.Priority;
                nav.IsActived = currentNav != null;
            });
            return result.OrderBy(m => m.Priority).ToList();
        }

        #endregion Expands
    }
}