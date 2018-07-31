// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiCultureViewModel
        : ViewModelBase<SiocCmsContext, SiocCulture, ApiCultureViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("lcid")]
        public string Lcid { get; set; }

        [Required]
        [JsonProperty("specificulture")]
        public new string Specificulture { get; set; }


        #endregion Models

        #endregion Properties

        #region Contructors

        public ApiCultureViewModel() : base()
        {
        }

        public ApiCultureViewModel(SiocCulture model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override async Task<RepositoryResponse<ApiCultureViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalConfigurationService.Instance.RefreshCultures();
            }
            return result;
        }
        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocCulture parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                var getConfigurations = await ApiConfigurationViewModel.Repository.GetModelListByAsync(c => c.Specificulture == GlobalConfigurationService.Instance.CmsConfigurations.Language, _context, _transaction);
                if (getConfigurations.IsSucceed)
                {
                    foreach (var c in getConfigurations.Data)
                    {
                        var cnf = new SiocConfiguration()
                        {
                            Keyword = c.Keyword,
                            Specificulture = Specificulture,
                            Category = c.Category,
                            DataType = (int)c.DataType,
                            Description = c.Description,
                            Priority = c.Priority.HasValue ? c.Priority.Value : 0,
                            Status = (int)c.Status,
                            Value = c.Value
                        };
                        _context.Entry(cnf).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }

                var getLanguages = await ApiLanguageViewModel.Repository.GetModelListByAsync(c => c.Specificulture == GlobalConfigurationService.Instance.CmsConfigurations.Language, _context, _transaction);
                if (getLanguages.IsSucceed)
                {
                    foreach (var c in getLanguages.Data)
                    {
                        var cnf = new SiocLanguage()
                        {
                            Keyword = c.Keyword,
                            Specificulture = Specificulture,
                            Category = c.Category,
                            DataType = (int)c.DataType,
                            Description = c.Description,
                            Priority = c.Priority.HasValue ? c.Priority.Value : 0,
                            Status = (int)c.Status,
                            DefaultValue = c.DefaultValue
                        };
                        _context.Entry(cnf).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }
                _context.SaveChanges();
            }
            return new RepositoryResponse<bool>() { IsSucceed = true };
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(ApiCultureViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };

            var configs = _context.SiocConfiguration.Where(c => c.Specificulture == Specificulture).ToList();
            configs.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var languages = _context.SiocLanguage.Where(l => l.Specificulture == Specificulture).ToList();
            languages.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var cates = _context.SiocCategory.Where(c => c.Specificulture == Specificulture).ToList();
            cates.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var modules = _context.SiocModule.Where(c => c.Specificulture == Specificulture).ToList();
            modules.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var articles = _context.SiocArticle.Where(c => c.Specificulture == Specificulture).ToList();
            articles.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var products = _context.SiocProduct.Where(c => c.Specificulture == Specificulture).ToList();
            products.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            await  _context.SaveChangesAsync();

            return result;
        }

        public override async Task<RepositoryResponse<SiocCulture>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                var cultures = CommonRepository.Instance.LoadCultures(null, _context, _transaction);
                var settings = FileRepository.Instance.GetFile("appsettings", ".json", string.Empty, true, "{}");
                var jsonSettings = JObject.Parse(settings.Content);
                if (jsonSettings["Language"].Value<string>() == Specificulture)
                {
                    jsonSettings["Language"] = cultures.FirstOrDefault().Specificulture;                    
                }
                FileRepository.Instance.SaveFile(settings);
                GlobalConfigurationService.Instance.RefreshAll(_context, _transaction);
            }
            return result;
        }

        #endregion Overrides
    }
}
