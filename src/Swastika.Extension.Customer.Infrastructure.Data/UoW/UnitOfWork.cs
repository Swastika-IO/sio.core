using Swastika.Domain.Core.Commands;
using Swastika.Domain.Interfaces;
using Swastika.Extension.Customer.Domain.Interfaces;
using Swastika.Extension.Customer.Infrastructure.Data.Context;

namespace Swastika.Extension.Customer.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SwastikaExtensionCustomerContext _context;

        public UnitOfWork(SwastikaExtensionCustomerContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
