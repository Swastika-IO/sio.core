using System.Collections.Generic;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib;
using Swastika.IO.Domain.Core.ViewModels;
using Newtonsoft.Json.Linq;
using Swastika.IO.Common.Helper;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.Repositories;
using Microsoft.Data.OData.Query;
using System;
using static Swastika.Cms.Lib.SWCmsConstants;
using Swastika.Cms.Lib.Services;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
    public class FEModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocModule, FEModuleViewModel>
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
        public ModuleType Type { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }
        #endregion

        #region Views

        [JsonProperty("view")]
        public TemplateViewModel View { get; set; }
        [JsonProperty("data")]
        public PaginationModel<InfoModuleDataViewModel> Data { get; set; } = new PaginationModel<InfoModuleDataViewModel>();
        [JsonProperty("columns")]
        public List<ModuleFieldViewModel> Columns { get; set; }
        [JsonProperty("templates")]
        public List<TemplateViewModel> Templates { get; set; }
        [JsonProperty("articles")]
        public PaginationModel<InfoArticleViewModel> Articles { get; set; } = new PaginationModel<InfoArticleViewModel>();
        public string TemplatePath
        {
            get
            {
                return string.Format("../{0}", Template);
                //return SWCmsHelper.GetFullPath(new string[]
                //{
                //    ""
                //    , SWCmsConstants.Parameters.TemplatesFolder
                //    , ApplicationConfigService.Instance.GetLocalString(SWCmsConstants.ConfigurationKeyword.Theme, Specificulture, SWCmsConstants.Default.DefaultTemplateFolder)
                //    , Template
                //});
            }
        }
        #endregion

        #endregion

        #region Contructors

        public FEModuleViewModel() : base()
        {
        }

        public FEModuleViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
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

            this.Templates = Templates ?? TemplateRepository.Instance.GetTemplates(SWCmsConstants.TemplateFolder.Modules);

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
                , 4, 0
                , _context: _context, _transaction: _transaction
                );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }
        }

        #endregion
        #region Expand

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

        #endregion
    }

}
