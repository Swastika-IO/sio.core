using System.Collections.Generic;
using Swastika.Domain.Core.Events;

namespace Swastika.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}