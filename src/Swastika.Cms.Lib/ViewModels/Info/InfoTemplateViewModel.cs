using System;
using System.Collections.Generic;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Cms.Lib;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoTemplateViewModel
       : ViewModelBase<SiocCmsContext, SiocTemplate, InfoTemplateViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public InfoTemplateViewModel() 
            : base()
        {
        }

        public InfoTemplateViewModel(SiocTemplate model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override SiocTemplate ParseModel()
        {
            if (Id==0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel();
        }

        #endregion
    }
}
