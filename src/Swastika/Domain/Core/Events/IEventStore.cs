namespace Swastika.Domain.Core.Events
{
    public interface IEventStore
    {
        /// <summary>
        /// Saves the specified the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        void Save<T>(T theEvent) where T : Event;
    }
}