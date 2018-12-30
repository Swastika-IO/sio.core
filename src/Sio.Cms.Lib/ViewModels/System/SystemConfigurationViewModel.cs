using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Cms.Lib.ViewModels;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioSystem
{
    public class SystemConfigurationViewModel
      : ViewModelBase<SioCmsContext, SioConfiguration, SystemConfigurationViewModel>
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
        public SioDataType DataType { get; set; }
        [JsonProperty("status")]
        public SioContentStatus Status { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdDatetime")]
        public DateTime CreatedDatetime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        #endregion Models

        #region Views

        [JsonProperty("domain")]
        public string Domain { get { return SioService.GetConfig<string>("Domain", Specificulture); } }

        [JsonProperty("property")]
        public DataValueViewModel Property { get; set; }

        #endregion Views
        #endregion Properties

        #region Contructors

        public SystemConfigurationViewModel()
            : base()
        {
        }
        public SystemConfigurationViewModel(SioConfiguration model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override SioConfiguration ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (CreatedDatetime == default(DateTime))
            {
                CreatedDatetime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }
        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Property = new DataValueViewModel() { DataType = DataType, Value = Value, Name = Keyword };
        }

        #endregion

        #region Expands

        public static async Task<RepositoryResponse<bool>> ImportConfigurations(List<SioConfiguration> arrConfiguration, string destCulture)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var context = new SioCmsContext();
            var transaction = context.Database.BeginTransaction();

            try
            {
                foreach (var item in arrConfiguration)
                {
                    var lang = new SystemConfigurationViewModel(item, context, transaction);
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
                UnitOfWorkHelper<SioCmsContext>.HandleTransaction(result.IsSucceed, true, transaction);
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                var error = UnitOfWorkHelper<SioCmsContext>.HandleException<SystemConfigurationViewModel>(ex, true, transaction);
                result.IsSucceed = false;
                result.Errors = error.Errors;
                result.Exception = error.Exception;
            }
            finally
            {
                //if current Context is Root
                context?.Dispose();
            }
            return result;
        }

        #endregion   
    }
}
