using Swastika.Domain.Core.Commands;
using Swastika.Domain.Core.Events;

namespace Swastika.Domain.Core.Bus
{
    public interface IBus
    {
        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        void SendCommand<T>(T theCommand) where T : Command;
        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}