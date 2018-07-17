// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Common.Helper;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.ViewModels.Spa
{
    public class SpaModuleDataViewModel
       : ViewModelBase<SiocCmsContext, SiocModuleData, SpaModuleDataViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonIgnore]
        public string Value { get; set; }

        #endregion Models

        #region Views

        public List<ModuleDataValueViewModel> DataProperties { get; set; }
        public List<ModuleFieldViewModel> Columns { get; set; }
        public JObject JItem { get { return ParseJson(); } }

        #endregion Views

        #endregion Properties

        #region Contructors

        public SpaModuleDataViewModel() : base()
        {
        }

        public SpaModuleDataViewModel(SiocModuleData model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            ListSupportedCulture = CommonRepository.Instance.LoadCultures(Specificulture, _context, _transaction);

            this.DataProperties = new List<ModuleDataValueViewModel>();
            
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
            return result;
        }

        #endregion Expands
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
