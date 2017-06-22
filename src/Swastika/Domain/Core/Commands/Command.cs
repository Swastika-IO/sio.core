using System;
using Swastika.Domain.Core.Events;
using FluentValidation.Results;

namespace Swastika.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; private set; }
        /// <summary>
        /// Gets or sets the validation result.
        /// </summary>
        /// <value>
        /// The validation result.
        /// </value>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsValid();
    }
}