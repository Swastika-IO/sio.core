using System;
using Swastika.Extension.Customer.Domain.Validations;

namespace Swastika.Extension.Customer.Domain.Commands
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveCustomerCommand" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}