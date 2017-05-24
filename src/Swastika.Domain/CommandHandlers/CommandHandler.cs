using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Commands;
using Swastika.Domain.Core.Notifications;
using Swastika.Domain.Interfaces;

namespace Swastika.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private const string CONST_DOMAIN_NOTIFICATION_KEY_COMMIT = "Commit";
        private const string CONST_DOMAIN_NOTIFICATION_KEY_COMMIT_VALUE = "We had a problem during saving your data.";
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification(
                CONST_DOMAIN_NOTIFICATION_KEY_COMMIT, 
                CONST_DOMAIN_NOTIFICATION_KEY_COMMIT_VALUE));
            return false;
        }
    }
}