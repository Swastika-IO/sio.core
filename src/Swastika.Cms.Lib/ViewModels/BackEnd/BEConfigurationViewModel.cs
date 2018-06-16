// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEConfigurationViewModel
        : ViewModelBase<SiocCmsContext, SiocConfiguration, BEConfigurationViewModel>
    {
        #region Properties

        #region Models

        [Required]
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }

        [JsonProperty("property")]
        public DataValueViewModel Property { get; set; }
        #endregion Views

        #endregion Properties

        #region Contructors

        public BEConfigurationViewModel() : base()
        {
        }

        public BEConfigurationViewModel(SiocConfiguration model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override SiocConfiguration ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Value = Property.Value;
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = false;
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported = true);
            Property = new DataValueViewModel() { DataType = DataType, Value = Value, Name = Keyword };
        }

        #endregion Overrides
    }
    public class DataValueViewModel
    {
        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}