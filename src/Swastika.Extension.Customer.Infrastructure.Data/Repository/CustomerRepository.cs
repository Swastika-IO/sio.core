using System.Linq;
using Swastika.Extension.Customer.Domain.Interfaces;
//using Swastika.Domain.Models;
using Swastika.Extension.Customer.Infrastructure.Data.Context;

namespace Swastika.Extension.Customer.Infrastructure.Data.Repository
{
    public class CustomerRepository : Repository<Domain.Models.Customer>,  ICustomerRepository
    {
        public CustomerRepository(SwastikaExtensionCustomerContext context)
            :base(context)
        {

        }       

        public Domain.Models.Customer GetByEmail(string email)
        {
            return Find(c => c.Email == email).FirstOrDefault();
        }
    }
}
