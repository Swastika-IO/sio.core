//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;

//namespace Swastika.Domain.Interfaces
//{
//    public interface IRepository<TEntity> : IDisposable where TEntity : class
//    {
//        /// <summary>
//        /// Adds the specified object.
//        /// </summary>
//        /// <param name="obj">The object.</param>
//        void Add(TEntity obj);
//        /// <summary>
//        /// Gets the by identifier.
//        /// </summary>
//        /// <param name="id">The identifier.</param>
//        /// <returns></returns>
//        TEntity GetById(Guid id);
//        /// <summary>
//        /// Gets all.
//        /// </summary>
//        /// <returns></returns>
//        IEnumerable<TEntity> GetAll();
//        /// <summary>
//        /// Updates the specified object.
//        /// </summary>
//        /// <param name="obj">The object.</param>
//        void Update(TEntity obj);
//        /// <summary>
//        /// Removes the specified identifier.
//        /// </summary>
//        /// <param name="id">The identifier.</param>
//        void Remove(Guid id);
//        /// <summary>
//        /// Finds the specified predicate.
//        /// </summary>
//        /// <param name="predicate">The predicate.</param>
//        /// <returns></returns>
//        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
//        /// <summary>
//        /// Saves the changes.
//        /// </summary>
//        /// <returns></returns>
//        int SaveChanges();
//    }
//}
