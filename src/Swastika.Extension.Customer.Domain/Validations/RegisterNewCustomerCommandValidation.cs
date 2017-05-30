using Swastika.Extension.Customer.Domain.Commands;

namespace Swastika.Extension.Customer.Domain.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNewCustomerCommandValidation" /> class.
        /// </summary>
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}