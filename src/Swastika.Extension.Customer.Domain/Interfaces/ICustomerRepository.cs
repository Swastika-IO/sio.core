using Swastika.Domain.Interfaces;

namespace Swastika.Extension.Customer.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Models.Customer>
    {
        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Models.Customer GetByEmail(string email);
    }
}