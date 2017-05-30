using Swastika.Extension.Customer.Domain.Commands;

namespace Swastika.Extension.Customer.Domain.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerCommandValidation" /> class.
        /// </summary>
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}