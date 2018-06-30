// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.Repositories
{
    public class CommonRepository
    {
        private static volatile CommonRepository instance;
        private static readonly object syncRoot = new Object();

        private CommonRepository()
        {
        }

        public static CommonRepository Instance {
            get {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CommonRepository();
                    }
                }

                return instance;
            }
        }

        #region Article

        #region Category-Article Navigator

        public RepositoryResponse<List<NavCategoryArticleViewModel>> GetCategoryArticleNav(string ArticleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navCategoryArticleViewModels = context.SiocCategory.Include(cp => cp.SiocCategoryArticle)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.CateType.List)
                    .Select(p => new NavCategoryArticleViewModel(
                        new SiocCategoryArticle()
                        {
                            ArticleId = ArticleId,
                            CategoryId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocCategoryArticle.Any(cp => cp.ArticleId == ArticleId && cp.Specificulture == specificulture),
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavCategoryArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = navCategoryArticleViewModels.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavCategoryArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<List<NavCategoryArticleViewModel>>> GetCategoryArticleNavAsync(string ArticleId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navCategoryArticleViewModels = context.SiocCategory.Include(cp => cp.SiocCategoryArticle).Where(a => a.Specificulture == specificulture && a.Type == (int)SWCmsConstants.CateType.List)
                    .Select(p => new NavCategoryArticleViewModel(
                        new SiocCategoryArticle()
                        {
                            ArticleId = ArticleId,
                            CategoryId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocCategoryArticle.Any(cp => cp.ArticleId == ArticleId && cp.Specificulture == specificulture),
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavCategoryArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await navCategoryArticleViewModels.ToListAsync().ConfigureAwait(false)
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavCategoryArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion Category-Article Navigator

        #region Module-Article Navigator

        private IQueryable<NavModuleArticleViewModel> GetNavModuleArticleViewModel(string ArticleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            return context.SiocModule.Include(cp => cp.SiocModuleArticle)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.Root)
                     .Select(p => new NavModuleArticleViewModel(
                         new SiocModuleArticle()
                         {
                             ArticleId = ArticleId,
                             ModuleId = p.Id,
                             Specificulture = specificulture
                         },
                         _context, _transaction)
                     {
                         IsActived = p.SiocModuleArticle.Any(cp => cp.ArticleId == ArticleId && cp.Specificulture == specificulture),
                         Description = p.Title
                     });
        }

        public RepositoryResponse<List<NavModuleArticleViewModel>> GetModuleArticleNav(string ArticleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navModuleArticleViewModels = GetNavModuleArticleViewModel(ArticleId, specificulture, context, transaction);

                return new RepositoryResponse<List<NavModuleArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = navModuleArticleViewModels.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavModuleArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<List<NavModuleArticleViewModel>>> GetModuleArticleNavAsync(string ArticleId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navModuleArticleViewModels = GetNavModuleArticleViewModel(ArticleId, specificulture, context, transaction);

                return new RepositoryResponse<List<NavModuleArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await navModuleArticleViewModels.ToListAsync().ConfigureAwait(false)
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavModuleArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion Module-Article Navigator

        #region Article-Module Navigator

        private IQueryable<NavArticleModuleViewModel> GetNavArticleModuleViewModels(string ArticleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            return context.SiocModule.Include(cp => cp.SiocArticleModule)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.SubArticle)
                     .Select(p => new NavArticleModuleViewModel(
                         new SiocArticleModule()
                         {
                             ArticleId = ArticleId,
                             ModuleId = p.Id,
                             Specificulture = specificulture,
                         },

                         _context, _transaction)
                     {
                         IsActived = p.SiocArticleModule.Any(cp => cp.ArticleId == ArticleId && cp.Specificulture == specificulture),
                         Description = p.Title
                     });
        }

        public RepositoryResponse<List<NavArticleModuleViewModel>> GetArticleModuleNav(string ArticleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navArticleModuleViewModels = GetNavArticleModuleViewModels(ArticleId, specificulture, context, transaction);

                return new RepositoryResponse<List<NavArticleModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = navArticleModuleViewModels.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavArticleModuleViewModel>>()
                {
                    IsSucceed = false,
                    Data = null,
                    Errors = new List<string>() { ex.Message },
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<List<NavArticleModuleViewModel>>> GetArticleModuleNavAsync(string ArticleId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navArticleModuleViewModels = GetNavArticleModuleViewModels(ArticleId, specificulture, context, transaction);
                return new RepositoryResponse<List<NavArticleModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await navArticleModuleViewModels.ToListAsync().ConfigureAwait(false)
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavArticleModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion Article-Module Navigator

        #endregion Article

        #region Product

        #region Category-Product Navigator

        public RepositoryResponse<List<NavCategoryProductViewModel>> GetCategoryProductNav(string ProductId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navCategoryProductViewModels = context.SiocCategory.Include(cp => cp.SiocCategoryProduct)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.CateType.ListProduct)
                    .Select(p => new NavCategoryProductViewModel(
                        new SiocCategoryProduct()
                        {
                            ProductId = ProductId,
                            CategoryId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocCategoryProduct.Any(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture),
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavCategoryProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = navCategoryProductViewModels.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavCategoryProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<List<NavCategoryProductViewModel>>> GetCategoryProductNavAsync(string ProductId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navCategoryProductViewModels = context.SiocCategory.Include(cp => cp.SiocCategoryProduct).Where(a => a.Specificulture == specificulture && a.Type == (int)SWCmsConstants.CateType.List)
                    .Select(p => new NavCategoryProductViewModel(
                        new SiocCategoryProduct()
                        {
                            ProductId = ProductId,
                            CategoryId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocCategoryProduct.Any(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture),
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavCategoryProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = await navCategoryProductViewModels.ToListAsync().ConfigureAwait(false)
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavCategoryProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion Category-Product Navigator

        #region Module-Product Navigator

        private IQueryable<NavModuleProductViewModel> GetNavModuleProductViewModel(string ProductId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            return context.SiocModule.Include(cp => cp.SiocModuleProduct)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.Root)
                     .Select(p => new NavModuleProductViewModel(
                         new SiocModuleProduct()
                         {
                             ProductId = ProductId,
                             ModuleId = p.Id,
                             Specificulture = specificulture
                         },
                         _context, _transaction)
                     {
                         IsActived = p.SiocModuleProduct.Any(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture),
                         Description = p.Title
                     });
        }

        public RepositoryResponse<List<NavModuleProductViewModel>> GetModuleProductNav(string ProductId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navModuleProductViewModels = GetNavModuleProductViewModel(ProductId, specificulture, context, transaction);

                return new RepositoryResponse<List<NavModuleProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = navModuleProductViewModels.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavModuleProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<List<NavModuleProductViewModel>>> GetModuleProductNavAsync(string ProductId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navModuleProductViewModels = GetNavModuleProductViewModel(ProductId, specificulture, context, transaction);

                return new RepositoryResponse<List<NavModuleProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = await navModuleProductViewModels.ToListAsync().ConfigureAwait(false)
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavModuleProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion Module-Product Navigator

        #region Product-Module Navigator

        private IQueryable<NavProductModuleViewModel> GetNavProductModuleViewModels(string ProductId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            return context.SiocModule.Include(cp => cp.SiocProductModule)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.SubProduct)
                     .Select(p => new NavProductModuleViewModel(
                         new SiocProductModule()
                         {
                             ProductId = ProductId,
                             ModuleId = p.Id,
                             Specificulture = specificulture,
                         },

                         _context, _transaction)
                     {
                         IsActived = p.SiocProductModule.Any(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture),
                         Description = p.Title
                     });
        }

        public RepositoryResponse<List<NavProductModuleViewModel>> GetProductModuleNav(string ProductId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navProductModuleViewModels = GetNavProductModuleViewModels(ProductId, specificulture, context, transaction);

                return new RepositoryResponse<List<NavProductModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = navProductModuleViewModels.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavProductModuleViewModel>>()
                {
                    IsSucceed = false,
                    Data = null,
                    Errors = new List<string>() { ex.Message },
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<List<NavProductModuleViewModel>>> GetProductModuleNavAsync(string ProductId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navProductModuleViewModels = GetNavProductModuleViewModels(ProductId, specificulture, context, transaction);
                return new RepositoryResponse<List<NavProductModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await navProductModuleViewModels.ToListAsync().ConfigureAwait(false)
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<NavProductModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion Product-Module Navigator

        #endregion Product
    }
}