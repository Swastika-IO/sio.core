using System.Linq;
using Swastika.Extension.Customer.Domain.Interfaces;
//using Swastika.Domain.Models;
using Swastika.Extension.Customer.Infrastructure.Data.Context;

namespace Swastika.Extension.Customer.Infrastructure.Data.Repository
{
    public class CustomerRepository : Repository<Domain.Models.Customer>,  ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CustomerRepository(SwastikaExtensionCustomerContext context) : base(context)
        {

        }

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Domain.Models.Customer GetByEmail(string email)
        {
            return Find(c => c.Email == email).FirstOrDefault();
        }
    }
}
