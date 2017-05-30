using System;
using Swastika.Domain.Core.Events;

namespace Swastika.Extension.Customer.Domain.Events
{
    public class CustomerRegisteredEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRegisteredEvent" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="birthDate">The birth date.</param>
        public CustomerRegisteredEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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