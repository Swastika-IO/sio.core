// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
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
            var configs = await ApiConfigurationViewModel.Repository.GetModelListByAsync(c => c.Specificulture == view.Specificulture, _context, _transaction);
            if (configs.IsSucceed)
            {
                foreach (var item in configs.Data)
                {
                    var removeResult = await item.RemoveModelAsync(false, _context, _transaction);
                    result.IsSucceed = result.IsSucceed && removeResult.IsSucceed;
                    if (!result.IsSucceed)
                    {
                        result.Errors.AddRange(removeResult.Errors);
                        result.Exception = removeResult.Exception;
                        break;
                    }
                }
            }
            if (result.IsSucceed)
            {
                var languages = await ApiLanguageViewModel.Repository.GetModelListByAsync(
                    c => c.Specificulture == view.Specificulture, _context, _transaction);
                if (languages.IsSucceed)
                {
                    foreach (var item in languages.Data)
                    {
                        var removeResult = await item.RemoveModelAsync(false, _context, _transaction);
                        result.IsSucceed = result.IsSucceed && removeResult.IsSucceed;
                        if (!result.IsSucceed)
                        {
                            result.Errors.AddRange(removeResult.Errors);
                            result.Exception = removeResult.Exception;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        #endregion Overrides
    }
}
