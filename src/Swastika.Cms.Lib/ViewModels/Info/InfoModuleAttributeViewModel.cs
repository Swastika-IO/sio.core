// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoModuleAttributeViewModel
        : ViewModelBase<SiocCmsContext, SiocModuleAttributeValue, InfoModuleAttributeViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dataType")]
        public int DataType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        #endregion Models

        #endregion Properties

        #region Contructors

        public InfoModuleAttributeViewModel() : base()
        {
        }

        public InfoModuleAttributeViewModel(SiocModuleAttributeValue model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors
    }
}