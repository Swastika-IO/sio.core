using Swastika.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Domain.Core.Models;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ArticleModuleListItemViewModel : ViewModelBase<SiocCmsContext, SiocArticleModule, ArticleModuleListItemViewModel>
    {
        public string ArticleId { get; set; }
        public int ModuleId { get; set; } // ModuleId
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
        public int ModuleId { get; set; } // Module Id
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

            var getModuleResult = ModuleWithDataViewModel.Repository.GetSingleModel(m => m.Id == ModuleId && m.Specificulture == Specificulture);
            if (getModuleResult.IsSucceed)
            {
                vm.Module = getModuleResult.Data;
            }

            return vm;
        }
        #region Async
        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocArticleModule parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            bool result = true;
            foreach (var data in Module.Data.Items)
            {
                data.ArticleId = ArticleId;
                data.ModuleId = ModuleId;
                result = result && (await data.SaveModelAsync(false, _context, _transaction)).IsSucceed;
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result,
                Data = result
            };

        }
        #endregion
        #endregion

    }
}
