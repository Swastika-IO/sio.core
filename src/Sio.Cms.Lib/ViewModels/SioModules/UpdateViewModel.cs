using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Repositories;
using Sio.Cms.Lib.Services;
using Sio.Cms.Lib.ViewModels.SioSystem;
using Sio.Common.Helper;
using Sio.Domain.Core.Models;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioModules
{
    //Use for update module info only => don't need to load data
    public class UpdateViewModel : ViewModelBase<SioCmsContext, SioModule, UpdateViewModel>
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
        
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("formTemplate")]
        public string FormTemplate { get; set; }

        [JsonProperty("edmTemplate")]
        public string EdmTemplate { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fields")]
        public string Fields { get; set; }

        [JsonProperty("type")]
        public SioModuleType Type { get; set; }

        [JsonProperty("status")]
        public SioContentStatus Status { get; set; }

        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion Models

        #region Views
        [JsonProperty("domain")]
        public string Domain { get { return SioService.GetConfig<string>("Domain"); } }

        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Image) && (Image.IndexOf("http") == -1) && Image[0] != '/')
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

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl
        {
            get
            {
                if (Thumbnail != null && Thumbnail.IndexOf("http") == -1 && Thumbnail[0] != '/')
                {
                    return CommonHelper.GetFullPath(new string[] {
                    Domain,  Thumbnail
                });
                }
                else
                {
                    return string.IsNullOrEmpty(Thumbnail) ? ImageUrl : Thumbnail;
                }
            }
        }

        [JsonProperty("data")]
        public PaginationModel<SioModuleDatas.ReadViewModel> Data { get; set; } = new PaginationModel<SioModuleDatas.ReadViewModel>();

        [JsonProperty("columns")]
        public List<ModuleFieldViewModel> Columns { get; set; }

        #region Template
        [JsonProperty("templates")]
        public List<SioTemplates.UpdateViewModel> Templates { get; set; }// Article Templates

        [JsonIgnore]
        public string TemplateFolderType
        {
            get
            {
                return SioEnums.EnumTemplateFolder.Modules.ToString();
            }
        }
        [JsonProperty("view")]
        public SioTemplates.UpdateViewModel View { get; set; }

        [JsonIgnore]
        public int ActivedTheme
        {
            get
            {
                return SioService.GetConfig<int>(SioConstants.ConfigurationKeyword.ThemeId, Specificulture);
            }
        }

        [JsonIgnore]
        public string ThemeFolderType { get { return SioEnums.EnumTemplateFolder.Modules.ToString(); } }

        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[]
                {
                    SioConstants.Folder.TemplatesFolder
                    , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ThemeName, Specificulture)
                    , ThemeFolderType
                }
            );
            }
        }

        #endregion Template

        #region Form
        [JsonProperty("forms")]
        public List<SioTemplates.UpdateViewModel> Forms { get; set; }// Article Forms

        [JsonIgnore]
        public string FormFolderType
        {
            get
            {
                return SioEnums.EnumTemplateFolder.Forms.ToString();
            }
        }
        [JsonProperty("formView")]
        public SioTemplates.UpdateViewModel FormView { get; set; }

        [JsonProperty("formFolder")]
        public string FormFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[]
                {
                    SioConstants.Folder.TemplatesFolder
                    , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ThemeName, Specificulture)
                    , SioEnums.EnumTemplateFolder.Forms.ToString()
                }
            );
            }
        }

        #endregion Form

        #region Edm
        [JsonProperty("edms")]
        public List<SioTemplates.UpdateViewModel> Edms { get; set; }// Article Edms

        [JsonIgnore]
        public string EdmFolderType
        {
            get
            {
                return SioEnums.EnumTemplateFolder.Edms.ToString();
            }
        }

        [JsonProperty("edmView")]
        public SioTemplates.UpdateViewModel EdmView { get; set; }

        [JsonProperty("edmFolder")]
        public string EdmFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[]
                {
                    SioConstants.Folder.TemplatesFolder
                    , SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.ThemeName, Specificulture)
                    , SioEnums.EnumTemplateFolder.Edms.ToString()
                }
            );
            }
        }

        #endregion Edm

        //Parent Article Id
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }

        //Parent Category Id
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public UpdateViewModel() : base()
        {
        }

        public UpdateViewModel(SioModule model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override void Validate(SioCmsContext _context, IDbContextTransaction _transaction)
        {
            base.Validate(_context, _transaction);
            if (IsValid && Id == 0)
            {
                IsValid = !Repository.CheckIsExists(m => m.Name == Name && m.Specificulture == Specificulture
                , _context, _transaction);
                if (!IsValid)
                {
                    Errors.Add("Module Name Existed");
                }
            }
        }
        public override SioModule ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                Id = ReadListItemViewModel.Repository.Max(m => m.Id, _context, _transaction).Data + 1;
                LastModified = DateTime.UtcNow;
                CreatedDateTime = DateTime.UtcNow;
            }
            Template = View != null ? string.Format(@"{0}/{1}{2}", View.FolderType, View.FileName, View.Extension) : Template;
            FormTemplate = FormView != null ? string.Format(@"{0}/{1}{2}", FormView.FolderType, FormView.FileName, FormView.Extension) : FormTemplate;
            EdmTemplate = EdmView != null ? string.Format(@"{0}/{1}{2}", EdmView.FolderType, EdmView.FileName, EdmView.Extension) : EdmTemplate;

            var arrField = Columns != null ? JArray.Parse(
                Newtonsoft.Json.JsonConvert.SerializeObject(Columns.OrderBy(c => c.Priority).Where(
                    c => !string.IsNullOrEmpty(c.Name)))) : new JArray();
            Fields = arrField.ToString(Newtonsoft.Json.Formatting.None);
            if (!string.IsNullOrEmpty(Image) && Image[0] == '/') { Image = Image.Substring(1); }            
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Cultures = SioModules.Helper.LoadCultures(Id, Specificulture, _context, _transaction);
            Cultures.ForEach(c => c.IsSupported = _context.SioModule.Any(m => m.Id == Id && m.Specificulture == c.Specificulture));
            Columns = new List<ModuleFieldViewModel>();
            JArray arrField = !string.IsNullOrEmpty(Fields) ? JArray.Parse(Fields) : new JArray();
            foreach (var field in arrField)
            {
                ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["name"].ToString()),
                    Title = field["title"]?.ToString(),
                    Options = field["options"] != null ? field["options"].Value<JArray>() : new JArray(),
                    Priority = field["priority"] != null ? field["priority"].Value<int>() : 0,
                    DataType = (SioDataType)(int)field["dataType"],
                    Width = field["width"] != null ? field["width"].Value<int>() : 3,
                    IsUnique = field["isUnique"] != null ? field["isUnique"].Value<bool>() : true,
                    IsRequired = field["isRequired"] != null ? field["isRequired"].Value<bool>() : true,
                    IsDisplay = field["isDisplay"] != null ? field["isDisplay"].Value<bool>() : true,
                    IsSelect = field["isSelect"] != null ? field["isSelect"].Value<bool>() : false,
                    IsGroupBy = field["isGroupBy"] != null ? field["isGroupBy"].Value<bool>() : false,
                };
                Columns.Add(thisField);
            }
            this.Templates = this.Templates ?? SioTemplates.UpdateViewModel.Repository.GetModelListBy(
                t => t.Theme.Id == ActivedTheme && t.FolderType == this.TemplateFolderType).Data;
            this.View = SioTemplates.UpdateViewModel.GetTemplateByPath(Template, Specificulture, SioEnums.EnumTemplateFolder.Modules, _context, _transaction);
            this.Template = CommonHelper.GetFullPath(new string[]
               {
                    this.View?.FileFolder
                    , this.View?.FileName
               });

            this.Forms = this.Forms ?? SioTemplates.UpdateViewModel.Repository.GetModelListBy(
                t => t.Theme.Id == ActivedTheme && t.FolderType == this.FormFolderType).Data;
            this.FormView = SioTemplates.UpdateViewModel.GetTemplateByPath(FormTemplate, Specificulture, SioEnums.EnumTemplateFolder.Forms, _context, _transaction);
            this.FormTemplate = CommonHelper.GetFullPath(new string[]
               {
                    this.FormView?.FileFolder
                    , this.FormView?.FileName
               });

            this.Edms = this.Edms ?? SioTemplates.UpdateViewModel.Repository.GetModelListBy(
                t => t.Theme.Id == ActivedTheme && t.FolderType == this.EdmFolderType).Data;
            this.EdmView = SioTemplates.UpdateViewModel.GetTemplateByPath(EdmTemplate, Specificulture, SioEnums.EnumTemplateFolder.Edms, _context, _transaction);
            this.EdmTemplate = CommonHelper.GetFullPath(new string[]
               {
                    this.EdmView?.FileFolder
                    , this.EdmView?.FileName
               });
        }

        #region Async

        public override Task<RepositoryResponse<SioModule>> RemoveModelAsync(bool isRemoveRelatedModels = false, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            return base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioModule parent, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {

            var saveView = await View.SaveModelAsync(true, _context, _transaction);

            if (saveView.IsSucceed && !string.IsNullOrEmpty(FormView.Content))
            {
                saveView = await FormView.SaveModelAsync(true, _context, _transaction);
            }
            if (saveView.IsSucceed && !string.IsNullOrEmpty(EdmView.Content))
            {
                saveView = await EdmView.SaveModelAsync(true, _context, _transaction);
            }

            return new RepositoryResponse<bool>()
            {
                IsSucceed = saveView.IsSucceed,
                Data = saveView.IsSucceed,
                Exception = saveView.Exception,
                Errors = saveView.Errors
            };
            
        }

        #endregion Async



        #endregion Overrides

        #region Expand
        
        public void LoadData(int? articleId = null, int? productId= null, int? categoryId = null
            , int? pageSize = null, int? pageIndex = 0
            , SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<PaginationModel<SioModuleDatas.ReadViewModel>> getDataResult = new RepositoryResponse<PaginationModel<SioModuleDatas.ReadViewModel>>();

            switch (Type)
            {
                case SioModuleType.Content:
                    getDataResult = SioModuleDatas.ReadViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SioModuleType.SubPage:
                    getDataResult = SioModuleDatas.ReadViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.CategoryId == categoryId)
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;

                case SioModuleType.SubArticle:
                    getDataResult = SioModuleDatas.ReadViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.ArticleId == articleId)
                       , "Priority", 0, pageSize, pageIndex
                       , _context, _transaction);
                    break;
                case SioModuleType.SubProduct:
                    getDataResult = SioModuleDatas.ReadViewModel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.ProductId == productId)
                       , "Priority", 0, pageSize, pageIndex
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
