using System;
using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Commands;
using Swastika.Domain.Core.Events;
using Swastika.Domain.Core.Notifications;

namespace Swastika.Infrastructure.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        private const string CONST_DOMAIN_NOTIFICATION = "DomainNotification";

        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();

        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            if(!theEvent.MessageType.Equals(CONST_DOMAIN_NOTIFICATION))
                _eventStore?.Save(theEvent);

            Publish(theEvent);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals(CONST_DOMAIN_NOTIFICATION)
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }

        private object GetService(Type serviceType)
        {
            return Container.GetService(serviceType);
        }

        private T GetService<T>()
        {
            return (T)Container.GetService(typeof(T));
        }
    }
}