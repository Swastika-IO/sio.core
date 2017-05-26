using Swastika.Extension.Blog.Domain.Commands;

namespace Swastika.Extension.Blog.Domain.Validations
{
    public class RemoveBlogCommandValidation : BlogValidation<RemoveBlogCommand>
    {
        public RemoveBlogCommandValidation()
        {
            ValidateId();
        }
    }
}