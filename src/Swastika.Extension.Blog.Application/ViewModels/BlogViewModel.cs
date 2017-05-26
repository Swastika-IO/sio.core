using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Extension.Blog.Application.ViewModels
{
    public class BlogViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Slug")]
        public string Slug { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("CreatedUtc")]
        public DateTime CreatedUtc { get; set; }
        [DisplayName("ModifiedUtc")]
        public DateTime ModifiedUtc { get; set; }
        [DisplayName("PublishedUtc")]
        public DateTime PublishedUtc { get; set; }
        [DisplayName("CreatedByUserId")]
        public string CreatedByUserId { get; set; }
        [DisplayName("CommonStatusId")]
        public int CommonStatusId { get; set; }

    }
}
