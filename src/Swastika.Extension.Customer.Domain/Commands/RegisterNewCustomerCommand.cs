using System;
using Swastika.Extension.Customer.Domain.Validations;

namespace Swastika.Extension.Customer.Domain.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNewCustomerCommand" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="birthDate">The birth date.</param>
        public RegisterNewCustomerCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}