using Swastika.Common.Helper;
using Swastika.Extension.Blog.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastika.Extension.Blog.Interfaces
{
    public interface IRepository<TModel, TView> where TModel : class where TView : ViewModelBase<TModel, TView>
    {
        bool CheckExists(TModel entity);

        TView CreateModel(TModel model);
        Task<TView> CreateModelAsync(TModel model);

        TView EditModel(TModel model);
        Task<TView> EditModelAsync(TModel model);

        TView SaveModel(TModel model);
        Task<TView> SaveModelAsync(TModel model);

        bool RemoveModel(TModel model);
        bool RemoveModel(Expression<Func<TModel, bool>> predicate);
        bool RemoveListModel(Expression<Func<TModel, bool>> predicate);

        Task<bool> RemoveModelAsync(TModel model);
        Task<bool> RemoveModelAsync(Expression<Func<TModel, bool>> predicate);
        Task<bool> RemoveListModelAsync(Expression<Func<TModel, bool>> predicate);


        TView GetSingleModel(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);
        Task<TView> GetSingleModelAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);

        List<TView> GetModelList(bool isGetSubModels);
        PaginationModel<TView> GetModelList(Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<TView> GetModelList(Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<TView> GetModelList(Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

        Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

        PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        List<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);

        Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);
        Task<List<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);
    }
}
