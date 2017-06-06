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
        public Blog() { }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public DateTime PublishedUtc { get; set; }
        public string CreatedByUserId { get; set; }
        public Byte CommonStatusId { get; set; }

    }
}
