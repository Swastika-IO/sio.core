// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoConfigurationViewModel
       : ViewModelBase<SiocCmsContext, SiocConfiguration, InfoConfigurationViewModel>
    {
        #region Properties

        #region Models

        [Required]
        [JsonProperty("keyword")]
        public string Keyword { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }

        [JsonProperty("property")]
        public DataValueViewModel Property { get; set; }
        #endregion Views
        #endregion Properties

        #region Contructors

        public InfoConfigurationViewModel()
            : base()
        {
        }

        public InfoConfigurationViewModel(SiocConfiguration model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Property = new DataValueViewModel() { DataType = DataType, Value = Value, Name = Keyword };
        }

        #endregion

        #region Expands

        public static async Task<RepositoryResponse<bool>> ImportConfigurations(List<SiocConfiguration> arrConfiguration, string destCulture, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            bool isRoot = _context == null;
            var context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();

            try
            {
                foreach (var item in arrConfiguration)
                {
                    var lang = new InfoConfigurationViewModel(item, context, transaction);
                    lang.Specificulture = destCulture;
                    var saveResult = await lang.SaveModelAsync(false, context, transaction);
                    result.IsSucceed = result.IsSucceed && saveResult.IsSucceed;
                    if (!result.IsSucceed)
                    {
                        result.Exception = saveResult.Exception;
                        result.Errors = saveResult.Errors;
                        break;
                    }
                }
                UnitOfWorkHelper<SiocCmsContext>.HandleTransaction(result.IsSucceed, isRoot, transaction);
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                var error = UnitOfWorkHelper<SiocCmsContext>.HandleException<InfoConfigurationViewModel>(ex, isRoot, transaction);
                result.IsSucceed = false;
                result.Errors = error.Errors;
                result.Exception = error.Exception;
            }
            finally
            {
                //if current Context is Root
                if (isRoot)
                {
                    context?.Dispose();
                }
            }
            return result;
        }

        #endregion   
    }
}
