using System;
using System.Collections.Generic;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Cms.Lib;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoArticleModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocArticleModule, InfoArticleModuleViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }
        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        #endregion

        #region Views
       
        #endregion

        #endregion

        #region Contructors

        public InfoArticleModuleViewModel() : base()
        {
        }

        public InfoArticleModuleViewModel(SiocArticleModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

    }
}
