using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models;
using Swastika.Common;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swastika.Domain.Core.Models;
using Swastika.IO.Cms.Lib.Models;

namespace Swastika.Cms.Lib.ViewModels
{
    public class FEModuleContentData : ViewModelBase<SiocCmsContext, SiocModuleData, FEModuleContentData>
    {
        public FEModuleContentData(SiocModuleData model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        public string Id { get; set; }
        public int ModuleId { get; set; }
        public string Specificulture { get; set; }
        public string Fields { get; set; }
        public string Value { get; set; }
        public string ArticleId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Priority { get; set; }
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
            JObject result = new JObject();
            result.Add(new JProperty("id", Id));
            foreach (var prop in DataProperties)
            {
                result.Add(new JProperty(Common.CommonHelper.ParseJsonPropertyName(prop.Name), prop.Value));
            }
            JObject model = new JObject();
            model.Add(new JProperty("id", Id));
            model.Add(new JProperty("moduleId", ModuleId));
            model.Add(new JProperty("specificulture", Specificulture));
            model.Add(new JProperty("fields", Fields));
            model.Add(new JProperty("value", Value));
            model.Add(new JProperty("articleId", ArticleId));
            model.Add(new JProperty("priority", Priority));
            model.Add(new JProperty("categoryId", CategoryId));
            model.Add(new JProperty("createdDateTime", CreatedDateTime));
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

        public override FEModuleContentData ParseView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(_context, _transaction);

            var objValue = Value != null ? JObject.Parse(Value) : new JObject();

            vm.DataProperties = new List<ModuleDataValueViewModel>();
            //Columns = new List<ModuleFieldViewModel>(); // ModuleRepository.GetInstance().GetColumns(m => m.Id == ModuleId && m.Specificulture == Specificulture);

            vm.Columns = new List<ModuleFieldViewModel>();

            JArray arrField = JArray.Parse(Fields);
            foreach (var field in arrField)
            {
                ModuleFieldViewModel vmField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                    DataType = (Constants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                };
                vm.Columns.Add(vmField);
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
                    DataType = (Constants.DataType)col.DataType,
                    Name = CommonHelper.ParseJsonPropertyName(prop.Name),
                    StringValue = prop.Value["value"].Value<string>()
                };
                switch (col.DataType)
                {
                    case Constants.DataType.Int:
                        dataVal.Value = prop.Value["value"] != null ? prop.Value["value"].Value<int>() : 0;
                        break;

                    case Constants.DataType.Boolean:
                        dataVal.Value = !string.IsNullOrEmpty(prop.Value["value"].ToString()) ? prop.Value["value"].Value<bool>() : false;
                        break;
                    case Constants.DataType.String:
                    case Constants.DataType.Image:
                    case Constants.DataType.Icon:
                    case Constants.DataType.CodeEditor:
                    case Constants.DataType.Html:
                    case Constants.DataType.TextArea:
                    default:
                        dataVal.Value = prop.Value["value"].Value<string>();
                        break;
                }
                vm.DataProperties.Add(dataVal);
                //}
            }



            return vm;
        }

       
        #endregion
    }

    public class ModuleDataValueViewModel
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public Constants.DataType DataType { get; set; }
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
        public Constants.DataType DataType { get; set; }
        public bool IsDisplay { get; set; }
        public int Width { get; set; }
    }
}
