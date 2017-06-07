using Swastika.Extension.Blog.Base;
using Swastika.Extension.Blog.Data;
using System;

namespace Swastika.Extensions.Blog.Repositories {

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Swastika.Extension.Blog.Base.RepositoryBase{Swastika.Extension.Blog.Models.Blog, Swastika.Extension.Blog.ViewModels.BlogViewModel, Swastika.Extension.Blog.Data.BlogDbContext}" />
    public class BlogPostRepository : RepositoryBase<Extension.Blog.Models.Blog, Extension.Blog.ViewModels.BlogViewModel, BlogDbContext> {

        /// <summary>
        /// The instance
        /// </summary>
        private static volatile BlogPostRepository instance;

        /// <summary>
        /// The synchronize root
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static BlogPostRepository GetInstance() {
            if (instance == null) {
                lock (syncRoot) {
                    if (instance == null)
                        instance = new BlogPostRepository();
                }
            }
            return instance;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="BlogPostRepository"/> class from being created.
        /// </summary>
        private BlogPostRepository() : base() {
        }
    }
}