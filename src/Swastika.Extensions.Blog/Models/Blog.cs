using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Extension.Blog.Models
{
    public class Blog : Entity
    {
        public Blog(Guid id, string name, string title, string slug, string description, DateTime createdutc, DateTime modifiedutc, DateTime publishedutc, string createdbyuserid, Byte commonstatusid)
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

        }

        // Empty constructor for EF
        protected Blog() { }

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
