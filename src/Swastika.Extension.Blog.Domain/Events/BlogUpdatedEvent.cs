using System;
using Swastika.Domain.Core.Events;

namespace Swastika.Extension.Blog.Domain.Events
{
    public class BlogUpdatedEvent : Event
    {
        public BlogUpdatedEvent(Guid id, string name, string title, string slug, string description, DateTime createdutc, DateTime modifiedutc, DateTime publishedutc, string createdbyuserid, int commonstatusid)
        {
            Id = id;
            Name = name;
            Title = title;
            Slug = slug;
            Description = description;
            CreatedUtc = createdutc;
            ModifiedUtc = modifiedutc;
            PublishedUtc = publishedutc;
            CreatedByUserId = createdbyuserid;
            CommonStatusId = commonstatusid;
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedUtc { get; private set; }
        public DateTime ModifiedUtc { get; private set; }
        public DateTime PublishedUtc { get; private set; }
        public string CreatedByUserId { get; private set; }
        public int CommonStatusId { get; private set; }
    }
}