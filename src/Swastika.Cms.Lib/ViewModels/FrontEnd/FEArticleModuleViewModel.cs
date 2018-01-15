using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Common.Helper;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
    public class FEArticleModuleViewModel
        : ViewModelBase<SiocCmsContext, SiocArticleModule, FEArticleModuleViewModel>
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
        [JsonProperty("module")]
        public FEModuleViewModel Module { get; set; }
        #endregion

        #endregion

        #region Contructors

        public FEArticleModuleViewModel() : base()
        {
        }

        public FEArticleModuleViewModel(SiocArticleModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getModuleResult = FEModuleViewModel.Repository.GetSingleModel(m => m.Id == ModuleId && m.Specificulture == Specificulture);
            if (getModuleResult.IsSucceed)
            {
                this.Module = getModuleResult.Data;
            }
        }
        #endregion

        #region Expands

        #endregion

    }
}
