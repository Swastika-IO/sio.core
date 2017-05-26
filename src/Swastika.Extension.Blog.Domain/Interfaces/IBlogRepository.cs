using Swastika.Domain.Interfaces;

namespace Swastika.Extension.Blog.Domain.Interfaces
{
    public interface IBlogRepository : IRepository<Models.Blog>
    {
        Models.Blog GetByName(string name);
    }
}