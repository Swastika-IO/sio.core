using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmMenuViewModel
        : ViewModelBase<SwastikaCrmContext, CrmMenu, FECrmMenuViewModel>
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("level")]
        public short Level { get; set; }
        [JsonProperty("parentId")]
        public int? ParentId { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }

        #region Models

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmMenuViewModel() : base()
        {
        }

        public FECrmMenuViewModel(CrmMenu model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
