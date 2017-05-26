using System;
using Swastika.Extension.Blog.Domain.Validations;

namespace Swastika.Extension.Blog.Domain.Commands
{
    public class UpdateBlogCommand : BlogCommand
    {
        public UpdateBlogCommand(Guid id, string name, string title, string slug, string description, DateTime createdutc, DateTime modifiedutc, DateTime publishedutc, string createdbyuserid, int commonstatusid)
        {
            Id = id;
            Title = title;
            Slug = slug;
            Description = description;
            CreatedUtc = createdutc;
            ModifiedUtc = modifiedutc;
            PublishedUtc = publishedutc;
            CreatedByUserId = createdbyuserid;
            CommonStatusId = commonstatusid;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBlogCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}