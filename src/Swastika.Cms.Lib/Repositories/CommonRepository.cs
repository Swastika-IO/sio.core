// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
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
        private static object syncRoot = new Object();

        private CommonRepository()
        {
        }

        public static CommonRepository Instance
        {
            get
            {
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

        public RepositoryResponse<List<CategoryArticleViewModel>> GetCategoryArticleNav(string articleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocCategory.Include(cp => cp.SiocCategoryArticle)
                    .Where(a => a.Specificulture == specificulture
                    && (a.Type == (int)SWCmsConstants.CateType.List || a.Type == (int)SWCmsConstants.CateType.Home))
                    .Select(p => new CategoryArticleViewModel(
                        new SiocCategoryArticle()
                        {
                            ArticleId = articleId,
                            CategoryId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocCategoryArticle.Count(cp => cp.ArticleId == articleId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<CategoryArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = result.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<CategoryArticleViewModel>>()
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

        public async System.Threading.Tasks.Task<RepositoryResponse<List<CategoryArticleViewModel>>> GetCategoryArticleNavAsync(string articleId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocCategory.Include(cp => cp.SiocCategoryArticle).Where(a => a.Specificulture == specificulture && a.Type == (int)SWCmsConstants.CateType.List)
                    .Select(p => new CategoryArticleViewModel(
                        new SiocCategoryArticle()
                        {
                            ArticleId = articleId,
                            CategoryId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocCategoryArticle.Count(cp => cp.ArticleId == articleId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<CategoryArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await result.ToListAsync()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<CategoryArticleViewModel>>()
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

        public RepositoryResponse<List<ModuleArticleViewModel>> GetModuleArticleNav(string articleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocModule.Include(cp => cp.SiocModuleArticle)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.Root)
                     .Select(p => new ModuleArticleViewModel(
                         new SiocModuleArticle()
                         {
                             ArticleId = articleId,
                             ModuleId = p.Id,
                             Specificulture = specificulture
                         },
                         _context, _transaction)
                     {
                         IsActived = p.SiocModuleArticle.Count(cp => cp.ArticleId == articleId && cp.Specificulture == specificulture) > 0,
                         Description = p.Title
                     });
                return new RepositoryResponse<List<ModuleArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = result.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<ModuleArticleViewModel>>()
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

        public async System.Threading.Tasks.Task<RepositoryResponse<List<ModuleArticleViewModel>>> GetModuleArticleNavAsync(string articleId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocModule.Include(cp => cp.SiocModuleArticle)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.Root)
                    .Select(p => new ModuleArticleViewModel(
                        new SiocModuleArticle()
                        {
                            ArticleId = articleId,
                            ModuleId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocModuleArticle.Count(cp => cp.ArticleId == articleId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<ModuleArticleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await result.ToListAsync()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<ModuleArticleViewModel>>()
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

        public RepositoryResponse<List<BEArticleModuleViewModel>> GetArticleModuleNav(string articleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocModule.Include(cp => cp.SiocArticleModule)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.SubArticle
                    )
                     .Select(p => new BEArticleModuleViewModel(
                         new SiocArticleModule()
                         {
                             ArticleId = articleId,
                             ModuleId = p.Id,
                             Specificulture = specificulture,
                         },

                         _context, _transaction)
                     {
                         IsActived = p.SiocArticleModule.Count(cp => cp.ArticleId == articleId && cp.Specificulture == specificulture) > 0,
                         Description = p.Title
                     });
                return new RepositoryResponse<List<BEArticleModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = result.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<BEArticleModuleViewModel>>()
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

        public async System.Threading.Tasks.Task<RepositoryResponse<List<InfoArticleModuleViewModel>>> GetArticleModuleNavAsync(string articleId, string specificulture
           , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocModule.Include(cp => cp.SiocArticleModule)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.SubArticle)
                    .Select(p => new InfoArticleModuleViewModel(
                        new SiocArticleModule()
                        {
                            ArticleId = articleId,
                            ModuleId = p.Id,
                            Specificulture = specificulture,
                        },

                        _context, _transaction)
                    {
                        IsActived = p.SiocArticleModule.Count(cp => cp.ArticleId == articleId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<InfoArticleModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await result.ToListAsync()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<InfoArticleModuleViewModel>>()
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
                var result = context.SiocCategory.Include(cp => cp.SiocCategoryProduct)
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
                        IsActived = p.SiocCategoryProduct.Count(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavCategoryProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = result.ToList()
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
                var result = context.SiocCategory.Include(cp => cp.SiocCategoryProduct).Where(a => a.Specificulture == specificulture && a.Type == (int)SWCmsConstants.CateType.List)
                    .Select(p => new NavCategoryProductViewModel(
                        new SiocCategoryProduct()
                        {
                            ProductId = ProductId,
                            CategoryId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SiocCategoryProduct.Count(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavCategoryProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = await result.ToListAsync()
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

        public RepositoryResponse<List<NavModuleProductViewModel>> GetModuleProductNav(string ProductId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocModule.Include(cp => cp.SiocModuleProduct)
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
                         IsActived = p.SiocModuleProduct.Count(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture) > 0,
                         Description = p.Title
                     });
                return new RepositoryResponse<List<NavModuleProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = result.ToList()
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
                var result = context.SiocModule.Include(cp => cp.SiocModuleProduct)
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
                        IsActived = p.SiocModuleProduct.Count(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavModuleProductViewModel>>()
                {
                    IsSucceed = true,
                    Data = await result.ToListAsync()
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

        public RepositoryResponse<List<NavProductModuleViewModel>> GetProductModuleNav(string ProductId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocModule.Include(cp => cp.SiocProductModule)
                    .Where(a => a.Specificulture == specificulture
                    && a.Type == (int)SWCmsConstants.ModuleType.SubProduct
                    )
                     .Select(p => new NavProductModuleViewModel(
                         new SiocProductModule()
                         {
                             ProductId = ProductId,
                             ModuleId = p.Id,
                             Specificulture = specificulture,
                         },

                         _context, _transaction)
                     {
                         IsActived = p.SiocProductModule.Count(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture) > 0,
                         Description = p.Title
                     });
                return new RepositoryResponse<List<NavProductModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = result.ToList()
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
                var result = context.SiocModule.Include(cp => cp.SiocProductModule)
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
                        IsActived = p.SiocProductModule.Count(cp => cp.ProductId == ProductId && cp.Specificulture == specificulture) > 0,
                        Description = p.Title
                    });
                return new RepositoryResponse<List<NavProductModuleViewModel>>()
                {
                    IsSucceed = true,
                    Data = await result.ToListAsync()
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