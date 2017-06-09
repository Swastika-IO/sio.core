using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Swastika.Domain.Core.Interfaces;
using Swastika.Extension.Customer.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Swastika.Extension.Customer.Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The database{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        protected SwastikaExtensionCustomerContext Db;
        /// <summary>
        /// The database set{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        protected DbSet<TEntity> DbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(SwastikaExtensionCustomerContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        /// <summary>
        /// Adds the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
