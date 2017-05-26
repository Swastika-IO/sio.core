using Swastika.Domain.Core.Commands;
using Swastika.Domain.Interfaces;
using Swastika.Extension.Blog.Domain.Interfaces;
using Swastika.Extension.Blog.Infrastructure.Data.Context;

namespace Swastika.Extension.Blog.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SwastikaExtensionBlogContext _context;

        public UnitOfWork(SwastikaExtensionBlogContext context)
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
