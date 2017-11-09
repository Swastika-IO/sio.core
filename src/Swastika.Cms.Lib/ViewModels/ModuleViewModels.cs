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
using Swastika.Domain.Core.Models;
using System.Linq;
using System.Threading.Tasks;
using static Swastika.IO.Cms.Lib.SWCmsConstants;
using Swastika.IO.Cms.Lib.Models;

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

        public ModuleType Type { get; set; }


        // View
        public TemplateViewModel View { get; set; }
        public PaginationModel<ModuleContentViewmodel> Data { get; set; }
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

            vm.Templates = Templates ?? TemplateRepository.Instance.GetTemplates(Constants.TemplateFolder.Modules);
            vm.Columns = new List<ModuleFieldViewModel>();
            JArray arrField = !string.IsNullOrEmpty(Fields) ? JArray.Parse(Fields) : new JArray();
            foreach (var field in arrField)
            {
                ModuleFieldViewModel vmField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                    DataType = (Constants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                };
                Columns.Add(vmField);
            }

            //if (Type == ModuleType.Root)
            //{
            //    var getDataResult = FEModuleContentData.Repository
            //      .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
            //      , "Priority", OrderByDirection.Ascending, null, null
            //      , _context, _transaction);
            //    if (getDataResult.IsSucceed)
            //    {
            //        getDataResult.Data.JsonItems = new List<JObject>();
            //        getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
            //        vm.Data = getDataResult.Data;
            //    }
            //}
            return vm;
        }



        #endregion
        #region Expand

        public void LoadData(string articleId = null, int? categoryId = null
            , int? pageSize = null, int? pageIndex = 0
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {

            RepositoryResponse<PaginationModel<ModuleContentViewmodel>> getDataResult = new RepositoryResponse<PaginationModel<ModuleContentViewmodel>>();

            switch (Type)
            {
                case ModuleType.Root:
                    getDataResult = ModuleContentViewmodel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;
                case ModuleType.SubPage:
                    getDataResult = ModuleContentViewmodel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.CategoryId == categoryId)
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;
                case ModuleType.SubArticle:
                    getDataResult = ModuleContentViewmodel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.ArticleId == articleId)
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;
                default:
                    break;
            }

            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }
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

        public string DetailsUrl { get; set; }
        public string EditUrl { get; set; }

        public ModuleListItemViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
    }

    #region Module Backend ViewModel

    public class ModuleBEViewModel : ViewModelBase<SiocCmsContext, SiocModule, ModuleBEViewModel>
    {

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }


        public List<CultureViewModel> ListSupportedCulture { get; set; }
        public TemplateViewModel View { get; set; }
        public List<TemplateViewModel> Templates { get; set; }
        public List<ModuleFieldViewModel> Columns { get; set; }

        public ModuleBEViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
        #region Overrides

        #region Common

        public override ModuleBEViewModel ParseView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(_context, _transaction);

            //Get Languages
            vm.Templates = Templates ?? TemplateRepository.Instance.GetTemplates(Constants.TemplateFolder.Modules);
            vm.Template = string.IsNullOrEmpty(Template) ? "Modules/_Default" : Template;
            vm.View = TemplateRepository.Instance.GetTemplate(Template, Templates, Constants.TemplateFolder.Modules);

            var getCulture = CultureViewModel.Repository.GetModelList(_context, _transaction);
            if (getCulture.IsSucceed)
            {
                getCulture.Data.ForEach(c =>
                c.IsSupported = ModuleBEViewModel.Repository.CheckIsExists(
                    a => a.Id == vm.Id && a.Specificulture == c.Specificulture));

                vm.ListSupportedCulture = getCulture.Data;
            }


            //Get columns
            vm.Columns = new List<ModuleFieldViewModel>();

            JArray arrField = JArray.Parse(Fields);
            foreach (var field in arrField)
            {
                ModuleFieldViewModel vmField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                    DataType = (Constants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                };
                vm.Columns.Add(vmField);
            }

            return vm;
        }

        public override SiocModule ParseModel()
        {
            var arrField = Columns != null ? JArray.Parse(
                Newtonsoft.Json.JsonConvert.SerializeObject(Columns.Where(
                    c => !string.IsNullOrEmpty(c.Name)))) : new JArray();
            Fields = arrField.ToString(Newtonsoft.Json.Formatting.None);
            Template = View != null ? string.Format(@"{0}/{1}", View.FileFolder, View.Filename) : string.Empty;

            return base.ParseModel();
        }

        #endregion

        #region Async

        public override async Task<RepositoryResponse<ModuleBEViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);

            if (result.IsSucceed)
            {
                TemplateRepository.Instance.SaveTemplate(View);
                foreach (var supportedCulture in ListSupportedCulture.Where(c => c.Specificulture != Specificulture))
                {

                    var cloneModule = await ModuleBEViewModel.Repository.GetSingleModelAsync(
                        b => b.Id == Id && b.Specificulture == supportedCulture.Specificulture);
                    if (cloneModule.Data == null && supportedCulture.IsSupported)
                    {
                        var cloneResult = this.Clone(supportedCulture.Specificulture);
                    }
                    else if (cloneModule.Data != null && !supportedCulture.IsSupported)
                    {
                        await ModuleBEViewModel.Repository.RemoveModelAsync(
                            b => b.Id == cloneModule.Data.Id && b.Specificulture == supportedCulture.Specificulture);
                    }
                }
            }

            return result;
        }

        #endregion

        #region Sync

        public override RepositoryResponse<ModuleBEViewModel> SaveModel(bool isSaveSubModels = false,
            SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.SaveModel(isSaveSubModels, _context, _transaction);

            if (result.IsSucceed)
            {
                TemplateRepository.Instance.SaveTemplate(View);
                foreach (var supportedCulture in ListSupportedCulture.Where(c =>
                c.Specificulture != Specificulture))
                {

                    var cloneModule = ModuleBEViewModel.Repository.GetSingleModel(
                        b => b.Id == Id && b.Specificulture == supportedCulture.Specificulture);
                    if (cloneModule.Data == null && supportedCulture.IsSupported)
                    {
                        var cloneResult = this.Clone(supportedCulture.Specificulture);
                    }
                    else if (cloneModule.Data != null && !supportedCulture.IsSupported)
                    {
                        ModuleBEViewModel.Repository.RemoveModel(
                            b => b.Id == cloneModule.Data.Id
                            && b.Specificulture == supportedCulture.Specificulture);
                    }
                }
            }

            return result;
        }

        #endregion

        #endregion

        #region Expands
        public RepositoryResponse<ModuleBEViewModel> Clone(string culture)
        {
            var cloneModel = new ModuleBEViewModel(this.Model)
            {
                Id = Id,
                Specificulture = culture,
                //Categories = new List<CategoryModuleViewModel>(),
                //Data = new PaginationModel<ModuleDataViewModel>()
            };
            //foreach (var cateModule in this.Categories.Where(p => p.IsActived))
            //{
            //    cloneModel.Categories.Add(new CategoryModuleViewModel()
            //    {
            //        ModuleId = cateModule.ModuleId,
            //        Specificulture = culture,
            //        CategoryId = cateModule.CategoryId,
            //        IsActived = cateModule.IsActived,
            //        Description = cateModule.Description
            //    });
            //}

            //Clone Data 
            //Data = ModuleDataRepository.GetInstance().GetModelListBy(d => d.ModuleId == Id && d.Specificulture == Specificulture, d => d.CreatedDate, "desc", 0, null, Constants.ViewModelType.BackEnd);
            //foreach (var data in Data.Items)
            //{

            //    ModuleDataViewModel cloneData = data;
            //    cloneData.Id = Guid.NewGuid().ToString();
            //    cloneData.Specificulture = culture;

            //    cloneModel.Data.Items.Add(cloneData);
            //}
            return ModuleBEViewModel.Repository.SaveModel(cloneModel, true);
        }
        #endregion
    }

    #endregion
}
