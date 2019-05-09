using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Repositories;
using Sio.Cms.Lib.ViewModels.SioSystem;
using Sio.Common.Helper;
using Sio.Domain.Core.Models;
using Sio.Domain.Core.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sio.Cms.Lib.ViewModels.SioPages
{
    public class Helper
    {
        public static async Task<RepositoryResponse<bool>> ImportAsync(List<SioPages.ImportViewModel> arrPage, string destCulture,
          SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            bool isRoot = _context == null;
            var context = _context ?? new SioCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();

            try
            {
                int id = UpdateViewModel.ModelRepository.Max(m => m.Id, context, transaction).Data + 1;
                var pages = FileRepository.Instance.GetFile(SioConstants.CONST_FILE_PAGES, "data", true, "{}");
                var obj = JObject.Parse(pages.Content);
                var initPages = obj["data"].ToObject<JArray>();
                foreach (var item in arrPage)
                {
                    if (item.Id > initPages.Count)
                    {
                        item.Id = id;
                        item.CreatedDateTime = DateTime.UtcNow;
                    }
                    item.Specificulture = destCulture;
                    var saveResult = await item.SaveModelAsync(true, context, transaction);
                    if (!saveResult.IsSucceed)
                    {
                        result.IsSucceed = false;
                        result.Exception = saveResult.Exception;
                        result.Errors = saveResult.Errors;
                        break;
                    }
                    else if (item.Id > initPages.Count)
                    {
                        id++;
                    }
                }
                result.Data = true;
                UnitOfWorkHelper<SioCmsContext>.HandleTransaction(result.IsSucceed, isRoot, transaction);
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {

                var error = UnitOfWorkHelper<SioCmsContext>.HandleException<ReadMvcViewModel>(ex, isRoot, transaction);
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


        public static List<SupportedCulture> LoadCultures(int id, string initCulture = null, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCultures = SystemCultureViewModel.Repository.GetModelList(_context, _transaction);
            var result = new List<SupportedCulture>();
            if (getCultures.IsSucceed)
            {
                foreach (var culture in getCultures.Data)
                {
                    result.Add(
                        new SupportedCulture()
                        {
                            Icon = culture.Icon,
                            Specificulture = culture.Specificulture,
                            Alias = culture.Alias,
                            FullName = culture.FullName,
                            Description = culture.FullName,
                            Id = culture.Id,
                            Lcid = culture.Lcid,
                            IsSupported = culture.Specificulture == initCulture || _context.SioPage.Any(p => p.Id == id && p.Specificulture == culture.Specificulture)
                        });

                }
            }
            return result;
        }

    }
}
