using Swastika.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ArticleModuleListItemViewModel : ViewModelBase<SiocCmsContext, SiocArticleModule, ArticleModuleListItemViewModel>
    {
        public string ArticleId { get; set; }
        [JsonProperty("moduleId")]
        public int Id { get; set; } // ModuleId
        public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }


        
        public ArticleModuleListItemViewModel(SiocArticleModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        
    }

    public class ArticleModuleFEViewModel : ViewModelBase<SiocCmsContext, SiocArticleModule, ArticleModuleFEViewModel>
    {
        public string ArticleId { get; set; }
        public int Id { get; set; } // Module Id
        public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }

        public ModuleWithDataViewModel Module { get; set; }
       
        public ArticleModuleFEViewModel(SiocArticleModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #region Overrides

        public override ArticleModuleFEViewModel ParseView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(_context, _transaction);

            var getModuleResult = ModuleWithDataViewModel.Repository.GetSingleModel(m => m.Id == Id && m.Specificulture == Specificulture);
            if (getModuleResult.IsSucceed)
            {
                vm.Module = getModuleResult.Data;
            }

            return vm;
        }

        #endregion

    }
}
