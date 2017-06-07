using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Swastika.Extension.Blog.Base;
using Swastika.Extension.Blog.Data;

namespace Swastika.Extensions.Blog.Repositories
{
    public class BlogPostRepository : RepositoryBase<Extension.Blog.Models.Blog, Extension.Blog.ViewModels.BlogViewModel, BlogDbContext>
    {
        private static volatile BlogPostRepository instance;
        private static object syncRoot = new Object();

        public static BlogPostRepository GetInstance(BlogDbContext context)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new BlogPostRepository(context);
                }
            }
            return instance;
        }

        private BlogPostRepository(BlogDbContext context) : base(context)
        {

        }

    }
}
