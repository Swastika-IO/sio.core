// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BECultureViewModel
        : ViewModelBase<SiocCmsContext, SiocCulture, BECultureViewModel>
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

        public BECultureViewModel() : base()
        {
        }

        public BECultureViewModel(SiocCulture model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(BECultureViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var configs = await ConfigurationViewModel.Repository.GetModelListByAsync(c => c.Specificulture == view.Specificulture, _context, _transaction);
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
                var languages = await BELanguageViewModel.Repository.GetModelListByAsync(c => c.Specificulture == view.Specificulture, _context, _transaction);
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
