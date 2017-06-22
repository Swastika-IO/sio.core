using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Commands;
using Swastika.Domain.Core.Notifications;
using Swastika.Domain.Core.Interfaces;
using Swastika.Common.Utility;

namespace Swastika.Domain.Core.CommandHandlers
{
    public class CommandHandler
    {
        /// <summary>
        /// The uow{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IUnitOfWork _uow;
        /// <summary>
        /// The bus{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IBus _bus;
        /// <summary>
        /// The notifications{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        /// <param name="bus">The bus.</param>
        /// <param name="notifications">The notifications.</param>
        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = notifications;
            _bus = bus;
        }

        /// <summary>
        /// Notifies the validation errors.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification(
                Const.CONST_DOMAIN_NOTIFICATION_KEY_COMMIT,
                Const.CONST_DOMAIN_NOTIFICATION_KEY_COMMIT_VALUE));
            return false;
        }
    }
}