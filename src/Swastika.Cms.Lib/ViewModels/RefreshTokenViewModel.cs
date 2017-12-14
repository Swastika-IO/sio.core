using System;
using Swastika.Infrastructure.Data.ViewModels;
using Swastika.IO.Cms.Lib.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Domain.Core.Models;
using System.Threading.Tasks;

namespace Swastika.IO.Cms.Lib.ViewModels
{
    public class RefreshTokenViewModel : ViewModelBase<SiocCmsContext, RefreshTokens, RefreshTokenViewModel>
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string ClientId { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string Email { get; set; }

        public RefreshTokenViewModel(RefreshTokens model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #region Expands

        public static async Task<RepositoryResponse<bool>> LogoutOther(string refreshTokenId)
        {
            SiocCmsContext context = new SiocCmsContext();
            IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                var token = await RefreshTokenViewModel.Repository.GetSingleModelAsync(t => t.Id == refreshTokenId, context, transaction);
                if (token.IsSucceed)
                {
                    var result = await RefreshTokenViewModel.Repository.RemoveListModelAsync(t => t.Id != refreshTokenId && t.Email == token.Data.Email);
                    if (result.IsSucceed)
                    {

                        if (transaction == null)
                        {
                            transaction.Commit();
                        }

                        return new RepositoryResponse<bool>()
                        {
                            IsSucceed = true,
                            Data = true
                        };
                    }
                    else
                    {
                        if (transaction == null)
                        {
                            transaction.Rollback();
                        }

                        return new RepositoryResponse<bool>()
                        {
                            IsSucceed = false,
                            Data = false
                        };
                    }
                }
                else
                {
                    if (transaction == null)
                    {
                        transaction.Rollback();
                    }

                    return new RepositoryResponse<bool>()
                    {
                        IsSucceed = false,
                        Data = false
                    };
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = false,
                    Data = false,
                    Ex = ex
                };
            }
            finally
            {
                context.Dispose();
            }

        }

        #endregion

    }
}
