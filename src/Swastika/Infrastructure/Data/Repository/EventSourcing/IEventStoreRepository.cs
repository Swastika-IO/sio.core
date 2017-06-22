using System;
using System.Collections.Generic;
using Swastika.Domain.Core.Events;

namespace Swastika.Infrastructure.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        /// <summary>
        /// Stores the specified the event.
        /// </summary>
        /// <param name="theEvent">The event.</param>
        void Store(StoredEvent theEvent);
        /// <summary>
        /// Alls the specified aggregate identifier.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <returns></returns>
        IList<StoredEvent> All(Guid aggregateId);
    }
}