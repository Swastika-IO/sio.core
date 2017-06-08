using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Swastika.Extension.Blog.Models {

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Swastika.Domain.Core.Models.Entity" />
    public class Blog : Entity {

        /// <summary>
        /// Initializes a new instance of the <see cref="Blog"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="title">The title.</param>
        /// <param name="slug">The slug.</param>
        /// <param name="description">The description.</param>
        /// <param name="createdutc">The createdutc.</param>
        /// <param name="modifiedutc">The modifiedutc.</param>
        /// <param name="publishedutc">The publishedutc.</param>
        /// <param name="createdbyuserid">The createdbyuserid.</param>
        /// <param name="commonstatusid">The commonstatusid.</param>
        public Blog(Guid id, string name, string title, string slug, string description, DateTime createdutc, DateTime modifiedutc, DateTime publishedutc, string createdbyuserid, Byte commonstatusid) {
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
        /// <summary>
        /// Initializes a new instance of the <see cref="Blog"/> class.
        /// </summary>
        public Blog() { }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created UTC.
        /// </summary>
        /// <value>
        /// The created UTC.
        /// </value>
        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Gets or sets the modified UTC.
        /// </summary>
        /// <value>
        /// The modified UTC.
        /// </value>
        public DateTime ModifiedUtc { get; set; }

        /// <summary>
        /// Gets or sets the published UTC.
        /// </summary>
        /// <value>
        /// The published UTC.
        /// </value>
        public DateTime PublishedUtc { get; set; }

        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        /// <value>
        /// The created by user identifier.
        /// </value>
        public string CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the common status identifier.
        /// </summary>
        /// <value>
        /// The common status identifier.
        /// </value>
        public Byte CommonStatusId { get; set; }

        public virtual ICollection<BlogPost> BlogPost { get; set; }
    }
}