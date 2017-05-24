using Swastika.Domain.Core.Commands;
using Swastika.Domain.Interfaces;
using Swastika.Infrastructure.Data.Context;

namespace Swastika.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SwastikaContext _context;

        public UnitOfWork(SwastikaContext context)
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
