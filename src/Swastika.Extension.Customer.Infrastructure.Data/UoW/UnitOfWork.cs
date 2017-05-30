using Swastika.Domain.Core.Commands;
using Swastika.Domain.Interfaces;
using Swastika.Extension.Customer.Domain.Interfaces;
using Swastika.Extension.Customer.Infrastructure.Data.Context;

namespace Swastika.Extension.Customer.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The context{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly SwastikaExtensionCustomerContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(SwastikaExtensionCustomerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
