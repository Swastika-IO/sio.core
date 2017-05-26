using Swastika.Extension.Blog.Domain.Commands;

namespace Swastika.Extension.Blog.Domain.Validations
{
    public class RegisterNewBlogCommandValidation : BlogValidation<RegisterNewBlogCommand>
    {
        public RegisterNewBlogCommandValidation()
        {
            ValidateName();
            ValidateTitle();
            ValidateSlug();
            ValidateDescription();
            ValidateCreatedUtc();
            ValidateModifiedUtc();
            ValidatePublishedUtc();
            ValidateCreatedByUserId();
            ValidateCommonStatusId();

        }
    }
}