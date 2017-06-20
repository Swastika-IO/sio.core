using Swastika.Domain.Core.ViewModels;
using Swastika.Extensions.Blog.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Extension.Blog.ViewModels
{

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Swastika.Extension.Blog.Base.ViewModelBase{Swastika.Extension.Blog.Models.Blog, Swastika.Extension.Blog.ViewModels.BlogViewModel}" />
    public class BlogViewModel : ViewModelBase<Models.Blog, ViewModels.BlogViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogViewModel"/> class.
        /// </summary>
        public BlogViewModel() : base()
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        //[Required]
        public string CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the common status identifier.
        /// </summary>
        /// <value>
        /// The common status identifier.
        /// </value>
        public Byte CommonStatusId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public BlogViewModel(Models.Blog model) : base(model) {
        }

        /// <summary>
        /// Gets or sets the blog post.
        /// </summary>
        /// <value>
        /// The blog post.
        /// </value>
        public virtual List<BlogPostViewModel> BlogPost { get; set; }
    }
}