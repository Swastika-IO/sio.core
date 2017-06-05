using Swastika.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastika.Extension.Blog.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool CheckExists(T entity);

        T CreateModel(T model);
        Task<T> CreateModelAsync(T model);

        T EditModel(T model);
        Task<T> EditModelAsync(T model);

        T SaveModel(T model);
        Task<T> SaveModelAsync(T model);

        bool RemoveModel(T model);
        bool RemoveModel(Expression<Func<T, bool>> predicate);
        bool RemoveListModel(Expression<Func<T, bool>> predicate);

        Task<bool> RemoveModelAsync(T model);
        Task<bool> RemoveModelAsync(Expression<Func<T, bool>> predicate);
        Task<bool> RemoveListModelAsync(Expression<Func<T, bool>> predicate);


        T GetSingleModel(Expression<Func<T, bool>> predicate, bool isGetSubModels);
        Task<T> GetSingleModelAsync(Expression<Func<T, bool>> predicate, bool isGetSubModels);

        List<T> GetModelList(bool isGetSubModels);
        PaginationModel<T> GetModelList(Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<T> GetModelList(Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<T> GetModelList(Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

        Task<PaginationModel<T>> GetModelListAsync(Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<T>> GetModelListAsync(Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<T>> GetModelListAsync(Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

        PaginationModel<T> GetModelListBy(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<T> GetModelListBy(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<T> GetModelListBy(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        List<T> GetModelListBy(Expression<Func<T, bool>> predicate, bool isGetSubModels);

        Task<PaginationModel<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<List<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, bool isGetSubModels);
    }
}
