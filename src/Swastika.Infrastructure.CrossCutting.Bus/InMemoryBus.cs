using System;
using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Commands;
using Swastika.Domain.Core.Events;
using Swastika.Domain.Core.Notifications;
using Swastika.Common.Utility;
namespace Swastika.Infrastructure.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {

        /// <summary>
        /// Gets or sets the container accessor.
        /// </summary>
        /// <value>
        /// The container accessor.
        /// </value>
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        private static IServiceProvider Container => ContainerAccessor();

        /// <summary>
        /// The event store{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryBus" /> class.
        /// </summary>
        /// <param name="eventStore">The event store.</param>
        public InMemoryBus(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            if (!theEvent.MessageType.Equals(Const.CONST_DOMAIN_NOTIFICATION))
                _eventStore?.Save(theEvent);

            Publish(theEvent);
        }

        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals(Const.CONST_DOMAIN_NOTIFICATION)
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        private object GetService(Type serviceType)
        {
            return Container.GetService(serviceType);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T GetService<T>()
        {
            return (T)Container.GetService(typeof(T));
        }
    }
}