using System;
using Swastika.Extension.Customer.Domain.Validations;

namespace Swastika.Extension.Customer.Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerCommand" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="birthDate">The birth date.</param>
        public UpdateCustomerCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
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
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}