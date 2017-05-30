using System;
using Swastika.Domain.Core.Events;

namespace Swastika.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        /// <summary>
        /// Gets the domain notification identifier.
        /// </summary>
        /// <value>
        /// The domain notification identifier.
        /// </value>
        public Guid DomainNotificationId { get; private set; }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; private set; }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; private set; }
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainNotification" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}