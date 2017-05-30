using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Core.Events;

namespace Swastika.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        /// <summary>
        /// The notifications{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private List<DomainNotification> _notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainNotificationHandler" /> class.
        /// </summary>
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(DomainNotification message)
        {
            _notifications.Add(message);
        }

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <returns></returns>
        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        /// <summary>
        /// Determines whether this instance has notifications.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has notifications; otherwise, <c>false</c>.
        /// </returns>
        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}