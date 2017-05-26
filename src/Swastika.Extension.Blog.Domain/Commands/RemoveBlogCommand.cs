using System;
using Swastika.Extension.Blog.Domain.Validations;

namespace Swastika.Extension.Blog.Domain.Commands
{
    public class RemoveBlogCommand : BlogCommand
    {
        public RemoveBlogCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBlogCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}