using Swastika.Domain.Core.Events;
using Swastika.Domain.Core.Interfaces;
using Swastika.Infrastructure.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace Swastika.Infrastructure.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        /// <summary>
        /// The event store repository{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IEventStoreRepository _eventStoreRepository;
        /// <summary>
        /// The user{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IUser _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlEventStore" /> class.
        /// </summary>
        /// <param name="eventStoreRepository">The event store repository.</param>
        /// <param name="user">The user.</param>
        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        /// <summary>
        /// Saves the specified the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Name);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}