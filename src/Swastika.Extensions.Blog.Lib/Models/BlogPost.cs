using Swastika.Domain.Core.Models;
using System;

namespace Swastika.Extension.Blog.Models {

    public partial class BlogPost : Entity {
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

        public virtual Blog Blog { get; set; }
        public virtual BlogPostStatus Status { get; set; }
    }
}