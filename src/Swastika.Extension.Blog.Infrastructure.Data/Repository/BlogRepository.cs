using System.Linq;
using Swastika.Extension.Blog.Domain.Interfaces;
//using Swastika.Domain.Models;
using Swastika.Extension.Blog.Infrastructure.Data.Context;

namespace Swastika.Extension.Blog.Infrastructure.Data.Repository
{
    public class BlogRepository : Repository<Domain.Models.Blog>,  IBlogRepository
    {
        public BlogRepository(SwastikaExtensionBlogContext context)
            :base(context)
        {

        }       

        public Domain.Models.Blog GetByName(string name)
        {
            return Find(c => c.Name == name).FirstOrDefault();
        }
    }
}
