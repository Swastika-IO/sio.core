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

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEArticleViewModel
        : ViewModelBase<SiocCmsContext, SiocArticle , BEArticleViewModel>
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
        #endregion

        #region Views
        [JsonProperty("categories")]
        public List<CategoryArticleViewModel> Categories { get; set; }
        [JsonProperty("modules")]
        public List<ModuleArticleViewModel> Modules { get; set; } // Parent to Modules
        [JsonProperty("moduleNavs")]
        public List<BEArticleModuleViewModel> ModuleNavs { get; set; } // Children Modules
        [JsonProperty("activedModules")]
        public List<ModuleWithDataViewModel> ActivedModules { get; set; } // Children Modules
        [JsonProperty("listTag")]
        public JArray ListTag { get; set; } = new JArray();
        [JsonProperty("view")]
        public TemplateViewModel View { get; set; }
        [JsonProperty("templates")]
        public List<TemplateViewModel> Templates { get; set; }// Article Templates
        [JsonProperty("imageFileStream")]
        public FileStreamViewModel ImageFileStream { get; set; }
        [JsonProperty("thumbnailFileStream")]
        public FileStreamViewModel ThumbnailFileStream { get; set; }
        [JsonProperty("templateFolder")]
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


        #endregion

        #endregion

        #region Contructors

        public BEArticleViewModel() : base()
        {
        }

        public BEArticleViewModel(SiocArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = ApplicationConfigService.ListSupportedCulture;

            if (!string.IsNullOrEmpty(this.Tags))
            {
                ListTag = JArray.Parse(this.Tags);
            }

            this.Templates = this.Templates ?? TemplateRepository.Instance.GetTemplates(
                SWCmsConstants.TemplateFolder.Articles);

            this.View = Templates.FirstOrDefault(t => !string.IsNullOrEmpty(this.Template) && this.Template.Contains(t.Filename + t.Extension));
            if (this.View == null)
            {
                this.View = new TemplateViewModel()
                {
                    Extension = SWCmsConstants.Parameters.TemplateExtension,
                    FileFolder = SWCmsConstants.TemplateFolder.Articles,
                    Filename = SWCmsConstants.Default.DefaultTemplate,
                    Content = "<div></div>"
                };
                this.Template = SWCmsHelper.GetFullPath(new string[]
                {
                    this.View?.FileFolder
                    , this.View?.Filename
                });
            }

            var getCateArticle = CommonRepository.Instance.GetCategoryArticleNav(Id, Specificulture, _context, _transaction);
            if (getCateArticle.IsSucceed)
            {
                this.Categories = getCateArticle.Data;
            }

            var getModuleArticle = CommonRepository.Instance.GetModuleArticleNav(Id, Specificulture, _context, _transaction);
            if (getModuleArticle.IsSucceed)
            {
                this.Modules = getModuleArticle.Data;
            }

            var getArticleModule = CommonRepository.Instance.GetArticleModuleNav(Id, Specificulture, _context, _transaction);
            if (getArticleModule.IsSucceed)
            {
                this.ModuleNavs = getArticleModule.Data;
            }

            this.ListSupportedCulture.ForEach(c => c.IsSupported =
            (string.IsNullOrEmpty(Id) && c.Specificulture == Specificulture)
            || Repository.CheckIsExists(a => a.Id == Id && a.Specificulture == c.Specificulture, _context, _transaction)
            );
            this.ActivedModules = new List<ModuleWithDataViewModel>();
            foreach (var module in this.ModuleNavs.Where(m => m.IsActived))
            {
                var getModule = ModuleWithDataViewModel.Repository.GetSingleModel(m => m.Id == module.ModuleId && m.Specificulture == module.Specificulture, _context, _transaction);
                if (getModule.IsSucceed)
                {
                    this.ActivedModules.Add(getModule.Data);
                    this.ActivedModules.ForEach(m => m.LoadData(Id));
                }
            }
        }

        public override SiocArticle ParseModel()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString(); //Common.Common.GetBase62(8);
                CreatedDateTime = DateTime.UtcNow;
            }
            if (ThumbnailFileStream != null)
            {
                string folder = SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.UploadFolder, "Articles", DateTime.UtcNow.ToString("dd-MM-yyyy")
                });
                string filename = SWCmsHelper.GetRandomName(ThumbnailFileStream.Name);
                bool saveThumbnail = SWCmsHelper.SaveFileBase64(folder, filename, ThumbnailFileStream.Base64);
                if (saveThumbnail)
                {
                    SWCmsHelper.RemoveFile(Thumbnail);
                    Thumbnail = SWCmsHelper.GetFullPath(new string[] { folder, filename });
                }
            }
            if (ImageFileStream != null)
            {
                string folder = SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.UploadFolder, "Articles", DateTime.UtcNow.ToString("dd-MM-yyyy")
                });
                string filename = SWCmsHelper.GetRandomName(ImageFileStream.Name);
                bool saveImage = SWCmsHelper.SaveFileBase64(folder, filename, ImageFileStream.Base64);
                if (saveImage)
                {
                    SWCmsHelper.RemoveFile(Image);
                    Image = SWCmsHelper.GetFullPath(new string[] { folder, filename });
                }
            }

            Tags = ListTag.ToString(Newtonsoft.Json.Formatting.None);
            Template = View != null ? SWCmsHelper.GetFullPath(new string[] { View?.FileFolder, View?.Filename + View?.Extension }) : Template;

            GenerateSEO();

            return base.ParseModel();
        }

        #region Async Methods        

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(
            SiocArticle parent
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            bool result = true;
            TemplateRepository.Instance.SaveTemplate(View);
            try
            {

                if (result)
                {
                    foreach (var item in Categories)
                    {
                        item.ArticleId = Id;
                        if (item.IsActived)
                        {
                            var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                            result = result && saveResult.IsSucceed;
                            if (!result)
                            {
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                            result = result && saveResult.IsSucceed;
                            if (!result)
                            {
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result)
                {
                    foreach (var item in Modules)
                    {
                        item.ArticleId = Id;
                        if (item.IsActived)
                        {
                            var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                            result = result && saveResult.IsSucceed;
                            if (!result)
                            {
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                            result = result && saveResult.IsSucceed;
                            if (!result)
                            {
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result)
                {
                    foreach (var item in ModuleNavs)
                    {
                        item.ArticleId = Id;
                        if (item.IsActived)
                        {
                            var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                        }
                        else
                        {
                            var saveResult = await item.RemoveModelAsync(true, _context, _transaction);
                            result = saveResult.IsSucceed;
                            if (!result)
                            {
                                Errors.AddRange(saveResult.Errors);
                                Ex = saveResult.Exception;
                            }
                        }
                    }
                }

                // save submodules navs
                if (result)
                {
                    foreach (var item in Modules)
                    {
                        item.ArticleId = Id;
                        if (item.IsActived)
                        {
                            var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                            result = result && saveResult.IsSucceed;
                            if (!result)
                            {
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                            result = result && saveResult.IsSucceed;
                            if (!result)
                            {
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                //save submodules data
                if (result)
                {
                    foreach (var module in ActivedModules)
                    {
                        module.Data.Items = new List<ModuleContentViewmodel>();
                        foreach (var data in module.Data.JsonItems)
                        {

                            SiocModuleData model = new SiocModuleData()
                            {
                                Id = data.Value<string>("id") ?? Guid.NewGuid().ToString(),
                                Specificulture = module.Specificulture,
                                ArticleId = Id,
                                ModuleId = module.Id,
                                Fields = module.Fields,
                                CreatedDateTime = DateTime.UtcNow,
                                UpdatedDateTime = DateTime.UtcNow
                            };

                            List<ModuleFieldViewModel> cols = module.Columns;
                            JObject val = new JObject();

                            foreach (JProperty prop in data.Properties())
                            {
                                var col = cols.FirstOrDefault(c => c.Name == prop.Name);
                                if (col != null)
                                {

                                    JObject fieldVal = new JObject
                                    {
                                        new JProperty("dataType", col.DataType),
                                        new JProperty("value", prop.Value)
                                    };
                                    val.Add(new JProperty(prop.Name, fieldVal));
                                }
                            }
                            model.Value = val.ToString(Newtonsoft.Json.Formatting.None);

                            var vmData = new ModuleContentViewmodel(model);

                            var saveResult = await vmData.SaveModelAsync(false, _context, _transaction);
                            if (saveResult.IsSucceed)
                            {
                                module.Data.Items.Add(vmData);
                            }
                            else
                            {
                                Errors.AddRange(saveResult.Errors);
                                Ex = saveResult.Exception;
                            }
                            result = result && saveResult.IsSucceed;
                        }
                    }
                }

                return new RepositoryResponse<bool>()
                {
                    IsSucceed = result,
                    Data = result,
                    Errors = Errors,
                    Exception = Ex
                };

            }
            catch (Exception ex)
            {
                result = false;
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = false,
                    Data = false,
                    Exception = ex
                };
            }
        }
        public override async Task<RepositoryResponse<bool>> CloneSubModelsAsync(BEArticleViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { };
            foreach (var module in ActivedModules)
            {
                module.ParseModel();
                var cloneModule = await module.CloneAsync(cloneCultures, _context, _transaction);
                if (cloneModule.IsSucceed)
                {
                    var moduleNav = ModuleNavs.FirstOrDefault(m => m.ModuleId == module.Id &&
                        m.ArticleId == Id && m.Specificulture == module.Specificulture);
                    var cloneNav = await moduleNav.CloneAsync(cloneCultures, _context, _transaction);
                    if (cloneNav.IsSucceed)
                    {
                        result.IsSucceed = cloneNav.IsSucceed;
                    }
                    else
                    {
                        result.IsSucceed = cloneNav.IsSucceed;
                        result.Errors.AddRange(cloneNav.Errors);
                        result.Exception = cloneNav.Exception;
                    }

                }
                else
                {
                    result.Errors.AddRange(cloneModule.Errors);
                    result.Exception = cloneModule.Exception;
                }
            }
            return result;
        }

       

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(BEArticleViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>()
            {
                IsSucceed = true
            };

            if (result.IsSucceed)
            {
                foreach (var item in view.Categories.Where(m => m.IsActived))
                {
                    result = await item.RemoveModelAsync(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in view.Modules.Where(m => m.IsActived))
                {
                    result = await item.RemoveModelAsync(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in view.ModuleNavs.Where(m => m.IsActived))
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }
            return result;
        }
        #endregion

        #region Sync Methods

        public override RepositoryResponse<bool> RemoveRelatedModels(BEArticleViewModel model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>()
            {
                IsSucceed = true
            };

            if (result.IsSucceed)
            {
                foreach (var item in model.Categories)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in model.Modules)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in model.ModuleNavs)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }
            return result;
        }


        public override RepositoryResponse<bool> SaveSubModels(SiocArticle parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            bool result = true;
            TemplateRepository.Instance.SaveTemplate(View);
            try
            {
                foreach (var supportedCulture in ListSupportedCulture.Where(c => c.Specificulture != Specificulture))
                {

                    if (result)
                    {

                        var getcloneArticle = BEArticleViewModel.Repository.GetSingleModel(b => b.Id == Id && b.Specificulture == supportedCulture.Specificulture
                            , _context, _transaction);
                        if (!getcloneArticle.IsSucceed && supportedCulture.IsSupported)
                        {
                            var cloneArticle = new BEArticleViewModel(this.Model, _context, _transaction)
                            {
                                Id = Id,
                                Specificulture = supportedCulture.Specificulture,
                                Categories = new List<CategoryArticleViewModel>(),
                                Modules = new List<ModuleArticleViewModel>(),
                                ModuleNavs = new List<BEArticleModuleViewModel>()
                            };
                            foreach (var cateArticle in this.Categories.Where(p => p.IsActived))
                            {
                                cloneArticle.Categories.Add(new CategoryArticleViewModel(
                                    new SiocCategoryArticle()
                                    {
                                        ArticleId = cateArticle.ArticleId,
                                        Specificulture = supportedCulture.Specificulture,
                                        CategoryId = cateArticle.CategoryId,
                                    },
                                    _context, _transaction)
                                {

                                    IsActived = cateArticle.IsActived,
                                    Description = cateArticle.Description
                                });
                            }

                            foreach (var moduleArticle in this.Modules.Where(p => p.IsActived))
                            {
                                cloneArticle.Modules.Add(new ModuleArticleViewModel(
                                    new SiocModuleArticle()
                                    {
                                        ArticleId = moduleArticle.ArticleId,
                                        Specificulture = supportedCulture.Specificulture,
                                        ModuleId = moduleArticle.ModuleId
                                    },
                                    _context, _transaction)
                                {

                                    IsActived = moduleArticle.IsActived,
                                    Description = moduleArticle.Description
                                });
                            }

                            foreach (var moduleArticle in this.Modules.Where(p => p.IsActived))
                            {
                                cloneArticle.Modules.Add(new ModuleArticleViewModel(
                                    new SiocModuleArticle()
                                    {
                                        ArticleId = moduleArticle.ArticleId,
                                        Specificulture = supportedCulture.Specificulture,
                                        ModuleId = moduleArticle.ModuleId
                                    },
                                    _context, _transaction)
                                {

                                    IsActived = moduleArticle.IsActived,
                                    Description = moduleArticle.Description
                                });
                            }
                            var cloneResult = BEArticleViewModel.Repository.SaveModel(cloneArticle, true);
                            result = result && cloneResult.IsSucceed;
                        }
                        else if (getcloneArticle.IsSucceed && !supportedCulture.IsSupported)
                        {
                            var delResult = BEArticleViewModel.Repository.RemoveModel(b => b.Id == getcloneArticle.Data.Id && b.Specificulture == supportedCulture.Specificulture);
                            result = result && delResult.IsSucceed;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = result,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                result = false;
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = false,
                    Data = false,
                    Exception = ex
                };
            }
        }
        #endregion

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
