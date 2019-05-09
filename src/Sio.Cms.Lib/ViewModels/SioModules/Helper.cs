using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.ViewModels.SioSystem;
using Sio.Common.Helper;
using Sio.Domain.Core.Models;
using Sio.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sio.Cms.Lib.ViewModels.SioModules
{
    public class Helper
    {
        public static async Task<RepositoryResponse<bool>> Import(List<SioModule> arrModule, string destCulture,
           SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            bool isRoot = _context == null;
            var context = _context ?? new SioCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();

            try
            {
                int id = UpdateViewModel.ModelRepository.Max(m => m.Id, context, transaction).Data + 1;
                foreach (var item in arrModule)
                {
                    item.Id = id;
                    item.CreatedDateTime = DateTime.UtcNow;
                    item.Specificulture = destCulture;
                    context.SioModule.Add(item);
                    id++;
                }
                await context.SaveChangesAsync();
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
                            IsSupported = culture.Specificulture == initCulture || _context.SioModule.Any(p => p.Id == id && p.Specificulture == culture.Specificulture)
                        });

                }
            }
            return result;
        }

        public static RepositoryResponse<UpdateViewModel> GetBy(
            Expression<Func<SioModule, bool>> predicate, string articleId = null, string productId = null, int categoryId = 0
             , SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = UpdateViewModel.Repository.GetSingleModel(predicate, _context, _transaction);
            if (result.IsSucceed)
            {
                result.Data.ArticleId = articleId;
                result.Data.CategoryId = categoryId;
            }
            return result;
        }

    }
}
