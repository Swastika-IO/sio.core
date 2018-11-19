using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.ViewModels.SioComments
{
    public class ReadViewModel: ViewModelBase<SioCmsContext, SioComment, ReadViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("customerId")]
        public string CreatedBy { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("rating")]
        public double Rating { get; set; }

        #endregion Models

        #region Views


        #endregion Views

        #endregion Properties

        #region Contructors

        public ReadViewModel() : base()
        {
        }

        public ReadViewModel(SioComment model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors
    }
}
