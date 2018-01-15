using System;
using System.Collections.Generic;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Cms.Lib;
using Newtonsoft.Json.Linq;
using Swastika.Common.Helper;
using System.Linq;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.Repositories;
using System.Threading.Tasks;
using Swastika.Cms.Lib.ViewModels.FrontEnd;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoModuleDataViewModel
       : ViewModelBase<SiocCmsContext, SiocModuleData, InfoModuleDataViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }
        [JsonProperty("fields")]
        public string Fields { get; set; } = "[]";
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }
        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("updatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }

        #endregion

        #region Views
        public List<ModuleDataValueViewModel> DataProperties { get; set; }
        public List<ModuleFieldViewModel> Columns { get; set; }
        public JObject JItem { get { return ParseJson(); } }
        #endregion

        #endregion

        #region Contructors

        public InfoModuleDataViewModel() : base()
        {
        }

        public InfoModuleDataViewModel(SiocModuleData model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override SiocModuleData ParseModel()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
                CreatedDateTime = DateTime.UtcNow;
            }
            Value = ParseObjectValue();
            return base.ParseModel();
        }
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = GlobalConfigurationService.ListSupportedCulture;

            var objValue = Value != null ? JObject.Parse(Value) : new JObject();

            this.DataProperties = new List<ModuleDataValueViewModel>();
            //Columns = new List<ModuleFieldViewModel>(); // ModuleRepository.GetInstance().GetColumns(m => m.Id == ModuleId && m.Specificulture == Specificulture);
            Fields = InfoModuleViewModel.Repository.GetSingleModel(m => m.Id == ModuleId && m.Specificulture == Specificulture, _context, _transaction).Data.Fields;
            this.Columns = new List<ModuleFieldViewModel>();
            if (!string.IsNullOrEmpty(Fields))
            {
                JArray arrField = JArray.Parse(Fields);

                foreach (var field in arrField)
                {
                    ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                    {
                        Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                        DataType = (SWCmsConstants.DataType)(int)field["DataType"],
                        Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                        IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                    };
                    this.Columns.Add(thisField);
                }
            }
            foreach (var col in Columns)
            {
                //    foreach (var field in objValue.Properties())
                //{
                JProperty prop = objValue.Property(col.Name);
                if (prop == null)
                {
                    JObject val = new JObject
                    {
                        { "dataType", (int)col.DataType },
                        { "value", null }
                    };
                    prop = new JProperty(col.Name, val);
                }
                //foreach (var prop in objValue.Properties())
                //{               
                var dataVal = new ModuleDataValueViewModel()
                {
                    ModuleId = ModuleId,
                    DataType = (SWCmsConstants.DataType)col.DataType,
                    Name = CommonHelper.ParseJsonPropertyName(prop.Name),
                    StringValue = prop.Value["value"].Value<string>()
                };
                switch (col.DataType)
                {
                    case SWCmsConstants.DataType.Int:
                        dataVal.Value = prop.Value["value"].HasValues ? prop.Value["value"].Value<int>() : 0;
                        break;

                    case SWCmsConstants.DataType.Boolean:
                        dataVal.Value = !string.IsNullOrEmpty(prop.Value["value"].ToString()) ? prop.Value["value"].Value<bool>() : false;
                        break;
                    case SWCmsConstants.DataType.String:
                    case SWCmsConstants.DataType.Image:
                    case SWCmsConstants.DataType.Icon:
                    case SWCmsConstants.DataType.CodeEditor:
                    case SWCmsConstants.DataType.Html:
                    case SWCmsConstants.DataType.TextArea:
                    default:
                        dataVal.Value = prop.Value["value"].Value<string>();
                        break;
                }
                this.DataProperties.Add(dataVal);
                //}
            }
        }

        #region Sync

        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                foreach (var prop in DataProperties)
                {
                    if (prop.DataType == SWCmsConstants.DataType.Image)
                    {
                        FileRepository.Instance.DeleteWebFile(prop.StringValue);
                    }
                }
            }
            return result;
        }

        #endregion

        #region ASync

        public override async Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
           
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                foreach (var prop in DataProperties)
                {
                    if (prop.DataType == SWCmsConstants.DataType.Image)
                    {
                        FileRepository.Instance.DeleteWebFile(prop.StringValue);
                    }
                }
            }
            return result;
        }
        #endregion
        #endregion


        #region Expands
        public string ParseObjectValue()
        {
            JObject result = new JObject();
            foreach (var prop in DataProperties)
            {
                
                JObject obj = new JObject();
                obj.Add(new JProperty("dataType", prop.DataType));
                obj.Add(new JProperty("value", prop.StringValue));
                result.Add(new JProperty(CommonHelper.ParseJsonPropertyName(prop.Name), obj));
            }
            return result.ToString(Formatting.None);
        }

        public string GetStringValue(string name)
        {
            var prop = DataProperties.FirstOrDefault(p => p.Name == name);
            return prop != null && prop.Value != null ? prop.Value.ToString() : string.Empty;
        }

        public T GetValue<T>(string name) where T : IConvertible
        {
            var prop = DataProperties.FirstOrDefault(p => p.Name == name);
            return prop != null && prop.Value != null ? (T)prop.Value : default(T);
        }

        public ModuleDataValueViewModel GetDataProperty(string name)
        {
            return DataProperties.FirstOrDefault(p => p.Name == name);
        }

        public JObject ParseJson()
        {
            JObject result = new JObject
            {
                new JProperty("id", Id)
            };
            foreach (var prop in DataProperties)
            {
                result.Add(new JProperty(CommonHelper.ParseJsonPropertyName(prop.Name), prop.Value));
            }
            JObject model = new JObject
            {
                new JProperty("id", Id),
                new JProperty("moduleId", ModuleId),
                new JProperty("specificulture", Specificulture),
                new JProperty("fields", Fields),
                new JProperty("value", Value),
                new JProperty("articleId", ArticleId),
                new JProperty("priority", Priority),
                new JProperty("categoryId", CategoryId),
                new JProperty("createdDateTime", CreatedDateTime)
            };
            result.Add(new JProperty("model", model));
            return result;

        }


        #endregion

    }

    public class ModuleDataValueViewModel
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public SWCmsConstants.DataType DataType { get; set; }
        public IConvertible Value { get; set; }

        public string StringValue { get; set; }

        public T GetValue<T>()
        {
            return this.Value != null ? (T)Value : default(T);
        }

    }
    
}
