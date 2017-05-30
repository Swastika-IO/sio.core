using System;
using System.Collections.Generic;
using Swastika.Extension.Customer.Application.EventSourcedNormalizers;
using Swastika.Extension.Customer.Application.ViewModels;

namespace Swastika.Extension.Customer.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        /// <summary>
        /// Registers the specified customer view model.
        /// </summary>
        /// <param name="customerViewModel">The customer view model.</param>
        void Register(CustomerViewModel customerViewModel);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CustomerViewModel> GetAll();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        CustomerViewModel GetById(Guid id);
        /// <summary>
        /// Updates the specified customer view model.
        /// </summary>
        /// <param name="customerViewModel">The customer view model.</param>
        void Update(CustomerViewModel customerViewModel);
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
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
