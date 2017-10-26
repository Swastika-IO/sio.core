using Swastika.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Common.Helper;
using Swastika.Cms.Lib.Repositories;
using Newtonsoft.Json.Linq;
using Swastika.Common;
using Microsoft.Data.OData.Query;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ModuleWithDataViewModel : ViewModelBase<SiocCmsContext, SiocModule, ModuleWithDataViewModel>
    {
        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }
        public string Title { get; set; }

        public string ArticleId { get; set; } // Article this module belong to
        public int? CategoryId { get; set; }// Category this module belong to

        // View
        public TemplateViewModel View { get; set; }
        public PaginationModel<FEModuleContentData> Data { get; set; }        
        public List<ModuleFieldViewModel> Columns { get; set; }
        public List<TemplateViewModel> Templates { get; set; }
        public int Priority { get; set; }

        public ModuleWithDataViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #region Overrides

        public override ModuleWithDataViewModel ParseView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(_context, _transaction);

            vm.Templates = Templates ?? TemplateRepository.GetInstance().GetTemplates(Constants.TemplateFolder.Modules);
            vm.Columns = new List<ModuleFieldViewModel>();
            JArray arrField = !string.IsNullOrEmpty(Fields) ? JArray.Parse(Fields) : new JArray();
            foreach (var field in arrField)
            {
                ModuleFieldViewModel vmField = new ModuleFieldViewModel()
                {
                    Name = field["Name"].ToString(),
                    DataType = (Constants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                };
                Columns.Add(vmField);
            }

            var getDataResult = FEModuleContentData.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (string.IsNullOrEmpty(ArticleId) || m.ArticleId == ArticleId || string.IsNullOrEmpty(m.ArticleId))
                       && (!CategoryId.HasValue || m.CategoryId == CategoryId || !m.CategoryId.HasValue)
                       , "Priority", OrderByDirection.Ascending,null, null
                       , _context, _transaction);

            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                vm.Data = getDataResult.Data;
            }

            return vm;
        }

        #endregion
    }

    public class ModuleListItemViewModel : ViewModelBase<SiocCmsContext, SiocModule, ModuleListItemViewModel>
    {

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }

        public ModuleListItemViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
    }
}
