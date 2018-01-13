using System.Collections.Generic;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Domain.Core.ViewModels;
using Newtonsoft.Json.Linq;
using Swastika.Common.Helper;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.Repositories;
using Microsoft.Data.OData.Query;
using System.Linq;
using Swastika.Domain.Core.Models;
using System.Threading.Tasks;
using Swastika.Cms.Lib.Services;
using System;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocModule, BEModuleViewModel>
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
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("fields")]
        public string Fields { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }
        #endregion

        #region Views


        [JsonProperty("data")]
        public PaginationModel<InfoModuleDataViewModel> Data { get; set; } = new PaginationModel<InfoModuleDataViewModel>();
        [JsonProperty("columns")]
        public List<ModuleFieldViewModel> Columns { get; set; }

        [JsonProperty("articles")]
        public PaginationModel<InfoArticleViewModel> Articles { get; set; } = new PaginationModel<InfoArticleViewModel>();

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
        public string TemplateFolderType { get { return SWCmsConstants.TemplateFolderEnum.Modules.ToString(); } }
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
        //Parent Article Id
        public string  ArticleId { get; set; }
        //Parent Category Id
        public int CategoryId { get; set; }
        #endregion

        #endregion

        #region Contructors

        public BEModuleViewModel() : base()
        {
        }

        public BEModuleViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override SiocModule ParseModel()
        {
            if (Id == 0)
            {
                Id = InfoModuleViewModel.Repository.Count().Data + 1;
            }
            Template = View != null ? string.Format(@"{0}/{1}{2}", View.FolderType, View.FileName, View.Extension) : Template;
            var arrField = Columns != null ? JArray.Parse(
                Newtonsoft.Json.JsonConvert.SerializeObject(Columns.Where(
                    c => !string.IsNullOrEmpty(c.Name)))) : new JArray();
            Fields = arrField.ToString(Newtonsoft.Json.Formatting.None);



            return base.ParseModel();
        }


        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = GlobalConfigurationService.ListSupportedCulture;
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
                    Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                    DataType = (SWCmsConstants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
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
            this.Template = SWCmsHelper.GetFullPath(new string[]
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
        }


        #region Async
        public override Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            return base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
        }

        public override async Task<RepositoryResponse<bool>> CloneSubModelsAsync(BEModuleViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            foreach (var data in parent.Data.Items)
            {
                var cloneData = await data.CloneAsync(cloneCultures, _context, _transaction);
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
        #endregion

        #region Sync
        public override RepositoryResponse<bool> CloneSubModels(BEModuleViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            foreach (var data in parent.Data.Items)
            {
                var cloneData = data.Clone(cloneCultures, _context, _transaction);
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
        #endregion


        #endregion

        #region Expands

        #endregion
    }

}
