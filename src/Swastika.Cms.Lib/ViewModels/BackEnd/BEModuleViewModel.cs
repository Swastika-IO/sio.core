// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.Data.OData.Query;
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
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Swastika.Cms.Lib.SWCmsConstants;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocModule, BEModuleViewModel>
    {
        
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fields")]
        public string Fields { get; set; }

        [JsonProperty("type")]
        public ModuleType Type { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("data")]
        public PaginationModel<InfoModuleDataViewModel> Data { get; set; } = new PaginationModel<InfoModuleDataViewModel>();

        [JsonProperty("columns")]
        public List<ModuleFieldViewModel> Columns { get; set; }

        [JsonProperty("articles")]
        public PaginationModel<InfoArticleViewModel> Articles { get; set; } = new PaginationModel<InfoArticleViewModel>();

        [JsonProperty("products")]
        public PaginationModel<NavModuleProductViewModel> Products { get; set; } = new PaginationModel<NavModuleProductViewModel>();

        #region Template

        [JsonProperty("view")]
        public BETemplateViewModel View { get; set; }

        [JsonProperty("templates")]
        public List<BETemplateViewModel> Templates { get; set; }// Article Templates

        [JsonIgnore]
        public string ActivedTemplate {
            get {
                return GlobalConfigurationService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, Specificulture, SWCmsConstants.Default.DefaultTemplateFolder);
            }
        }

        [JsonIgnore]
        public string TemplateFolderType { get { return SWCmsConstants.EnumTemplateFolder.Modules.ToString(); } }

        [JsonProperty("templateFolder")]
        public string TemplateFolder {
            get {
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

        //Parent Article Id
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }

        //Parent Category Id
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public BEModuleViewModel() : base()
        {
        }

        public BEModuleViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override SiocModule ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                Id = InfoModuleViewModel.Repository.Count().Data + 1;
                LastModified = DateTime.UtcNow;
            }
            Template = View != null ? string.Format(@"{0}/{1}{2}", View.FolderType, View.FileName, View.Extension) : Template;
            var arrField = Columns != null ? JArray.Parse(
                Newtonsoft.Json.JsonConvert.SerializeObject(Columns.OrderBy(c => c.Priority).Where(
                    c => !string.IsNullOrEmpty(c.Name)))) : new JArray();
            Fields = arrField.ToString(Newtonsoft.Json.Formatting.None);

            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            ListSupportedCulture = CommonRepository.Instance.LoadCultures(Specificulture, _context, _transaction);
            this.ListSupportedCulture.ForEach(c => c.IsSupported =
           (Id == 0 && c.Specificulture == Specificulture)
           || Repository.CheckIsExists(a => a.Id == Id && a.Specificulture == c.Specificulture, _context, _transaction)
           );
            Columns = new List<ModuleFieldViewModel>();
            JArray arrField = !string.IsNullOrEmpty(Fields) ? JArray.Parse(Fields) : new JArray();
            foreach (var field in arrField)
            {
                ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["name"].ToString()),
                    Priority = field["priority"] != null ? field["priority"].Value<int>() : 0,
                    DataType = (SWCmsConstants.DataType)(int)field["dataType"],
                    Width = field["width"] != null ? field["width"].Value<int>() : 3,
                    IsDisplay = field["isDisplay"] != null ? field["isDisplay"].Value<bool>() : true
                };
                Columns.Add(thisField);
            }

            //Get Templates
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
            this.Template = SwCmsHelper.GetFullPath(new string[]
               {
                    this.View?.FileFolder
                    , this.View?.FileName
               });

            var getDataResult = InfoModuleDataViewModel.Repository
                .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                , "Priority", OrderByDirection.Ascending, null, null
                , _context, _transaction);
            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }
            var getArticles = InfoArticleViewModel.GetModelListByModule(Id, Specificulture, SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
                , _context: _context, _transaction: _transaction
                );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }

            var getProducts = NavModuleProductViewModel.Repository.GetModelListBy(
                m => m.ModuleId == Id && m.Specificulture == Specificulture
            , SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
            , null, null
                , _context: _context, _transaction: _transaction
                );
            if (getProducts.IsSucceed)
            {
                Products = getProducts.Data;
            }
        }

        #region Async

        public override Task<RepositoryResponse<SiocModule>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            return base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
        }

        public override async Task<RepositoryResponse<bool>> CloneSubModelsAsync(BEModuleViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            foreach (var data in parent.Data.Items)
            {
                var cloneData = await data.CloneAsync(data.Model, cloneCultures, _context, _transaction);
                if (cloneData.IsSucceed)
                {
                    result.IsSucceed = cloneData.IsSucceed;
                }
                else
                {
                    result.IsSucceed = cloneData.IsSucceed;
                    result.Errors.AddRange(cloneData.Errors);
                    result.Exception = cloneData.Exception;
                }
            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocModule parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var saveView = await View.SaveModelAsync(true, _context, _transaction);
            return new RepositoryResponse<bool>()
            {
                IsSucceed = saveView.IsSucceed,
                Data = saveView.IsSucceed,
                Exception = saveView.Exception,
                Errors = saveView.Errors
            };
        }

        #endregion Async

        #region Sync

        public override RepositoryResponse<bool> CloneSubModels(BEModuleViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            foreach (var data in parent.Data.Items)
            {
                var cloneData = data.Clone(data.Model, cloneCultures, _context, _transaction);
                if (cloneData.IsSucceed)
                {
                    result.IsSucceed = cloneData.IsSucceed;
                }
                else
                {
                    result.IsSucceed = cloneData.IsSucceed;
                    result.Errors.AddRange(cloneData.Errors);
                    result.Exception = cloneData.Exception;
                }
            }
            return result;
        }

        public override RepositoryResponse<bool> SaveSubModels(SiocModule parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var saveView = View.SaveModel(true, _context, _transaction);
            return new RepositoryResponse<bool>()
            {
                IsSucceed = saveView.IsSucceed,
                Data = saveView.IsSucceed,
                Exception = saveView.Exception,
                Errors = saveView.Errors
            };
        }

        #endregion Sync

        #endregion Overrides

        #region Expand

        public static RepositoryResponse<BEModuleViewModel> GetBy(
            Expression<Func<SiocModule, bool>> predicate, string articleId = null, string productId = null, int categoryId = 0
             , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = Repository.GetSingleModel(predicate, _context, _transaction);
            if (result.IsSucceed)
            {
                result.Data.ArticleId = articleId;
                result.Data.CategoryId = categoryId;
                result.Data.LoadData();
            }
            return result;
        }

        public void LoadData(string articleId = null, int? categoryId = null
            , int? pageSize = null, int? pageIndex = 0
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<PaginationModel<InfoModuleDataViewModel>> getDataResult = new RepositoryResponse<PaginationModel<InfoModuleDataViewModel>>();

            switch (Type)
            {
                case SWCmsConstants.ModuleType.Root:
                    getDataResult = InfoModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SWCmsConstants.ModuleType.SubPage:
                    getDataResult = InfoModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.CategoryId == categoryId)
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SWCmsConstants.ModuleType.SubArticle:
                    getDataResult = InfoModuleDataViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.ArticleId == articleId)
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                default:
                    break;
            }

            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }
        }

        #endregion Expand
    }
}