using System.Collections.Generic;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Domain.Core.ViewModels;
using Newtonsoft.Json.Linq;
using Swastika.IO.Common.Helper;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.Repositories;
using Microsoft.Data.OData.Query;
using System.Linq;
using Swastika.Domain.Core.Models;
using System.Threading.Tasks;

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
        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , SWCmsConstants.TemplateFolder.Modules.ToString()
                }
            );
            }
        }
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
            if (Id==0)
            {
                Id = InfoModuleViewModel.Repository.Count().Data + 1;
            }
            var arrField = Columns != null ? JArray.Parse(
                Newtonsoft.Json.JsonConvert.SerializeObject(Columns.Where(
                    c => !string.IsNullOrEmpty(c.Name)))) : new JArray();
            Fields = arrField.ToString(Newtonsoft.Json.Formatting.None);
            Template = View != null ? string.Format(@"{0}/{1}", View.FileFolder, View.Filename) : Template;

            return base.ParseModel();
        }


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

            //Get Languages
            this.Templates = Templates ?? TemplateRepository.Instance.GetTemplates(
                this.TemplateFolder);
            this.View = TemplateRepository.Instance.GetTemplate(Template, Templates, SWCmsConstants.TemplateFolder.Modules);
            if (this.View == null)
            {
                this.View = new TemplateViewModel()
                {
                    Extension = SWCmsConstants.Parameters.TemplateExtension,
                    FileFolder = this.TemplateFolder,
                    Filename = SWCmsConstants.Default.DefaultTemplate,
                    Content = "<div></div>"
                };
                this.Template = SWCmsHelper.GetFullPath(new string[]
                {
                    this.View?.FileFolder
                    , this.View?.Filename
                });
            }
            Template = View != null ? string.Format(@"{0}/{1}{2}", View.FileFolder, View.Filename, View.Extension) : Template;

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
        #endregion


        #endregion
    }

}
