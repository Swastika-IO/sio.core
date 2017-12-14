using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using Swastika.IO.Cms.Lib.Models;
using Swastika.Common;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.IO.Cms.Lib.Services;

namespace Swastika.IO.Cms.Lib.ViewModels
{
    public class ModuleContentViewmodel : ViewModelBase<SiocCmsContext, SiocModuleData, ModuleContentViewmodel>
    {
        public ModuleContentViewmodel(SiocModuleData model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        public string Id { get; set; }
        public int ModuleId { get; set; }
        //public string Specificulture { get; set; }
        public string Fields { get; set; } = "[]";
        public string Value { get; set; }
        public string ArticleId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        //View
        public List<ModuleDataValueViewModel> DataProperties { get; set; }
        public List<ModuleFieldViewModel> Columns { get; set; }
        public JObject JItem { get { return ParseJson(); } }

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
                result.Add(new JProperty(Common.CommonHelper.ParseJsonPropertyName(prop.Name), prop.Value));
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


        public override SiocModuleData ParseModel()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel();
        }
        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = ApplicationConfigService.ListSupportedCulture;

            var objValue = Value != null ? JObject.Parse(Value) : new JObject();

            this.DataProperties = new List<ModuleDataValueViewModel>();
            //Columns = new List<ModuleFieldViewModel>(); // ModuleRepository.GetInstance().GetColumns(m => m.Id == ModuleId && m.Specificulture == Specificulture);

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
                        dataVal.Value = prop.Value["value"] != null ? prop.Value["value"].Value<int>() : 0;
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

    public class ModuleFieldViewModel
    {
        public string Name { get; set; }
        public SWCmsConstants.DataType DataType { get; set; }
        public bool IsDisplay { get; set; }
        public int Width { get; set; }
    }
}
