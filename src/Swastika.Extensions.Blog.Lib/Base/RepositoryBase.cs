using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Swastika.Common.Helper;
using Swastika.Extension.Blog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Swastika.Extension.Blog.Base
{
    public abstract class RepositoryBase<TModel, TView, TContext> : IRepository<TModel, TView> where TModel : class where TView : ViewModelBase<TModel, TView> where TContext : DbContext
    {
        public RepositoryBase()
        {
            RegisterAutoMapper();
        }
        public virtual TContext InitContext()
        {
            Type classType = typeof(TContext);
            ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { });
            TContext context = (TContext)classConstructor.Invoke(new object[] {  });
            return context;
        }
        public virtual void RegisterAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TModel, TView>();
                cfg.CreateMap<TView, TModel>();
            });
        }
        public virtual TView ParseView(TModel model)
        {
            Type classType = typeof(TView);
            ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { model.GetType() });
            TView vm = (TView)classConstructor.Invoke(new object[] { model });
            return vm;
        }

        public virtual List<TView> ParseView(List<TModel> lstModel)
        {
            List<TView> result = new List<TView>();
            foreach (var model in lstModel)
            {
                result.Add(ParseView(model));
            }
            return result;

        }

        public virtual bool CheckExists(TModel entity)
        {
            using (TContext context = InitContext())
            {
                //For the former case use:
                return context.Set<TModel>().Local.Any(e => e == entity);

                //For the latter case use(it will check loaded entities as well):
                //return (_context.Set<T>().Find(keys) != null);               
            }
        }
        public bool CheckExists(System.Func<TModel, bool> predicate)
        {
            using (TContext context = InitContext())
            {
                //For the former case use:
                return context.Set<TModel>().Local.Any(predicate);

                //For the latter case use(it will check loaded entities as well):
                //return (_context.Set<T>().Find(keys) != null);
            }
        }

        public virtual TView CreateModel(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Added;
                    int records = context.SaveChanges();
                    if (records > 0)
                    {
                        return ParseView(model);
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

        public virtual async Task<TView> CreateModelAsync(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Added;
                    int records = await context.SaveChangesAsync();
                    if (records > 0)
                    {
                        return ParseView(model);
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

        public virtual TView EditModel(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Modified;
                    int records = context.SaveChanges();
                    if (records > 0)
                    {
                        return ParseView(model);
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

        public virtual async Task<TView> EditModelAsync(TModel model)
        {
            try
            {
                using (TContext context = InitContext())
                {
                    context.Entry(model).State = EntityState.Modified;
                    int records = await context.SaveChangesAsync();
                    if (records > 0)
                    {
                        return ParseView(model);
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
        public virtual async Task<List<TView>> GetViewModelListAsync(bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TView> result = new List<TView>();
                    var query = await context.Set<TModel>().ToListAsync();
                    query.ForEach(p => context.Entry(p).State = EntityState.Detached);
                    if (query.Count > 0)
                    {
                        foreach (var model in query)
                        {
                            if (isGetSubModels)
                            {
                                GetSubModels(model);
                            }
                            result.Add(ParseView(model));
                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }

                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }

            }
        }

        public virtual List<TView> GetModelList(bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    List<TView> result = new List<TView>();
                    var query = context.Set<TModel>().ToList();
                    query.ForEach(p => context.Entry(p).State = EntityState.Detached);
                    if (query.Count > 0)
                    {
                        foreach (var model in query)
                        {
                            if (isGetSubModels)
                            {
                                GetSubModels(model);
                            }
                            result.Add(ParseView(model));
                        }
                        return result;                        
                    }
                    else
                    {
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;
                }

            }
        }
        public virtual PaginationModel<TView> GetModelList(Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>();
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<TView> GetModelList(Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>();
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<TView> GetModelList(Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>();
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }

                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>();
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<List<TView>> GetModelListAsync(bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    var query = await context.Set<TModel>().ToListAsync();
                    query.ForEach(p => context.Entry(p).State = EntityState.Detached);
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
        public virtual async Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>();
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }
                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<TView>> GetModelListAsync(Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>();
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModel);
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
        public virtual List<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    var query = context.Set<TModel>().Where(predicate).ToList();
                    query.ForEach(p => context.Entry(p).State = EntityState.Detached);
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
        public virtual PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual PaginationModel<TView> GetModelListBy(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);
                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            GetSubModels(model);
                        }
                    }
                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }

        public virtual async Task<List<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                try
                {
                    var query = await context.Set<TModel>().Where(predicate).ToListAsync();
                    query.ForEach(p => context.Entry(p).State = EntityState.Detached);
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

        public virtual async Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, int>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, string>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModel);
                    return result;
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex);
                    return null;

                }
            }
        }
        public virtual async Task<PaginationModel<TView>> GetModelListByAsync(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {

                try
                {
                    PaginationModel<TView> result = new PaginationModel<TView>();
                    List<TModel> lstModel = new List<TModel>();
                    var query = context.Set<TModel>().Where(predicate);
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
                    lstModel.ForEach(p => context.Entry(p).State = EntityState.Detached);

                    if (lstModel.Count > 0 && isGetSubModels)
                    {
                        foreach (var model in lstModel)
                        {
                            await GetSubModelsAsync(model);
                        }
                    }

                    result.Items = ParseView(lstModel) ;
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


        public virtual TView GetSingleModel(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                TModel query = context.Set<TModel>().FirstOrDefault(predicate);
                if (query != null)
                {
                    context.Entry(query).State = EntityState.Detached;
                    if (isGetSubModels)
                    {
                        GetSubModels(query);
                    }
                    return ParseView(query);
                }
                return null;
            }
        }

        public virtual async Task<TView> GetSingleModelAsync(Expression<Func<TModel, bool>> predicate, bool isGetSubModels)
        {
            using (TContext context = InitContext())
            {
                TModel model = await context.Set<TModel>().FirstOrDefaultAsync(predicate);
                if (model != null)
                {
                    context.Entry(model).State = EntityState.Detached;
                }
                if (isGetSubModels)
                {
                    await GetSubModelsAsync(model);
                }
                return ParseView(model);
            }
        }

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

        public virtual TView SaveModel(TModel model)
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

        public virtual Task<TView> SaveModelAsync(TModel model)
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

        public virtual void GetSubModels(TModel model) { }

        public virtual Task GetSubModelsAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public virtual void LogErrorMessage(Exception ex)
        {

        }
    }
}
