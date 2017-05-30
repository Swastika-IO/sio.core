using System;
using Swastika.Extension.Customer.Domain.Commands;
using FluentValidation;

namespace Swastika.Extension.Customer.Domain.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        /// <summary>
        /// Validates the name.
        /// </summary>
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        /// <summary>
        /// Validates the birth date.
        /// </summary>
        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer must have 18 years or more");
        }

        /// <summary>
        /// Validates the email.
        /// </summary>
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        /// <summary>
        /// Validates the identifier.
        /// </summary>
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        /// <summary>
        /// Haves the minimum age.
        /// </summary>
        /// <param name="birthDate">The birth date.</param>
        /// <returns></returns>
        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}