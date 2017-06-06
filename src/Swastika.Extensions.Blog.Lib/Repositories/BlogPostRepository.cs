using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Swastika.Extension.Blog.Base;

namespace Swastika.Extensions.Blog.Repositories
{
    public class BlogPostRepository : RepositoryBase<Extension.Blog.Models.Blog>
    {
        public BlogPostRepository(DbContext context) : base(context)
        {
        }
        
    }
}
