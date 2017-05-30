using System;

namespace Swastika.Domain.Core.Events
{
    public class StoredEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoredEvent" /> class.
        /// </summary>
        /// <param name="theEvent">The event.</param>
        /// <param name="data">The data.</param>
        /// <param name="user">The user.</param>
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        // EF Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="StoredEvent" /> class.
        /// </summary>
        protected StoredEvent() { }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public string Data { get; private set; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public string User { get; private set; }
    }
}