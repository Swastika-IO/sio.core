using Swastika.IO.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.IO.Cms.Lib.Repositories;
using Newtonsoft.Json.Linq;
using Swastika.Common;
using Microsoft.Data.OData.Query;
using Swastika.Domain.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.IO.Cms.Lib.ViewModels
{
    public class ModuleWithDataViewModel : ViewModelBase<SiocCmsContext, SiocModule, ModuleWithDataViewModel>
    {
        public int Id { get; set; }
        //public string Specificulture { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }
        public string Title { get; set; }

        public string ArticleId { get; set; } // Article this module belong to
        public int? CategoryId { get; set; }// Category this module belong to

        public SWCmsConstants.ModuleType Type { get; set; }


        // View
        public TemplateViewModel View { get; set; }
        public PaginationModel<ModuleContentViewmodel> Data { get; set; } = new PaginationModel<ModuleContentViewmodel>();
        public List<ModuleFieldViewModel> Columns { get; set; }
        public List<TemplateViewModel> Templates { get; set; }
        public PaginationModel<ArticleListItemViewModel> Articles { get; set; } = new PaginationModel<ArticleListItemViewModel>();

        public ModuleWithDataViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #region Overrides
        public override ModuleWithDataViewModel ParseView(bool isExpand = true, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm  = base.ParseView(isExpand, _context, _transaction);
            vm.Columns = new List<ModuleFieldViewModel>();
            JArray arrField = !string.IsNullOrEmpty(vm.Fields) ? JArray.Parse(vm.Fields) : new JArray();
            foreach (var field  in arrField)
            {
                ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                    DataType = (SWCmsConstants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                };
                vm.Columns.Add(thisField);
            }
            return vm;
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.Templates = Templates ?? TemplateRepository.Instance.GetTemplates(SWCmsConstants.TemplateFolder.Modules);

            var getDataResult = ModuleContentViewmodel.Repository
                .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                , "Priority", OrderByDirection.Ascending, null, null
                , _context, _transaction);
            if (getDataResult.IsSucceed)
            {
                getDataResult.Data.JsonItems = new List<JObject>();
                getDataResult.Data.Items.ForEach(d => getDataResult.Data.JsonItems.Add(d.JItem));
                Data = getDataResult.Data;
            }
            var getArticles = ArticleListItemViewModel.GetModelListByModule(Id, Specificulture, SWCmsConstants.Default.OrderBy, OrderByDirection.Ascending
                , _context: _context, _transaction: _transaction
                );
            if (getArticles.IsSucceed)
            {
                Articles = getArticles.Data;
            }

        }

        public override SiocModule ParseModel()
        {
            var model = base.ParseModel();
            model.Type = (int)Type;
            return model;
        }

        public override async Task<RepositoryResponse<bool>> CloneSubModelsAsync(ModuleWithDataViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            foreach (var data in Data.Items)
            {
                
                var cloneData = await data.CloneAsync(cloneCultures, _context, _transaction);
                if (cloneData.IsSucceed)
                {
                    result.IsSucceed = cloneData.IsSucceed;
                }
                else
                {
                    result.IsSucceed = cloneData.IsSucceed;
                    result.Errors.AddRange(cloneData.Errors);
                    result.Ex = cloneData.Ex;
                }
            }
            return result;
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
                case SWCmsConstants.ModuleType.Root:
                    getDataResult = ModuleContentViewmodel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;
                case SWCmsConstants.ModuleType.SubPage:
                    getDataResult = ModuleContentViewmodel.Repository
                       .GetModelListBy(m => m.ModuleId == Id && m.Specificulture == Specificulture
                       && (m.CategoryId == categoryId)
                       , "Priority", OrderByDirection.Ascending, pageSize, pageIndex
                       , _context, _transaction);
                    break;
                case SWCmsConstants.ModuleType.SubArticle:
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
        //public string Specificulture { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }

        public string DetailsUrl { get; set; }
        public string EditUrl { get; set; }
        public SWCmsConstants.ModuleType Type { get; set; }
        public ModuleListItemViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
    }

    #region Module Backend ViewModel

    public class ModuleBEViewModel : ViewModelBase<SiocCmsContext, SiocModule, ModuleBEViewModel>
    {

        public int Id { get; set; }
        //public string Specificulture { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }

        public SWCmsConstants.ModuleType Type { get; set; }
        //public List<CultureViewModel> ListSupportedCulture { get; set; }
        public TemplateViewModel View { get; set; }
        public List<TemplateViewModel> Templates { get; set; }
        public List<ModuleFieldViewModel> Columns { get; set; }
        public PaginationModel<ModuleContentViewmodel> Data { get; set; }

        public ModuleBEViewModel(SiocModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
        #region Overrides

        #region Common
        public override ModuleBEViewModel ParseView(bool isExpand = true, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(isExpand, _context, _transaction);
            vm.Columns = new List<ModuleFieldViewModel>();
            JArray arrField = !string.IsNullOrEmpty(vm.Fields) ? JArray.Parse(vm.Fields) : new JArray();
            foreach (var field in arrField)
            {
                ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                    DataType = (SWCmsConstants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                };
                vm.Columns.Add(thisField);
            }
            if (isExpand)
            {
                ExpandView();
            }
            return vm;
        }
        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = IO.Cms.Lib.Services.ApplicationConfigService.ListSupportedCulture;

            //Get Languages
            this.Templates = Templates ?? TemplateRepository.Instance.GetTemplates(SWCmsConstants.TemplateFolder.Modules);
            this.Template = string.IsNullOrEmpty(Template) ? "Modules/_Default" : Template;
            this.View = TemplateRepository.Instance.GetTemplate(Template, Templates, SWCmsConstants.TemplateFolder.Modules);

            //Get columns
            this.Columns = new List<ModuleFieldViewModel>();

            JArray arrField = JArray.Parse(Fields ?? "[]");
            foreach (var field in arrField)
            {
                ModuleFieldViewModel thisField = new ModuleFieldViewModel()
                {
                    Name = CommonHelper.ParseJsonPropertyName(field["Name"].ToString()),
                    DataType = (SWCmsConstants.DataType)(int)field["DataType"],
                    Width = field["Width"] != null ? field["Width"].Value<int>() : 3,
                    IsDisplay = field["IsDisplay"] != null ? field["IsDisplay"].Value<bool>() : true
                };
                this.Columns.Add(thisField);
            }
            var getData = ModuleContentViewmodel.Repository.GetModelListBy(d => d.ModuleId == Id && d.Specificulture == Specificulture,"Id", OrderByDirection.Ascending, pageSize: null ,pageIndex:null, _context: _context, _transaction: _transaction);
            this.Data = getData.Data;
        }

        public override SiocModule ParseModel()
        {
            var arrField = Columns != null ? JArray.Parse(
                Newtonsoft.Json.JsonConvert.SerializeObject(Columns.Where(
                    c => !string.IsNullOrEmpty(c.Name)))) : new JArray();
            Fields = arrField.ToString(Newtonsoft.Json.Formatting.None);
            Template = View != null ? string.Format(@"{0}/{1}", View.FileFolder, View.Filename) : Template;

            return base.ParseModel();
        }

        #endregion

        #region Async

        public override async Task<RepositoryResponse<ModuleBEViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);

            //if (result.IsSucceed)
            //{
            //    TemplateRepository.Instance.SaveTemplate(View);
            //    foreach (var supportedCulture in ListSupportedCulture.Where(c => c.Specificulture != Specificulture))
            //    {

            //        var cloneModule = await ModuleBEViewModel.Repository.GetSingleModelAsync(
            //            b => b.Id == Id && b.Specificulture == supportedCulture.Specificulture);
            //        if (cloneModule.Data == null && supportedCulture.IsSupported)
            //        {
            //            var cloneResult = this.Clone(supportedCulture.Specificulture);
            //        }
            //        else if (cloneModule.Data != null && !supportedCulture.IsSupported)
            //        {
            //            await ModuleBEViewModel.Repository.RemoveModelAsync(
            //                b => b.Id == cloneModule.Data.Id && b.Specificulture == supportedCulture.Specificulture);
            //        }
            //    }
            //}

            return result;
        }

        public override async Task<RepositoryResponse<bool>> CloneSubModelsAsync(ModuleBEViewModel parent, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>() { IsSucceed = true };
            foreach (var data in parent.Data.Items)
            {
                var cloneData = await data.CloneAsync(cloneCultures, _context, _transaction);
                if (cloneData.IsSucceed)
                {
                    result.IsSucceed = cloneData.IsSucceed;
                }
                else
                {
                    result.IsSucceed = cloneData.IsSucceed;
                    result.Errors.AddRange(cloneData.Errors);
                    result.Ex = cloneData.Ex;
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
            //Data = ModuleDataRepository.GetInstance().GetModelListBy(d => d.ModuleId == Id && d.Specificulture == Specificulture, d => d.CreatedDate, "desc", 0, null, SWCmsConstants.ViewModelType.BackEnd);
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
