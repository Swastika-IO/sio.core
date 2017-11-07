using System;
using System.Collections.Generic;

namespace Swastika.IO.Cms.Lib.Models
{
    public partial class SiocComment
    {
        public Guid Id { get; set; }
        public int? ArticleId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool? IsReviewed { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsDeleted { get; set; }
    }
}
