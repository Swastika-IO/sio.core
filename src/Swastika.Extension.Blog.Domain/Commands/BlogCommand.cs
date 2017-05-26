using System;
using Swastika.Domain.Core.Commands;

namespace Swastika.Extension.Blog.Domain.Commands
{
    public abstract class BlogCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Title { get; protected set; }
        public string Slug { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedUtc { get; protected set; }
        public DateTime ModifiedUtc { get; protected set; }
        public DateTime PublishedUtc { get; protected set; }
        public string CreatedByUserId { get; protected set; }
        public int CommonStatusId { get; protected set; }

    }
}