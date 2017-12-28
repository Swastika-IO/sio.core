using System;
using System.Collections.Generic;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Cms.Lib;
using Newtonsoft.Json.Linq;
using Swastika.IO.Common.Helper;
using System.Linq;
using Swastika.Cms.Lib.ViewModels;

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
            return base.ParseModel();
        }

        #endregion


        #region Expands

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
