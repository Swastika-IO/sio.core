// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Common.Helper;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiModuleDataViewModel
       : ViewModelBase<SiocCmsContext, SiocModuleData, ApiModuleDataViewModel>
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
        [JsonIgnore]
        public string Value { get; set; }

        [JsonProperty("articleId")]
        public string ArticleId { get; set; }
        [JsonProperty("productId")]
        public string ProductId { get; set; }
        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("updatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }

        #endregion Models

        #region Views

        public List<ModuleDataValueViewModel> DataProperties { get; set; }
        public List<ModuleFieldViewModel> Columns { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public ApiModuleDataViewModel() : base()
        {
        }

        public ApiModuleDataViewModel(SiocModuleData model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override SiocModuleData ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
                CreatedDateTime = DateTime.UtcNow;
            }
            else
            {
                UpdatedDateTime = DateTime.UtcNow;
            }
            Value = ParseObjectValue();
            return base.ParseModel(_context, _transaction);
        }
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            ListSupportedCulture = GlobalConfigurationService.Instance.CmsCulture.ListSupportedCulture;

            var objValue = Value != null ? JObject.Parse(Value) : new JObject();
            this.DataProperties = new List<ModuleDataValueViewModel>();
            Fields = InfoModuleViewModel.Repository.GetSingleModel(m => m.Id == ModuleId && m.Specificulture == Specificulture, _context, _transaction).Data?.Fields;
            this.Columns = new List<ModuleFieldViewModel>();
            if (!string.IsNullOrEmpty(Fields))
            {
                JArray arrField = JArray.Parse(Fields);

                foreach (var field in arrField)
                {
                    ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                    {
                        Name = CommonHelper.ParseJsonPropertyName(field["name"].ToString()),
                        
                        Priority = field["priority"] != null ? field["priority"].Value<int>() : 0,
                        DataType = (SWCmsConstants.DataType)(int)field["dataType"],
                        Width = field["width"] != null ? field["width"].Value<int>() : 3,
                        Options = field["options"] != null ? field["options"].Value<JArray>() : new JArray(),
                        IsSelect = field["isSelect"] != null ? field["isSelect"].Value<bool>() : false,
                        IsGroupBy = field["isGroupBy"] != null ? field["isGroupBy"].Value<bool>() : false,
                        IsDisplay = field["isDisplay"] != null ? field["isDisplay"].Value<bool>() : true
                    };
                    this.Columns.Add(thisField);
                }
            }
            foreach (var col in Columns)
            {
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
                var dataVal = new ModuleDataValueViewModel()
                {
                    ModuleId = ModuleId,
                    DataType = (SWCmsConstants.DataType)col.DataType,
                    Name = CommonHelper.ParseJsonPropertyName(prop.Name),
                    IsSelect = col.IsSelect,
                    IsGroupBy = col.IsGroupBy,
                    Options = col.Options,
                    Value = prop.Value["value"].Value<string>()
                };
                
                this.DataProperties.Add(dataVal);
            }
        }

        #endregion Overrides

        #region Expands

        public string ParseObjectValue()
        {
            JObject result = new JObject();
            foreach (var prop in DataProperties)
            {
                JObject obj = new JObject();
                obj.Add(new JProperty("dataType", prop.DataType));
                obj.Add(new JProperty("value", prop.Value));
                result.Add(new JProperty(CommonHelper.ParseJsonPropertyName(prop.Name), obj));
            }
            return result.ToString(Formatting.None);
        }

        public string GetStringValue(string name)
        {
            var prop = DataProperties.FirstOrDefault(p => p.Name == name);
            return prop != null && prop.Value != null ? prop.Value.ToString() : string.Empty;
        }

        public ModuleDataValueViewModel GetDataProperty(string name)
        {
            return DataProperties.FirstOrDefault(p => p.Name == name);
        }

        #endregion Expands
    }

    public class ModuleDataValueViewModel
    {
        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("isSelect")]
        public bool IsSelect { get; set; }
        [JsonProperty("isGroupBy")]
        public bool IsGroupBy { get; set; }
        [JsonProperty("options")]
        public JArray Options { get; set; } = new JArray();
    }
}
