using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Swastika.Common.Helper;
using Swastika.Domain.Core.Interfaces;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Swastika.Infrastructure.Data.Repository
{

    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="Swastika.Extension.Blog.Interfaces.IRepository{TModel, TView}" />
    public abstract class RepositoryBase<TModel, TView, TContext>
        : IRepository<TModel, TView> where TModel : class where TView : ViewModelBase<TModel, TView> where TContext : DbContext
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{TModel, TView, TContext}"/> class.
        /// </summary>
        public RepositoryBase()
        {
            RegisterAutoMapper();
        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        /// <returns></returns>
        public virtual TContext InitContext()
        {
            Type classType = typeof(TContext);
            ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { });
            TContext context = (TContext)classConstructor.Invoke(new object[] { });

            return context;
        }

        /// <summary>
        /// Registers the automatic mapper.
        /// </summary>
        public virtual void RegisterAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TModel, TView>();
                cfg.CreateMap<TView, TModel>();
            });
        }

        /// <summary>
        /// Parses the view.
        /// </summary>
        /// <param name="lstModels">The LST models.</param>
        /// <returns></returns>
        public virtual List<TView> ParseView(List<TModel> lstModels)
        {
            List<TView> lstView = new List<TView>();
            foreach (var model in lstModels)
            {
                lstView.Add(ParseView(model));
            }

            return lstView;
        }

        /// <summary>
        /// Parses the view.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual TView ParseView(TModel model)
        {
            Type classType = typeof(TView);
            ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { model.GetType() });
            TView vm = (TView)classConstructor.Invoke(new object[] { model });

            return vm;
        }

        /// <summary>
        /// Determines whether the specified entity is exists.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity is exists; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool isExists(TModel entity)
        {
            using (TContext context = InitContext())
            {
                //For the former case use:
                return context.Set<TModel>().Local.Any(e => e == entity);

                //For the latter case use(it will check loaded entities as well):
                //return (_context.Set<T>().Find(keys) != null);
            }
        }

        /// <summary>
        /// Determines whether the specified predicate is exists.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        ///   <c>true</c> if the specified predicate is exists; otherwise, <c>false</c>.
        /// </returns>
        public bool isExists(System.Func<TModel, bool> predicate)
        {
            using (TContext context = InitContext())
            {
                //For the former case use:
                return context.Set<TModel>().Local.Any(predicate);

                //For the latter case use(it will check loaded entities as well):
                //return (_context.Set<T>().Find(keys) != null);
            }
        }

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual TView CreateModel(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Added;

                    if (context.SaveChanges() > 0)
                    {
                        return ParseView(model);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            // TODO: Add more specific exeption types instead of Exception only
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }
        }

        /// <summary>
        /// Creates the model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual async Task<TView> CreateModelAsync(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Added;

                    if (await context.SaveChangesAsync() > 0)
                    {
                        return ParseView(model);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            // TODO: Add more specific exeption types instead of Exception only
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }
        }

        /// <summary>
        /// Edits the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual TView EditModel(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Modified;

                    if (context.SaveChanges() > 0)
                    {
                        return ParseView(model);
                    }

                    return null;
                }
            }
            // TODO: Add more specific exeption types instead of Exception only
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }
        }

        /// <summary>
        /// Edits the model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual async Task<TView> EditModelAsync(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Modified;

                    if (await context.SaveChangesAsync() > 0)
                    {
                        return ParseView(model);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            // TODO: Add more specific exeption types instead of Exception only
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }
        }

        #region GetModelList

        /// <summary>
        /// Gets the view model list asynchronous.
        /// </summary>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<List<TView>> GetViewModelListAsync(bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TView> lstViewResult = new List<TView>();
                    var lstModelss = await context.Set<TModel>().ToListAsync();

                    lstModelss.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModelss.Count > 0)
                    {
                        foreach (var model in lstModelss)
                        {
                            if (isGetSubModels)
                            {
                                GetSubModels(model);
                            }

                            lstViewResult.Add(ParseView(model));
                        }

                        return lstViewResult;
                    }
                    else
                    {
                        return lstViewResult;
                    }
                }
                // TODO: Add more specific exeption types instead of Exception only
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list.
        /// </summary>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual List<TView> GetModelList(bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TView> lstViewResult = new List<TView>();
                    var lstModelss = context.Set<TModel>().ToList();

                    lstModelss.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModelss.Count > 0)
                    {
                        foreach (var model in lstModelss)
                        {
                            if (isGetSubModels)
                            {
                                GetSubModels(model);
                            }

                            lstViewResult.Add(ParseView(model));
                        }
                        return lstViewResult;
                    }
                    else
                    {
                        return lstViewResult;
                    }
                }
                // TODO: Add more specific exeption types instead of Exception only
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual PaginationModel<TView> GetModelList(
            Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModelss = new List<TModel>();
                    var query = context.Set<TModel>();

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }

                    // TODO: should we change "direction" to boolean "isDesc" and use if condition instead?
                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModelss = query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModelss = query
                                    .OrderByDescending(orderBy)
                                    .ToList();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModelss = query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModelss = query
                                    .OrderBy(orderBy)
                                    .ToList();
                            }
                            break;
                    }

                    lstModelss.ForEach(model => context.Entry(model).State = EntityState.Detached);
                    if (lstModelss.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModelss)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModelss);
                    return result;
                }
                // TODO: Add more specific exeption types instead of Exception only
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual PaginationModel<TView> GetModelList(
            Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModelss = new List<TModel>();

                    var query = context.Set<TModel>();
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }

                    // TODO: should we change "direction" to boolean "isDesc" and use if condition instead?
                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModelss = query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModelss = query
                                    .OrderByDescending(orderBy)
                                    .ToList();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModelss = query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModelss = query
                                    .OrderBy(orderBy)
                                    .ToList();
                            }
                            break;
                    }

                    lstModelss.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModelss.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModelss)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModelss);
                    return result;
                }
                // TODO: Add more specific exeption types instead of Exception only
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual PaginationModel<TView> GetModelList(
            Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModelss = new List<TModel>();
                    var query = context.Set<TModel>();

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }

                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModelss = query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModelss = query
                                    .OrderByDescending(orderBy)
                                    .ToList();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModelss = query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value).ToList();
                            }
                            else
                            {
                                lstModelss = query
                                    .OrderBy(orderBy)
                                    .ToList();
                            }
                            break;
                    }

                    lstModelss.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModelss.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModelss)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModelss);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list asynchronous.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<PaginationModel<TView>> GetModelListAsync(
            Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModelss = new List<TModel>();
                    var query = context.Set<TModel>();

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }

                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModelss = await query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModelss = await query
                                    .OrderByDescending(orderBy)
                                    .ToListAsync();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModelss = await query.OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value).ToListAsync();
                            }
                            else
                            {
                                lstModelss = await query.OrderBy(orderBy)
                                    .ToListAsync();
                            }
                            break;
                    }

                    lstModelss.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModelss.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModelss)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModelss);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list asynchronous.
        /// </summary>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<List<TView>> GetModelListAsync(bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    var query = await context.Set<TModel>().ToListAsync();
                    query.ForEach(model => context.Entry(model).State = EntityState.Detached);
                    if (query.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in query)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }
                    return ParseView(query);
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list asynchronous.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<PaginationModel<TView>> GetModelListAsync(
            Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>();

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }

                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .ToListAsync();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .ToListAsync();
                            }
                            break;
                    }
                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list asynchronous.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<PaginationModel<TView>> GetModelListAsync(
            Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>();

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }

                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .ToListAsync();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .ToListAsync();
                            }
                            break;
                    }

                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        #endregion GetModelList

        #region GetModelListBy

        /// <summary>
        /// Gets the model list by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual List<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    var query = context.Set<TModel>().Where(predicate).ToList();
                    query.ForEach(model => context.Entry(model).State = EntityState.Detached);
                    if (isGetSubModels)
                    {
                        foreach (var model in query)
                        {
                            GetSubModels(model);
                        }
                    }
                    return ParseView(query);
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual PaginationModel<TView> GetModelListBy(
            Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }

                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModels = query
                                    .OrderByDescending(orderBy)
                                    .ToList();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModels = query
                                    .OrderBy(orderBy)
                                    .ToList();
                            }
                            break;
                    }

                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);
                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual PaginationModel<TView> GetModelListBy(
            Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }
                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModels = query
                                    .OrderByDescending(orderBy)
                                    .ToList();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModels = query
                                    .OrderBy(orderBy)
                                    .ToList();
                            }
                            break;
                    }

                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual PaginationModel<TView> GetModelListBy(
            Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }
                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModels = query
                                    .OrderByDescending(orderBy)
                                    .ToList();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToList();
                            }
                            else
                            {
                                lstModels = query
                                    .OrderBy(orderBy)
                                    .ToList();
                            }
                            break;
                    }

                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);
                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list by asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<List<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    var query = await context.Set<TModel>().Where(predicate).ToListAsync();
                    query.ForEach(model => context.Entry(model).State = EntityState.Detached);
                    if (isGetSubModels)
                    {
                        foreach (var model in query)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    return ParseView(query);
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list by asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<PaginationModel<TView>> GetModelListByAsync(
            Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }
                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .ToListAsync();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .ToListAsync();
                            }
                            break;
                    }

                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list by asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<PaginationModel<TView>> GetModelListByAsync(
            Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }
                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .ToListAsync();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .ToListAsync();
                            }
                            break;
                    }
                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the model list by asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<PaginationModel<TView>> GetModelListByAsync(
            Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TModel> lstModels = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);

                    PaginationModel<TView> result = new PaginationModel<TView>();
                    result.TotalItems = query.Count();
                    result.PageIndex = pageIndex ?? 0;
                    result.PageSize = pageSize ?? result.TotalItems;

                    if (pageSize.HasValue)
                    {
                        result.TotalPage = result.TotalItems / pageSize.Value + (result.TotalItems % pageSize.Value > 0 ? 1 : 0);
                    }
                    switch (direction)
                    {
                        case "desc":
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderByDescending(orderBy)
                                    .ToListAsync();
                            }
                            break;

                        default:
                            if (pageSize.HasValue)
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .Skip(pageIndex.Value * pageSize.Value)
                                    .Take(pageSize.Value)
                                    .ToListAsync();
                            }
                            else
                            {
                                lstModels = await query
                                    .OrderBy(orderBy)
                                    .ToListAsync();
                            }
                            break;
                    }
                    lstModels.ForEach(model => context.Entry(model).State = EntityState.Detached);

                    if (lstModels.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModels)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModels);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }
            }
        }

        #endregion GetModelListBy

        /// <summary>
        /// Gets the single model.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual TView GetSingleModel(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                TModel model = context.Set<TModel>().FirstOrDefault(predicate);
                if (model != null)
                {
                    context.Entry(model).State = EntityState.Detached;
                    if (isGetSubModels)
                    {
                        GetSubModels(model);
                    }
                    return ParseView(model);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the single model asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="isGetSubModels">if set to <c>true</c> [is get sub models].</param>
        /// <returns></returns>
        public virtual async Task<TView> GetSingleModelAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                TModel model = await context.Set<TModel>().FirstOrDefaultAsync(predicate);
                if (model != null)
                {
                    context.Entry(model).State = EntityState.Detached;

                    if (isGetSubModels)
                    {
                        await GetSubModelsAsync(model);
                    }
                    return ParseView(model);
                }
                else
                {
                    return null;
                }
            }
        }

        // TODO: Should return return enum status code instead
        /// <summary>
        /// Removes the list model.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual bool RemoveListModel(Expression<Func<TModel, bool>> predicate)
        {
            using (TContext context = InitContext())
            {
                var models = context.Set<TModel>().Where(predicate);
                if (models != null)
                {
                    foreach (var model in models)
                    {
                        context.Entry(models).State = EntityState.Deleted;
                    }

                    int records = context.SaveChanges();
                    return records > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        // TODO: Should return return enum status code instead
        /// <summary>
        /// Removes the list model asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual async Task<bool> RemoveListModelAsync(Expression<Func<TModel, bool>> predicate)
        {
            using (TContext context = InitContext())
            {
                var models = await context.Set<TModel>().Where(predicate).ToListAsync();
                if (models != null)
                {
                    foreach (var model in models)
                    {
                        context.Entry(models).State = EntityState.Deleted;
                    }

                    int records = await context.SaveChangesAsync();
                    return records > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        // TODO: Should return return enum status code instead
        /// <summary>
        /// Removes the model.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual bool RemoveModel(Expression<Func<TModel, bool>> predicate)
        {
            using (TContext context = InitContext())
            {
                TModel model = context.Set<TModel>().FirstOrDefault(predicate);
                if (model != null)
                {
                    context.Entry(model).State = EntityState.Deleted;
                    int records = context.SaveChanges();
                    return records > 0;
                }
                return false;
            }
        }

        // TODO: Should return return enum status code instead
        /// <summary>
        /// Removes the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual bool RemoveModel(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return false;
            }
        }

        // TODO: Should return return enum status code instead
        /// <summary>
        /// Removes the model asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual async Task<bool> RemoveModelAsync(Expression<Func<TModel, bool>> predicate)
        {
            using (TContext context = InitContext())
            {
                TModel model = await context.Set<TModel>().FirstOrDefaultAsync(predicate);
                if (model != null)
                {
                    context.Entry(model).State = EntityState.Deleted;
                    int records = await context.SaveChangesAsync();
                    return records > 0;
                }
                return false;
            }
        }

        // TODO: Should return return enum status code instead
        /// <summary>
        /// Removes the model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual async Task<bool> RemoveModelAsync(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Deleted;
                    int records = await context.SaveChangesAsync();
                    return records > 0;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Saves the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual TView SaveModel(TModel model)
        {
            if (isExists(model))
            {
                return EditModel(model);
            }
            else
            {
                return CreateModel(model);
            }
        }

        /// <summary>
        /// Saves the model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual Task<TView> SaveModelAsync(TModel model)
        {
            if (isExists(model))
            {
                return EditModelAsync(model);
            }
            else
            {
                return CreateModelAsync(model);
            }
        }

        /// <summary>
        /// Gets the sub models.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void GetSubModels(TModel model)
        {
        }

        /// <summary>
        /// Gets the sub models asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual Task GetSubModelsAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public virtual void LogErrorMessage(Exception ex)
        {
        }
    }
}