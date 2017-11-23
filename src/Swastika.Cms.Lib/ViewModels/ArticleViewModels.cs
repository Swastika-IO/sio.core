using Swastika.Cms.Lib.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Common.Helper;
using Swastika.Cms.Lib.Repositories;
using Swastika.Common;
using Swastika.Domain.Core.Models;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using Swastika.IO.Cms.Lib.Models;
using Swastika.IO.Cms.Lib;
using Swastika.IO.Cms.Lib.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ArticleBEViewModel :
        Swastika.Infrastructure.Data.ViewModels.ViewModelBase<SiocCmsContext, SiocArticle, ArticleBEViewModel>
    {

        public string Id { get; set; }
        //public string Specificulture { get; set; }
        //public List<SupportedCulture> ListSupportedCulture { get; set; } = IO.Cms.Lib.Services.ApplicationConfigService.ListSupportedCulture;

        public string Template { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string Source { get; set; }
        public int? Views { get; set; }
        public int Type { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public string Tags { get; set; }

        public List<CategoryArticleViewModel> Categories { get; set; }
        public List<ModuleArticleViewModel> Modules { get; set; } // Parent to Modules
        public List<ArticleModuleListItemViewModel> ModuleNavs { get; set; } // Children Modules
        public List<ModuleWithDataViewModel> ActivedModules { get; set; } // Children Modules
        public JArray ListTag { get; set; } = new JArray();
        public TemplateViewModel View { get; set; }
        public List<TemplateViewModel> Templates { get; set; }// Article Templates

        public FileStreamViewModel ImageFileStream { get; set; }
        public FileStreamViewModel ThumbnailFileStream { get; set; }

        public string TemplateFolder
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.TemplatesFolder
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

        public ArticleBEViewModel(SiocArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {            
        }
        public ArticleBEViewModel()
        {

        }


        #region Overrides

        public override ArticleBEViewModel ParseView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = IO.Cms.Lib.Services.ApplicationConfigService.ListSupportedCulture;

            var vm = base.ParseView(_context, _transaction);
            
            if (!string.IsNullOrEmpty(vm.Tags))
            {
                ListTag = JArray.Parse(vm.Tags);
            }

            vm.Templates = vm.Templates ?? TemplateRepository.Instance.GetTemplates(Constants.TemplateFolder.Articles);

            vm.View = Templates.FirstOrDefault(t => !string.IsNullOrEmpty(vm.Template) && vm.Template.Contains(t.Filename + t.Extension));
            if (vm.View == null)
            {
                //vm.Template = SWCmsHelper.GetFullPath(new string[]
                //{
                //    vm.TemplateFolder
                //    , SWCmsConstants.Default.ArticleTemplate
                //});
                vm.View = Templates.FirstOrDefault();//t => vm.Template.Contains(t.Filename + t.Extension)
                vm.Template = SWCmsHelper.GetFullPath(new string[]
                {
                    vm.View?.FileFolder
                    , vm.View?.Filename
                });
            }

            //var getCulture = CultureViewModel.Repository.GetModelList(_context, _transaction);
            //if (getCulture.IsSucceed)
            //{
            //    getCulture.Data.ForEach(c =>
            //    c.IsSupported = ArticleBEViewModel.Repository.CheckIsExists(
            //        a => a.Id == vm.Id && a.Specificulture == c.Specificulture));

            //    //vm.ListSupportedCulture = getCulture.Data;
            //}

            var getCateArticle = CommonRepository.Instance.GetCategoryArticleNav(Id, Specificulture, _context, _transaction);
            if (getCateArticle.IsSucceed)
            {
                vm.Categories = getCateArticle.Data;
            }

            var getModuleArticle = CommonRepository.Instance.GetModuleArticleNav(Id, Specificulture, _context, _transaction);
            if (getModuleArticle.IsSucceed)
            {
                vm.Modules = getModuleArticle.Data;
            }

            var getArticleModule = CommonRepository.Instance.GetArticleModuleNav(Id, Specificulture, _context, _transaction);
            if (getArticleModule.IsSucceed)
            {
                vm.ModuleNavs = getArticleModule.Data;
            }

            //if (string.IsNullOrEmpty(Id))
            //{
                vm.ListSupportedCulture.ForEach(c => c.IsSupported = (c.Specificulture == Specificulture));
            //}
            vm.ActivedModules = new List<ModuleWithDataViewModel>();
            foreach (var module in vm.ModuleNavs.Where(m => m.IsActived))
            {
                var getModule = ModuleWithDataViewModel.Repository.GetSingleModel(m => m.Id == module.ModuleId && m.Specificulture == module.Specificulture, _context, _transaction);
                if (getModule.IsSucceed)
                {
                    vm.ActivedModules.Add(getModule.Data);
                    vm.ActivedModules.ForEach(m => m.LoadData(Id));
                }
            }
            return vm;
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
                    SWCmsConstants.UploadFolder, "Articles", DateTime.UtcNow.ToString("dd-MM-yyyy")
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
                    SWCmsConstants.UploadFolder, "Articles", DateTime.UtcNow.ToString("dd-MM-yyyy")
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
            Template = View!=null? SWCmsHelper.GetFullPath(new string[] { View?.FileFolder, View?.Filename + View?.Extension }): Template;
            var model = base.ParseModel();

            return model;
        }
        //public override void Validate()
        //{

        //    if (IsValid && string.IsNullOrEmpty(Title))
        //    {
        //        IsValid = false;
        //        Errors.Add("Title is required");
        //    }
        //    if (string.IsNullOrEmpty(SeoName))
        //    {
        //        IsValid = false;
        //        Errors.Add("Seoname is required");
        //    }
        //}

        #region Async Methods        

        public override async Task<RepositoryResponse<ArticleBEViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Validate();
            if (IsValid)
            {
                GenerateSEO();
                return await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            }
            else
            {
                return new RepositoryResponse<ArticleBEViewModel>()
                {
                    IsSucceed = false,
                    Data = null,
                    Errors = Errors
                };
            }

        }

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
                                Ex = saveResult.Ex;
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
                        foreach (var data in module.Data.JsonItems)
                        {
                            SiocModuleData model = new SiocModuleData()
                            {
                                Id = Guid.NewGuid().ToString(),
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

                                    JObject fieldVal = new JObject();
                                    fieldVal.Add(new JProperty("dataType", col.DataType));
                                    fieldVal.Add(new JProperty("value", prop.Value));
                                    val.Add(new JProperty(prop.Name, fieldVal));
                                }
                            }
                            model.Value = val.ToString(Newtonsoft.Json.Formatting.None);
                            var vmData = new ModuleContentViewmodel(model);
                            var saveResult = await vmData.SaveModelAsync(false, _context, _transaction);
                            result = result && saveResult.IsSucceed;
                        }
                    }
                }

                return new RepositoryResponse<bool>()
                {
                    IsSucceed = result,
                    Data = result,
                    Errors = Errors,
                    Ex = Ex
                };

            }
            catch (Exception ex)
            {
                result = false;
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = false,
                    Data = false,
                    Ex = ex
                };
            }
        }
        public override async Task<RepositoryResponse<bool>> CloneSubModelsAsync(ArticleBEViewModel parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { };
            foreach (var moduleNav in ModuleNavs.Where(a => a.IsActived))
            {

                var getModule = await ModuleBEViewModel.Repository.GetSingleModelAsync(m => m.Id == moduleNav.ModuleId
                    && m.Specificulture == Specificulture, _context, _transaction);
                var module = getModule.Data;
                var cloneModule = await module.CloneAsync(ListSupportedCulture, _context, _transaction);
                if (cloneModule.IsSucceed)
                {
                    var cloneNav = await moduleNav.CloneAsync(ListSupportedCulture, _context, _transaction);
                    if (cloneNav.IsSucceed)
                    {
                        result.IsSucceed = cloneNav.IsSucceed;
                    }
                    else
                    {
                        result.Errors.AddRange(cloneNav.Errors);
                        result.Ex = cloneNav.Ex;
                    }

                }
                else
                {
                    result.Errors.AddRange(cloneModule.Errors);
                    result.Ex = cloneModule.Ex;
                }
            }
            return result;
        }
        //public override async Task<RepositoryResponse<ArticleBEViewModel>> CloneAsync(string desSpecificulture, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        //{
        //    ArticleBEViewModel cloneArticle = new ArticleBEViewModel(this.Model, _context, _transaction)
        //    {
        //        Id = Id,
        //        Specificulture = desSpecificulture,
        //        Categories = new List<CategoryArticleViewModel>(),
        //        Modules = new List<ModuleArticleViewModel>(),
        //        ModuleNavs = new List<ArticleModuleListItemViewModel>()
        //    };



        //    foreach (var moduleArticle in this.Modules.Where(p => p.IsActived))
        //    {
        //        cloneArticle.Modules.Add(new ModuleArticleViewModel(
        //            new SiocModuleArticle()
        //            {
        //                ArticleId = moduleArticle.ArticleId,
        //                Specificulture = desSpecificulture,
        //                ModuleId = moduleArticle.ModuleId
        //            },
        //            _context, _transaction)
        //        {
        //            IsActived = moduleArticle.IsActived,
        //            Description = moduleArticle.Description
        //        });
        //    }

        //    foreach (var moduleArticle in this.Modules.Where(p => p.IsActived))
        //    {
        //        cloneArticle.Modules.Add(new ModuleArticleViewModel(
        //            new SiocModuleArticle()
        //            {
        //                ArticleId = moduleArticle.ArticleId,
        //                Specificulture = desSpecificulture,
        //                ModuleId = moduleArticle.ModuleId
        //            },
        //            _context, _transaction)
        //        {
        //            IsActived = moduleArticle.IsActived,
        //            Description = moduleArticle.Description
        //        });
        //    }
        //    var cloneResult = await ArticleBEViewModel.Repository.SaveModelAsync(cloneArticle, true);
        //    return cloneResult;
        //}

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(ArticleBEViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>()
            {
                IsSucceed = true
            };

            if (result.IsSucceed)
            {
                foreach (var item in view.Categories)
                {
                    result = await item.RemoveModelAsync(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in view.Modules)
                {
                    result = await item.RemoveModelAsync(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in view.ModuleNavs)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }
            return result;
        }
        #endregion

        #region Sync Methods

        public override RepositoryResponse<bool> RemoveRelatedModels(ArticleBEViewModel model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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

        public override RepositoryResponse<ArticleBEViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Validate();
            if (IsValid)
            {
                GenerateSEO();
                return base.SaveModel(isSaveSubModels, _context, _transaction);
            }
            else
            {
                return new RepositoryResponse<ArticleBEViewModel>()
                {
                    IsSucceed = false,
                    Data = null,
                    Errors = Errors
                };
            }
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

                        var getcloneArticle = ArticleBEViewModel.Repository.GetSingleModel(b => b.Id == Id && b.Specificulture == supportedCulture.Specificulture
                            , _context, _transaction);
                        if (!getcloneArticle.IsSucceed && supportedCulture.IsSupported)
                        {
                            var cloneArticle = new ArticleBEViewModel(this.Model, _context, _transaction)
                            {
                                Id = Id,
                                Specificulture = supportedCulture.Specificulture,
                                Categories = new List<CategoryArticleViewModel>(),
                                Modules = new List<ModuleArticleViewModel>(),
                                ModuleNavs = new List<ArticleModuleListItemViewModel>()
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
                            var cloneResult = ArticleBEViewModel.Repository.SaveModel(cloneArticle, true);
                            result = result && cloneResult.IsSucceed;
                        }
                        else if (getcloneArticle.IsSucceed && !supportedCulture.IsSupported)
                        {
                            var delResult = ArticleBEViewModel.Repository.RemoveModel(b => b.Id == getcloneArticle.Data.Id && b.Specificulture == supportedCulture.Specificulture);
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
                    Ex = ex
                };
            }
        }
        #endregion

        #endregion
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

    }




    public class ArticleListItemViewModel :
        Swastika.Infrastructure.Data.ViewModels.ViewModelBase<SiocCmsContext, SiocArticle, ArticleListItemViewModel>
    {
        public string Id { get; set; }
        public string Specificulture { get; set; }
        public string Template { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string StaticUrl { get; set; }
        public string Source { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }

        public string DetailsUrl { get; set; }
        public string EditUrl { get; set; }

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

        public ArticleListItemViewModel(SiocArticle model
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }


    }

    public class FEArticleViewModel :
        Swastika.Infrastructure.Data.ViewModels.ViewModelBase<SiocCmsContext, SiocArticle, FEArticleViewModel>
    {
        public string Id { get; set; }
        public string Specificulture { get; set; }
        public string Template { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string StaticUrl { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string SeoName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string Source { get; set; }
        public int? Views { get; set; }
        public int Type { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public string Tags { get; set; }

        public List<ArticleModuleFEViewModel> Modules { get; set; }

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
        public FEArticleViewModel(SiocArticle model
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }


        #region Overrides

        public override FEArticleViewModel ParseView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(_context, _transaction);

            var getModulesResult = ArticleModuleFEViewModel.Repository.GetModelListBy(m => m.ArticleId == Id && m.Specificulture == Specificulture, _context, _transaction);
            if (getModulesResult.IsSucceed)
            {
                vm.Modules = getModulesResult.Data;
            }

            return vm;
        }

        #endregion
    }

}
