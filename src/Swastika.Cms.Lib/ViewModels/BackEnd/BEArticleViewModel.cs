// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Common.Helper;
using Swastika.Domain.Core.Models;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEArticleViewModel
        : ViewModelBase<SiocCmsContext, SiocArticle, BEArticleViewModel>
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

        [JsonProperty("domain")]
        public string Domain => GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/");

        [JsonProperty("categories")]
        public List<NavCategoryArticleViewModel> Categories { get; set; }

        [JsonProperty("modules")]
        public List<NavModuleArticleViewModel> Modules { get; set; } // Parent to Modules

        [JsonProperty("moduleNavs")]
        public List<NavArticleModuleViewModel> ModuleNavs { get; set; } // Children Modules

        [JsonProperty("mediaNavs")]
        public List<NavArticleMediaViewModel> MediaNavs { get; set; }

        [JsonProperty("jMediaNavs")]
        public JArray JMediaNavs { get { return JArray.FromObject(MediaNavs); } }

        [JsonProperty("activedModules")]
        public List<BEModuleViewModel> ActivedModules { get; set; } // Children Modules

        [JsonProperty("listTag")]
        public JArray ListTag { get; set; } = new JArray();

        [JsonProperty("imageFileStream")]
        public FileStreamViewModel ImageFileStream { get; set; }

        [JsonProperty("thumbnailFileStream")]
        public FileStreamViewModel ThumbnailFileStream { get; set; }

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
        public string TemplateFolderType { get { return SWCmsConstants.TemplateFolderEnum.Articles.ToString(); } }

        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return SwCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , ActivedTemplate
                    , TemplateFolderType
                }
            );
            }
        }

        #endregion Template

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
                if (Thumbnail != null && Thumbnail.IndexOf("http") == -1)
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
        }

        [JsonProperty("properties")]
        public List<ExtraProperty> Properties { get; set; }
        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }
        #endregion Views

        #endregion Properties

        #region Contructors

        public BEArticleViewModel() : base()
        {
        }

        public BEArticleViewModel(SiocArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            //if (!string.IsNullOrEmpty(this.Tags))
            //{
            //    ListTag = JArray.Parse(this.Tags);
            //}
            Properties = new List<ExtraProperty>();
            if (!string.IsNullOrEmpty(ExtraProperties))
            {
                JArray arr = JArray.Parse(ExtraProperties);
                foreach (JToken item in arr)
                {
                    Properties.Add(item.ToObject<ExtraProperty>());
                }
            }
            //Get Templates
            this.Templates = this.Templates ??
                BETemplateViewModel.Repository.GetModelListBy(
                t => t.Template.Name == ActivedTemplate && t.FolderType == this.TemplateFolderType).Data;
            if (!string.IsNullOrEmpty(Template))
            {
                this.View = Templates.FirstOrDefault(t => Template.Contains(t.FileName));
            }
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

            this.Template = SwCmsHelper.GetFullPath(new string[]
               {
                    this.View?.FileFolder
                    , this.View?.FileName
               });

            var getCateArticle = CommonRepository.Instance.GetCategoryArticleNav(Id, Specificulture, _context, _transaction);
            if (getCateArticle.IsSucceed)
            {
                this.Categories = getCateArticle.Data;
                this.Categories.ForEach(c =>
                {
                    c.IsActived = NavCategoryArticleViewModel.Repository.CheckIsExists(n => n.CategoryId == c.CategoryId && n.ArticleId == Id, _context, _transaction);
                });
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

            var getArticleMedia = NavArticleMediaViewModel.Repository.GetModelListBy(n => n.ArticleId == Id && n.Specificulture == Specificulture, _context, _transaction);
            if (getArticleMedia.IsSucceed)
            {
                MediaNavs = getArticleMedia.Data.OrderBy(p => p.Priority).ToList();
                MediaNavs.ForEach(n => n.IsActived = true);
            }

            this.ListSupportedCulture.ForEach(c => c.IsSupported =
            (string.IsNullOrEmpty(Id) && c.Specificulture == Specificulture)
            || Repository.CheckIsExists(a => a.Id == Id && a.Specificulture == c.Specificulture, _context, _transaction)
            );
            this.ActivedModules = new List<BEModuleViewModel>();
            foreach (var module in this.ModuleNavs.Where(m => m.IsActived))
            {
                var getModule = BEModuleViewModel.Repository.GetSingleModel(m => m.Id == module.ModuleId && m.Specificulture == module.Specificulture, _context, _transaction);
                if (getModule.IsSucceed)
                {
                    this.ActivedModules.Add(getModule.Data);
                    this.ActivedModules.ForEach(m => m.LoadData(Id));
                }
            }
        }

        public override SiocArticle ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
                CreatedDateTime = DateTime.UtcNow;
            }
            if (Properties.Count > 0)
            {
                JArray arrProperties = new JArray();
                foreach (var p in Properties.Where(p => !string.IsNullOrEmpty(p.Value) && !string.IsNullOrEmpty(p.Name)).OrderBy(p => p.Priority))
                {
                    arrProperties.Add(JObject.FromObject(p));
                }
                ExtraProperties = arrProperties.ToString(Formatting.None);
            }

            Template = View != null ? string.Format(@"{0}/{1}{2}", View.FolderType, View.FileName, View.Extension) : Template;
            if (ThumbnailFileStream != null)
            {
                string folder = SwCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.UploadFolder, "Articles", DateTime.UtcNow.ToString("dd-MM-yyyy")
                });
                string filename = SwCmsHelper.GetRandomName(ThumbnailFileStream.Name);
                bool saveThumbnail = SwCmsHelper.SaveFileBase64(folder, filename, ThumbnailFileStream.Base64);
                if (saveThumbnail)
                {
                    SwCmsHelper.RemoveFile(Thumbnail);
                    Thumbnail = SwCmsHelper.GetFullPath(new string[] { folder, filename });
                }
            }
            if (ImageFileStream != null)
            {
                string folder = SwCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.UploadFolder, "Articles", DateTime.UtcNow.ToString("dd-MM-yyyy")
                });
                string filename = SwCmsHelper.GetRandomName(ImageFileStream.Name);
                bool saveImage = SwCmsHelper.SaveFileBase64(folder, filename, ImageFileStream.Base64);
                if (saveImage)
                {
                    SwCmsHelper.RemoveFile(Image);
                    Image = SwCmsHelper.GetFullPath(new string[] { folder, filename });
                }
            }

            //Tags = ListTag.ToString(Newtonsoft.Json.Formatting.None);
            GenerateSEO();

            return base.ParseModel(_context, _transaction);
        }

        #region Async Methods

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(
            SiocArticle parent
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            try
            {
                // Save Template
                var saveTemplate = await View.SaveModelAsync(false, _context, _transaction);
                result.IsSucceed = result.IsSucceed && saveTemplate.IsSucceed;
                if (saveTemplate.IsSucceed)
                {
                    result.Errors.AddRange(saveTemplate.Errors);
                    result.Exception = saveTemplate.Exception;
                }

                if (result.IsSucceed)
                {
                    // Save Parent Category
                    foreach (var item in Categories)
                    {
                        item.ArticleId = parent.Id;
                        if (item.IsActived)
                        {
                            var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result.IsSucceed)
                {
                    // Save Parent Modules
                    foreach (var item in Modules)
                    {
                        item.ArticleId = parent.Id;
                        if (item.IsActived)
                        {
                            var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = await item.RemoveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result.IsSucceed)
                {
                    // Save Children Category
                    foreach (var item in ModuleNavs)
                    {
                        item.ArticleId = parent.Id;
                        if (item.IsActived)
                        {
                            var saveResult = await item.SaveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = await item.RemoveModelAsync(true, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                //save submodules data
                if (result.IsSucceed)
                {
                    foreach (var module in ActivedModules)
                    {
                        module.Data.Items = new List<InfoModuleDataViewModel>();
                        foreach (var data in module.Data.JsonItems)
                        {
                            SiocModuleData model = new SiocModuleData()
                            {
                                Id = data.Value<string>("id") ?? Guid.NewGuid().ToString(),
                                Specificulture = module.Specificulture,
                                ArticleId = parent.Id,
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

                            var vmData = new InfoModuleDataViewModel(model);

                            var saveResult = await vmData.SaveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result.IsSucceed)
                {
                    foreach (var navMedia in MediaNavs)
                    {
                        navMedia.ArticleId = parent.Id;
                        navMedia.Specificulture = parent.Specificulture;

                        if (navMedia.IsActived)
                        {
                            var saveResult = await navMedia.SaveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = await navMedia.RemoveModelAsync(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                result.IsSucceed = false;
                result.Exception = ex;
                return result;
            }
        }

        public override async Task<RepositoryResponse<bool>> CloneSubModelsAsync(BEArticleViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            if (ActivedModules.Count > 0)
            {
                foreach (var module in ActivedModules)
                {
                    module.ParseModel();
                    var cloneModule = await module.CloneAsync(module.Model, cloneCultures, _context, _transaction);
                    if (cloneModule.IsSucceed)
                    {
                        var moduleNav = ModuleNavs.FirstOrDefault(m => m.ModuleId == module.Id &&
                            m.ArticleId == parent.Id && m.Specificulture == module.Specificulture);
                        var cloneNav = await moduleNav.CloneAsync(moduleNav.Model, cloneCultures, _context, _transaction);
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
                    result = await item.RemoveModelAsync(false, _context, _transaction).ConfigureAwait(false);
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

            if (result.IsSucceed)
            {
                foreach (var item in view.MediaNavs)
                {
                    result = await item.RemoveModelAsync(false, _context, _transaction);
                }
            }
            return result;
        }

        #endregion Async Methods

        #region Sync Methods

        public override RepositoryResponse<bool> RemoveRelatedModels(BEArticleViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>()
            {
                IsSucceed = true
            };

            if (result.IsSucceed)
            {
                foreach (var item in view.Categories)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in view.Modules)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in view.ModuleNavs)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }

            if (result.IsSucceed)
            {
                foreach (var item in view.MediaNavs)
                {
                    result = item.RemoveModel(false, _context, _transaction);
                }
            }
            return result;
        }

        public override RepositoryResponse<bool> SaveSubModels(
            SiocArticle parent
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            try
            {
                // Save Template
                var saveTemplate = View.SaveModel(false, _context, _transaction);
                result.IsSucceed = result.IsSucceed && saveTemplate.IsSucceed;
                if (saveTemplate.IsSucceed)
                {
                    result.Errors.AddRange(saveTemplate.Errors);
                    result.Exception = saveTemplate.Exception;
                }

                if (result.IsSucceed)
                {
                    // Save Parent Category
                    foreach (var item in Categories)
                    {
                        item.ArticleId = parent.Id;
                        if (item.IsActived)
                        {
                            var saveResult = item.SaveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = item.RemoveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result.IsSucceed)
                {
                    // Save Parent Modules
                    foreach (var item in Modules)
                    {
                        item.ArticleId = parent.Id;
                        if (item.IsActived)
                        {
                            var saveResult = item.SaveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = item.RemoveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result.IsSucceed)
                {
                    // Save Children Category
                    foreach (var item in ModuleNavs)
                    {
                        item.ArticleId = parent.Id;
                        if (item.IsActived)
                        {
                            var saveResult = item.SaveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = item.RemoveModel(true, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                //save submodules data
                if (result.IsSucceed)
                {
                    foreach (var module in ActivedModules)
                    {
                        module.Data.Items = new List<InfoModuleDataViewModel>();
                        foreach (var data in module.Data.JsonItems)
                        {
                            SiocModuleData model = new SiocModuleData()
                            {
                                Id = data.Value<string>("id") ?? Guid.NewGuid().ToString(),
                                Specificulture = module.Specificulture,
                                ArticleId = parent.Id,
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

                            var vmData = new InfoModuleDataViewModel(model);

                            var saveResult = vmData.SaveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                if (result.IsSucceed)
                {
                    foreach (var navMedia in MediaNavs)
                    {
                        navMedia.ArticleId = parent.Id;
                        navMedia.Specificulture = parent.Specificulture;

                        if (navMedia.IsActived)
                        {
                            var saveResult = navMedia.SaveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                        else
                        {
                            var saveResult = navMedia.RemoveModel(false, _context, _transaction);
                            result.IsSucceed = saveResult.IsSucceed;
                            if (!result.IsSucceed)
                            {
                                result.Exception = saveResult.Exception;
                                Errors.AddRange(saveResult.Errors);
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                result.IsSucceed = false;
                result.Exception = ex;
                return result;
            }
        }

        #endregion Sync Methods

        #endregion Overrides

        #region Expands

        private void GenerateSEO()
        {
            if (string.IsNullOrEmpty(this.SeoName))
            {
                this.SeoName = SeoHelper.GetSEOString(this.Title);
            }
            int i = 1;
            string name = SeoName;
            while (BEArticleViewModel.Repository.CheckIsExists(a => a.SeoName == name && a.Specificulture == Specificulture && a.Id != Id))
            {
                name = SeoName + "_" + i;
                i++;
            }
            SeoName = name;

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