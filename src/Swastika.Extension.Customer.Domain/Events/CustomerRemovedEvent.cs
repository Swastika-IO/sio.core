using System;
using Swastika.Domain.Core.Events;

namespace Swastika.Extension.Customer.Domain.Events
{
    public class CustomerRemovedEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRemovedEvent" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}