using System;
using System.Collections.Generic;
using Swastika.Domain.Core.Events;

namespace Swastika.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}