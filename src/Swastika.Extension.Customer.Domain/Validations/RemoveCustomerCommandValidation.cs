using Swastika.Extension.Customer.Domain.Commands;

namespace Swastika.Extension.Customer.Domain.Validations
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveCustomerCommandValidation" /> class.
        /// </summary>
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}