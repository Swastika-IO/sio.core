using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Common.Helper;
using Swastika.IO.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using System.Threading.Tasks;
using Swastika.Cms.Lib.ViewModels.FrontEnd;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEPositionViewModel
        : ViewModelBase<SiocCmsContext, SiocPosition, BEPositionViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        #endregion

        #region Views
       
        #endregion

        #endregion

        #region Contructors

        public BEPositionViewModel() : base()
        {
        }

        public BEPositionViewModel(SiocPosition model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion
    }
}
