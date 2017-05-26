using Swastika.Extension.Blog.Domain.Commands;

namespace Swastika.Extension.Blog.Domain.Validations
{
    public class UpdateBlogCommandValidation : BlogValidation<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidation()
        {
            ValidateId();
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