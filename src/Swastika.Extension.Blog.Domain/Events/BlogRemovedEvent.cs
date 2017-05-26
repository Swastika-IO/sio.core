using System;
using Swastika.Domain.Core.Events;

namespace Swastika.Extension.Blog.Domain.Events
{
    public class BlogRemovedEvent : Event
    {
        public BlogRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}