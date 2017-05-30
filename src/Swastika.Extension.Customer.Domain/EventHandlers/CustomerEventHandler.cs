using Swastika.Domain.Core.Events;
using Swastika.Extension.Customer.Domain.Events;

namespace Swastika.Extension.Customer.Domain.EventHandlers
{
    public class CustomerEventHandler :
        IHandler<CustomerRegisteredEvent>,
        IHandler<CustomerUpdatedEvent>,
        IHandler<CustomerRemovedEvent>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(CustomerUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(CustomerRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(CustomerRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}