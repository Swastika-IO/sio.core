using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmCategoryViewModel
        : ViewModelBase<SwastikaCrmContext, CrmCategory, FECrmCategoryViewModel>
    {
        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        #region Models

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmCategoryViewModel() : base()
        {
        }

        public FECrmCategoryViewModel(CrmCategory model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
