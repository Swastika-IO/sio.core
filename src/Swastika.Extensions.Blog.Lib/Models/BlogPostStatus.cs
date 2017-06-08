using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Swastika.Extension.Blog.Models
{
    public partial class BlogPostStatus : Entity {
        public BlogPostStatus()
        {
            BlogPost = new HashSet<BlogPost>();
        }

        public byte StatusId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BlogPost> BlogPost { get; set; }
    }
}
