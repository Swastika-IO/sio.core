using Swastika.Domain.Core.ViewModels;
using Swastika.Extension.Blog.Models;
using System;

namespace Swastika.Extensions.Blog.Lib.ViewModels
{
    public class BlogPostViewModel: ViewModelBase<BlogPost, BlogPostViewModel>
    {
        public Guid PostId { get; set; }
        public Guid BlogId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Excerpt { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Content { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? ModifiedUtc { get; set; }
        public DateTime? PublishedUtc { get; set; }
        public byte? StatusId { get; set; }

        public virtual BlogPostStatusViewModel Status { get; set; }
    }
}
