// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiLanguageViewModel
        : ViewModelBase<SiocCmsContext, SiocLanguage, ApiLanguageViewModel>
    {
        #region Properties

        #region Models

        [Required]
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [Required]
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }

        [JsonProperty("property")]
        public DataValueViewModel Property { get; set; }
        #endregion Views

        #endregion Properties

        #region Contructors

        public ApiLanguageViewModel() : base()
        {
        }

        public ApiLanguageViewModel(SiocLanguage model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override SiocLanguage ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Value = Property.Value;
            return base.ParseModel(_context, _transaction);
        }
        public override ApiLanguageViewModel ParseView(bool isExpand = true, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Property = new DataValueViewModel() { DataType = DataType, Value = Value, Name = Keyword };
            return base.ParseView(isExpand, _context, _transaction);
        }
        public override Task<ApiLanguageViewModel> ParseViewAsync(bool isExpand = true, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Property = new DataValueViewModel() { DataType = DataType, Value = Value, Name = Keyword };
            return base.ParseViewAsync(isExpand, _context, _transaction);
        }
        public override Task<bool> ExpandViewAsync(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Cultures = CommonRepository.Instance.LoadCultures(Specificulture, _context, _transaction);
            this.Cultures.ForEach(c => c.IsSupported = true);
            IsClone = true;
            
            return base.ExpandViewAsync(_context, _transaction);
        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Cultures = CommonRepository.Instance.LoadCultures(Specificulture, _context, _transaction);
            this.Cultures.ForEach(c => c.IsSupported = true);
            IsClone = true;
            Property = new DataValueViewModel() { DataType = DataType, Value = Value, Name = Keyword };
        }

        public override RepositoryResponse<bool> RemoveRelatedModels(ApiLanguageViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            foreach (var culture in Cultures.Where(c => c.Specificulture != Specificulture))
            {
                var lang = _context.SiocLanguage.First(c => c.Keyword == Keyword && c.Specificulture == culture.Specificulture);
                if (lang != null)
                {
                    _context.SiocLanguage.Remove(lang);
                }
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = _context.SaveChanges() > 0
            };
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(ApiLanguageViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            foreach (var culture in Cultures.Where(c => c.Specificulture != Specificulture))
            {
                var lang = _context.SiocLanguage.First(c => c.Keyword == Keyword && c.Specificulture == culture.Specificulture);
                if (lang != null)
                {
                    _context.SiocLanguage.Remove(lang);
                }
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = (await _context.SaveChangesAsync()) > 0
            };
        }

        #endregion Overrides
    }
}