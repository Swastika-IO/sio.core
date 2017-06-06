using Swastika.Extension.Blog.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Extension.Blog.Interfaces
{
    public interface IService<T, TView> where T : class where TView : class
    {
        /// <summary>
        /// Registers the specified customer view model.
        /// </summary>
        /// <param name="TView">The customer view model.</param>
        void Register(TView TView);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TView> GetAll();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TView GetById(Guid id);
        /// <summary>
        /// Updates the specified customer view model.
        /// </summary>
        /// <param name="TView">The customer view model.</param>
        void Update(TView TView);
        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Remove(Guid id);
        /// <summary>
        /// Gets all history.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<HistoryData<T>> GetAllHistory(Guid id);
        /// <summary>
        /// Gets all history.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<HistoryData<T>> GetAllHistory(int id);
        /// <summary>
        /// Gets all history.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<HistoryData<T>> GetAllHistory(string id);
    }
}
