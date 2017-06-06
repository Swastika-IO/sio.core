using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Swastika.Extension.Blog.Base;
using Swastika.Extension.Blog.Data;

namespace Swastika.Extensions.Blog.Repositories
{
    public class BlogPostRepository : RepositoryBase<Extension.Blog.Models.Blog, Extension.Blog.ViewModels.BlogViewModel, BlogDbContext>
    {
        public BlogPostRepository(BlogDbContext context) : base(context)
        {
        }
        
    }
}
