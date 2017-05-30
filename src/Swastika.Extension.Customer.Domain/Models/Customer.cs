using System;
using Swastika.Domain.Core.Models;

namespace Swastika.Extension.Customer.Domain.Models
{
    public class Customer : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="birthDate">The birth date.</param>
        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        // Empty constructor for EF
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        protected Customer() { }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public DateTime BirthDate { get; private set; }
    }
}