using System.Collections.Generic;
using Swastika.Domain.Core.Events;

namespace Swastika.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        /// <summary>
        /// Determines whether this instance has notifications.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has notifications; otherwise, <c>false</c>.
        /// </returns>
        bool HasNotifications();
        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <returns></returns>
        List<T> GetNotifications();
    }
}