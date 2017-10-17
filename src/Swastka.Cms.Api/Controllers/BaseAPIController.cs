using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swastika.Domain.Core.Models;
using System.Linq.Expressions;
using System;
using Swastika.Common.Helper;
using Microsoft.Data.OData.Query;
using System.Threading.Tasks;
using Swastika.Infrastructure.Data.Repository;

namespace Swastka.Cms.Api.Controllers
{
    public class BaseAPIController<TContext, TModel> : Controller
        where TContext : DbContext
        where TModel : class
    {
        protected readonly DefaultRepository<TContext, TModel> _repo;
        public BaseAPIController()
        {
            _repo = DefaultRepository<TContext, TModel>.Instance;
        }      

        #region Common Methods
        public async Task<RepositoryResponse<List<TModel>>> GetAsync()
        {
            var result = await _repo.GetModelListAsync();
            return result;
        }


        public async Task<RepositoryResponse<TModel>> PostAsync([FromBody]TModel model)
        {
            var result = await _repo.SaveModelAsync(model);
            return result;
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            var result = await _repo.GetSingleModelAsync(predicate);
            return result;
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<bool>> DeleteAsync(Expression<Func<TModel, bool>> predicate)
        {
            var result = await _repo.RemoveModelAsync(predicate);
            return result;
        }

        #region Get Paging Models

        public async System.Threading.Tasks.Task<RepositoryResponse<PaginationModel<TModel>>> Search(
            Expression<Func<TModel, bool>> predicate, string orderBy, OrderByDirection direction
            , int? pageSize = null, int? pageIndex = null, string keyword = null)
        {
            var result = await _repo.GetModelListByAsync(predicate, orderBy, direction,
                pageIndex, pageSize);
            return result;
        }
        
        public async System.Threading.Tasks.Task<RepositoryResponse<PaginationModel<TModel>>> Get(
           string orderBy, OrderByDirection direction
           , int? pageSize, int pageIndex = 0)
        {
            var result = await _repo.GetModelListAsync(orderBy, direction,
                pageIndex, pageSize);
            return result;
        }
        
        #endregion
       

        #endregion
    }

    public class BaseAPIController<TDbContext, TModel, TView> : Controller
        where TDbContext : DbContext
        where TModel : class
        where TView : Swastika.Infrastructure.Data.ViewModels.ViewModelBase<TDbContext, TModel, TView>
    {
        protected readonly DefaultRepository<TDbContext, TModel, TView> _repo;
        public BaseAPIController()
        {
            _repo = DefaultRepository<TDbContext, TModel, TView>.Instance;
        }

        #region Common Methods
        public async Task<RepositoryResponse<List<TView>>> GetAsync()
        {
            var result = await _repo.GetModelListAsync();
            return result;
        }


        public async Task<RepositoryResponse<TView>> PostAsync([FromBody]TView model)
        {
            var result = await _repo.SaveModelAsync(model);
            return result;
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<TView>> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            var result = await _repo.GetSingleModelAsync(predicate);
            return result;
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<bool>> DeleteAsync(Expression<Func<TModel, bool>> predicate)
        {
            var result = await _repo.RemoveModelAsync(predicate);
            return result;
        }

        #region Get Paging Models

        public async System.Threading.Tasks.Task<RepositoryResponse<PaginationModel<TView>>> Search(
            Expression<Func<TModel, bool>> predicate, string orderBy, OrderByDirection direction
            , int? pageSize = null, int? pageIndex = null, string keyword = null)
        {
            var result = await _repo.GetModelListByAsync(predicate, orderBy, direction,
                pageIndex, pageSize);
            return result;
        }

        public async System.Threading.Tasks.Task<RepositoryResponse<PaginationModel<TView>>> Get(
           string orderBy, OrderByDirection direction
           , int? pageSize, int pageIndex = 0)
        {
            var result = await _repo.GetModelListAsync(orderBy, direction,
                pageIndex, pageSize);
            return result;
        }

        #endregion


        #endregion
    }
}