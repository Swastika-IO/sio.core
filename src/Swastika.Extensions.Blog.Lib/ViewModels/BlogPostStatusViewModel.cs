using Swastika.Domain.Core.ViewModels;
using Swastika.Extension.Blog.Models;
using System.Collections.Generic;

namespace Swastika.Extensions.Blog.Lib.ViewModels
{
    public class BlogPostStatusViewModel: ViewModelBase<BlogPostStatus, BlogPostStatusViewModel>
    {
        public BlogPostStatusViewModel()
        {
            BlogPost = new List<BlogPostViewModel>();
        }

        public byte StatusId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual List<BlogPostViewModel> BlogPost { get; set; }
    }
}
