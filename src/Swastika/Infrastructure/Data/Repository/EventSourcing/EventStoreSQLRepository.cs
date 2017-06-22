using System;
using System.Linq;
using System.Collections.Generic;
using Swastika.Domain.Core.Events;
using Swastika.Infrastructure.Data.Context;

namespace Swastika.Infrastructure.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        /// <summary>
        /// The context{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly EventStoreSQLContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreSQLRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EventStoreSQLRepository(EventStoreSQLContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Alls the specified aggregate identifier.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <returns></returns>
        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        /// <summary>
        /// Stores the specified the event.
        /// </summary>
        /// <param name="theEvent">The event.</param>
        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}