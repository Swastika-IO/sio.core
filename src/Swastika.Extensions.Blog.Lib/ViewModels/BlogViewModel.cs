using Swastika.Extension.Blog.Base;
using System;

namespace Swastika.Extension.Blog.ViewModels
{
    public class BlogViewModel: ViewModelBase<Models.Blog, ViewModels.BlogViewModel>
    { 
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedUtc { get; private set; }
        public DateTime ModifiedUtc { get; private set; }
        public DateTime PublishedUtc { get; private set; }
        public string CreatedByUserId { get; private set; }
        public Byte CommonStatusId { get; private set; }        
    }
}
