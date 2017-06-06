using Microsoft.EntityFrameworkCore;
using Swastika.Common.Helper;
using Swastika.Extension.Blog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Swastika.Extension.Blog.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; set; }
        public RepositoryBase(DbContext context)
        {
            Context = context;
        }
        public virtual bool CheckExists(T entity)
        {
            using (Context)
            {
                //For the former case use:
                return Context.Set<T>().Local.Any(e => e == entity);

                //For the latter case use(it will check loaded entities as well):
                //return (_context.Set<T>().Find(keys) != null);               
            }
        }
        public bool CheckExists(System.Func<T, bool> predicate)
        {
            using (Context)
            {
                //For the former case use:
                return Context.Set<T>().Local.Any(predicate);

                //For the latter case use(it will check loaded entities as well):
                //return (_context.Set<T>().Find(keys) != null);
            }
        }

        public virtual T CreateModel(T model)
        {
            T result = null;
            try
            {
                using (Context)
                {
                    Context.Entry(model).State = EntityState.Added;
                    Context.SaveChanges();
                    result = model;

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }

        }

        public virtual async Task<T> CreateModelAsync(T model)
        {
            try
            {
                using (Context)
                {
                    Context.Entry(model).State = EntityState.Added;
                    int records = await Context.SaveChangesAsync();
                    if (records > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }
        }

        public virtual T EditModel(T model)
        {
            try
            {
                using (Context)
                {
                    Context.Entry(model).State = EntityState.Modified;
                    int records = Context.SaveChanges();
                    if (records > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }
        }

        public virtual async Task<T> EditModelAsync(T model)
        {
            try
            {
                using (Context)
                {
                    Context.Entry(model).State = EntityState.Modified;
                    int records = await Context.SaveChangesAsync();
                    if (records > 0)
                    {
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return null;
            }
        }
        #region GetModelList

        public virtual List<T> GetModelList(bool isGetSubModels)
        {
            using (Context)
            {
                try
                {
                    var query = Context.Set<T>().ToList();
                    query.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (query.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in query)
                        {
                            GetSubModels(model);
                        }
                    }
                    return query;

                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }

            }
        }
        public virtual PaginationModel<T> GetModelList(Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>();
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
                                lstModel = query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderByDescending(orderBy).ToList();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderBy(orderBy).ToList();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<T> GetModelList(Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>();
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
                                lstModel = query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderByDescending(orderBy).ToList();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderBy(orderBy).ToList();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<T> GetModelList(Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>();
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
                                lstModel = query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderByDescending(orderBy).ToList();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderBy(orderBy).ToList();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<T>> GetModelListAsync(Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>();
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
                                lstModel = await query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderByDescending(orderBy).ToListAsync();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = await query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderBy(orderBy).ToListAsync();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<List<T>> GetModelListAsync(bool isGetSubModels)
        {
            using (Context)
            {
                try
                {
                    var query = await Context.Set<T>().ToListAsync();
                    query.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (query.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in query)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }
                    return query;

                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }

            }
        }
        public virtual async Task<PaginationModel<T>> GetModelListAsync(Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>();
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
                                lstModel = await query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderByDescending(orderBy).ToListAsync();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = await query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderBy(orderBy).ToListAsync();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }
                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<T>> GetModelListAsync(Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>();
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
                                lstModel = await query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderByDescending(orderBy).ToListAsync();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = await query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderBy(orderBy).ToListAsync();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }

        #endregion

        #region GetModelListBy
        public virtual List<T> GetModelListBy(Expression<Func<T, bool>> predicate, bool isGetSubModels)
        {
            using (Context)
            {
                try
                {
                    var query = Context.Set<T>().Where(predicate).ToList();
                    query.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (isGetSubModels)
                    {
                        foreach (var model in query)
                        {
                            GetSubModels(model);
                        }
                    }
                    return query;

                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }

            }
        }
        public virtual PaginationModel<T> GetModelListBy(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>().Where(predicate);
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
                                lstModel = query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderByDescending(orderBy).ToList();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderBy(orderBy).ToList();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<T> GetModelListBy(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>().Where(predicate);
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
                                lstModel = query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderByDescending(orderBy).ToList();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderBy(orderBy).ToList();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<T> GetModelListBy(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>().Where(predicate);
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
                                lstModel = query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderByDescending(orderBy).ToList();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                            }
                            else
                            {
                                lstModel = query.OrderBy(orderBy).ToList();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }

        public virtual async Task<List<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, bool isGetSubModels)
        {
            using (Context)
            {
                try
                {
                    var query = await Context.Set<T>().Where(predicate).ToListAsync();
                    query.ForEach(p => Context.Entry(p).State = EntityState.Detached);
                    if (isGetSubModels)
                    {
                        foreach (var model in query)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }
                    return query;

                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }

            }
        }

        public virtual async Task<PaginationModel<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>().Where(predicate);
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
                                lstModel = await query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderByDescending(orderBy).ToListAsync();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = await query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderBy(orderBy).ToListAsync();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>().Where(predicate);
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
                                lstModel = await query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderByDescending(orderBy).ToListAsync();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = await query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderBy(orderBy).ToListAsync();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<T>> GetModelListByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (Context)
            {

                try
                {
                    PaginationModel<T> result = new PaginationModel<T>();
                    List<T> lstModel = new List<T>();
                    var query = Context.Set<T>().Where(predicate);
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
                                lstModel = await query.OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderByDescending(orderBy).ToListAsync();
                            }
                            break;
                        default:
                            if (pageSize.HasValue)
                            {
                                lstModel = await query.OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToListAsync();

                            }
                            else
                            {
                                lstModel = await query.OrderBy(orderBy).ToListAsync();
                            }
                            break;
                    }
                    lstModel.ForEach(p => Context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = lstModel;
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        #endregion


        public virtual T GetSingleModel(Expression<Func<T, bool>> predicate, bool isGetSubModels)
        {
            using (Context)
            {
                T query = Context.Set<T>().FirstOrDefault(predicate);
                if (query != null)
                {
                    Context.Entry(query).State = EntityState.Detached;
                    if (isGetSubModels)
                    {
                        GetSubModels(query);
                    }
                }
                return query;
            }
        }

        public virtual async Task<T> GetSingleModelAsync(Expression<Func<T, bool>> predicate, bool isGetSubModels)
        {
            using (Context)
            {
                T model = await Context.Set<T>().FirstOrDefaultAsync(predicate);
                if (model != null)
                {
                    Context.Entry(model).State = EntityState.Detached;
                }
                if (isGetSubModels)
                {
                    await GetSubModelsAsync(model);
                }
                return model;
            }
        }

        public virtual bool RemoveListModel(Expression<Func<T, bool>> predicate)
        {
            using (Context)
            {
                var models = Context.Set<T>().Where(predicate);
                if (models != null)
                {
                    foreach (var model in models)
                    {
                        Context.Entry(models).State = EntityState.Deleted;
                    }

                    int records = Context.SaveChanges();
                    return records > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual async Task<bool> RemoveListModelAsync(Expression<Func<T, bool>> predicate)
        {
            using (Context)
            {
                var models = await Context.Set<T>().Where(predicate).ToListAsync();
                if (models != null)
                {
                    foreach (var model in models)
                    {
                        Context.Entry(models).State = EntityState.Deleted;
                    }

                    int records = await Context.SaveChangesAsync();
                    return records > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual bool RemoveModel(Expression<Func<T, bool>> predicate)
        {
            T model = Context.Set<T>().FirstOrDefault(predicate);
            if (model != null)
            {

                Context.Entry(model).State = EntityState.Deleted;
                int records = Context.SaveChanges();
                return records > 0;
            }
            return false;
        }

        public virtual bool RemoveModel(T model)
        {
            try
            {
                using (Context)
                {
                    Context.Entry(model).State = EntityState.Deleted;
                    Context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return false;
            }
        }

        public virtual async Task<bool> RemoveModelAsync(Expression<Func<T, bool>> predicate)
        {
            using (Context)
            {
                T model = await Context.Set<T>().FirstOrDefaultAsync(predicate);
                if (model != null)
                {

                    Context.Entry(model).State = EntityState.Deleted;
                    int records = await Context.SaveChangesAsync();
                    return records > 0;
                }
                return false;
            }

        }

        public virtual async Task<bool> RemoveModelAsync(T model)
        {
            try
            {
                using (Context)
                {
                    Context.Entry(model).State = EntityState.Deleted;
                    int records = await Context.SaveChangesAsync();
                    return records > 0;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                return false;
            }
        }

        public virtual T SaveModel(T model)
        {
            if (CheckExists(model))
            {
                return EditModel(model);
            }
            else
            {
                return CreateModel(model);
            }
        }

        public virtual Task<T> SaveModelAsync(T model)
        {
            if (CheckExists(model))
            {
                return EditModelAsync(model);
            }
            else
            {
                return CreateModelAsync(model);
            }
        }

        public virtual void GetSubModels(T model) { }

        public virtual  Task GetSubModelsAsync(T model)
        {
            throw new NotImplementedException();
        }

        public virtual void LogErrorMessage(Exception ex)
        {

        }
    }
}
