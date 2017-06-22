using System;

namespace Swastika.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Handle(T message);
    }
}