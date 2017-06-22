using System;

namespace Swastika.Domain.Core.Events
{
    public abstract class Event : Message
    {
        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event" /> class.
        /// </summary>
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}