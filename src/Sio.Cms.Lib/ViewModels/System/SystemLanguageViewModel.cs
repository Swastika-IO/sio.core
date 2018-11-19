using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioSystem
{
    public class SystemLanguageViewModel
        : ViewModelBase<SioCmsContext, SioLanguage, SystemLanguageViewModel>
    {
        #region Properties

        #region Models

        [Required]
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("dataType")]
        public SioDataType DataType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [Required]
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        #endregion Models

        #endregion Properties

        #region Contructors

        public SystemLanguageViewModel() : base()
        {
        }

        public SystemLanguageViewModel(SioLanguage model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override RepositoryResponse<bool> RemoveRelatedModels(SystemLanguageViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            foreach (var culture in Cultures.Where(c => c.Specificulture != Specificulture))
            {
                var lang = _context.SioLanguage.First(c => c.Keyword == Keyword && c.Specificulture == culture.Specificulture);
                if (lang != null)
                {
                    _context.SioLanguage.Remove(lang);
                }
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = _context.SaveChanges() > 0
            };
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(SystemLanguageViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            foreach (var culture in Cultures.Where(c => c.Specificulture != Specificulture))
            {
                var lang = _context.SioLanguage.First(c => c.Keyword == Keyword && c.Specificulture == culture.Specificulture);
                if (lang != null)
                {
                    _context.SioLanguage.Remove(lang);
                }
            }
            return new RepositoryResponse<bool>()
            {
                IsSucceed = (await _context.SaveChangesAsync()) > 0
            };
        }

        #endregion Overrides

        #region Expands

        public static async Task<RepositoryResponse<bool>> ImportLanguages(List<SioLanguage> arrLanguage, string destCulture)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var context = new SioCmsContext();
            var transaction = context.Database.BeginTransaction();

            try
            {
                foreach (var item in arrLanguage)
                {
                    var lang = new SystemLanguageViewModel(item, context, transaction);
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
                var error = UnitOfWorkHelper<SioCmsContext>.HandleException<SystemLanguageViewModel>(ex, true, transaction);
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
