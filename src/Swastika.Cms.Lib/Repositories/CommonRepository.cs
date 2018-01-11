using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Lib.ViewModels.BackEnd;

namespace Swastika.Cms.Lib.Repositories
{
    public class CommonRepository
    {
        private static volatile CommonRepository instance;
        private static object syncRoot = new Object();

        private CommonRepository() { }

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

        #region Category-Article Navigator


        public RepositoryResponse<List<CategoryArticleViewModel>> GetCategoryArticleNav(string articleId, string specificulture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SiocCmsContext context = _context ?? new SiocCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var result = context.SiocCategory.Include(cp => cp.SiocCategoryArticle)
                    .Where(a => a.Specificulture == specificulture && a.Type == (int)SWCmsConstants.CateType.List)
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
            catch (Exception ex)
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
            catch (Exception ex)
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

        #endregion

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
            catch (Exception ex)
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
            catch (Exception ex)
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

        #endregion

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
                    //&& a.Type == (int)SWCmsConstants.ModuleType.SubArticle
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
            catch (Exception ex)
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<BEArticleModuleViewModel>>()
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
            catch (Exception ex)
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

        #endregion
    }
}
