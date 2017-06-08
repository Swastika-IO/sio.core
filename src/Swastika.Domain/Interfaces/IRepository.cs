//using Swastika.Common.Helper;
//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Threading.Tasks;

//namespace Swastika.Domain.Interfaces {

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <typeparam name="TModel">The type of the model.</typeparam>
//    /// <typeparam name="TView">The type of the view.</typeparam>
//    public interface IRepository<TModel, TView> where TModel : class where TView : ViewModelBase<TModel, TView> {

//        /// <summary>
//        /// Determines whether the specified entity is exists.
//        /// </summary>
//        /// <param name="entity">The entity.</param>
//        /// <returns>
//        ///   <c>true</c> if the specified entity is exists; otherwise, <c>false</c>.
//        /// </returns>
//        bool isExists(TModel entity);

//        /// <summary>
//        /// Creates the model.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        TView CreateModel(TModel model);

//        /// <summary>
//        /// Creates the model asynchronous.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        Task<TView> CreateModelAsync(TModel model);

//        /// <summary>
//        /// Edits the model.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        TView EditModel(TModel model);

//        /// <summary>
//        /// Edits the model asynchronous.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        Task<TView> EditModelAsync(TModel model);

//        /// <summary>
//        /// Saves the model.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        TView SaveModel(TModel model);

//        /// <summary>
//        /// Saves the model asynchronous.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        Task<TView> SaveModelAsync(TModel model);

//        /// <summary>
//        /// Removes the model.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        bool RemoveModel(TModel model);

//        /// <summary>
//        /// Removes the model.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns></returns>
//        bool RemoveModel(Expression<Func<TModel, bool>> predicate);

//        /// <summary>
//        /// Removes the list model.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns></returns>
//        bool RemoveListModel(Expression<Func<TModel, bool>> predicate);

//        /// <summary>
//        /// Removes the model asynchronous.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        /// <returns></returns>
//        Task<bool> RemoveModelAsync(TModel model);

//        /// <summary>
//        /// Removes the model asynchronous.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns></returns>
//        Task<bool> RemoveModelAsync(Expression<Func<TModel, bool>> predicate);

//        /// <summary>
//        /// Removes the list model asynchronous.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns></returns>
//        Task<bool> RemoveListModelAsync(Expression<Func<TModel, bool>> predicate);

//        /// <summary>
//        /// Gets the single model.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        TView GetSingleModel(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);

//        /// <summary>
//        /// Gets the single model asynchronous.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<TView> GetSingleModelAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list.
//        /// </summary>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        List<TView> GetModelList(bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list.
//        /// </summary>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        PaginationModel<TView> GetModelList(Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list.
//        /// </summary>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        PaginationModel<TView> GetModelList(Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list.
//        /// </summary>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        PaginationModel<TView> GetModelList(Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list asynchronous.
//        /// </summary>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list asynchronous.
//        /// </summary>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list asynchronous.
//        /// </summary>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        List<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by asynchronous.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by asynchronous.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by asynchronous.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="orderBy">The order by.</param>
//        /// <param name="direction">The direction.</param>
//        /// <param name="pageIndex">Index of the page.</param>
//        /// <param name="pageSize">Size of the page.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels);

//        /// <summary>
//        /// Gets the model list by asynchronous.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
//        /// <returns></returns>
//        Task<List<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels);
//    }
//}