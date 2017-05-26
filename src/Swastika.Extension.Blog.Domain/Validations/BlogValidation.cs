using System;
using Swastika.Extension.Blog.Domain.Commands;
using FluentValidation;

namespace Swastika.Extension.Blog.Domain.Validations
{
    public abstract class BlogValidation<T> : AbstractValidator<T> where T : BlogCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateName() { }
        protected void ValidateTitle() { }
        protected void ValidateSlug() { }
        protected void ValidateDescription() { }
        protected void ValidateCreatedUtc() { }
        protected void ValidateModifiedUtc() { }
        protected void ValidatePublishedUtc() { }
        protected void ValidateCreatedByUserId() { }
        protected void ValidateCommonStatusId() { }

    }
}