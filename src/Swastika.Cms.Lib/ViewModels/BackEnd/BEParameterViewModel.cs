using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using System.Threading.Tasks;
using Swastika.Cms.Lib.ViewModels.FrontEnd;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEParameterViewModel
        : ViewModelBase<SiocCmsContext, SiocParameter, BEParameterViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public BEParameterViewModel() : base()
        {
        }

        public BEParameterViewModel(SiocParameter model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion
    }
}
