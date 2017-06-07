using Swastika.Extension.Blog.Base;
using System;

namespace Swastika.Extension.Blog.ViewModels
{
    public class BlogViewModel: ViewModelBase<Models.Blog, ViewModels.BlogViewModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public DateTime PublishedUtc { get; set; }
        public string CreatedByUserId { get; set; }
        public Byte CommonStatusId { get; set; }

        public BlogViewModel(Models.Blog model) : base(model)
        {
        }

        public BlogViewModel() : base()
        {
        }
    }
}
