using Swastika.Domain.Interfaces;

namespace Swastika.Extension.Customer.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Models.Customer>
    {
        Models.Customer GetByEmail(string email);
    }
}