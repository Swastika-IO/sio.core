using Microsoft.AspNetCore.Mvc;
using Swastika.Domain.Core.Notifications;

namespace Swastika.UI.Base.Controllers {

    public class BaseController : Controller {

        /// <summary>
        /// The notifications{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        /// <param name="notifications">The notifications.</param>
        public BaseController()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        /// <param name="notifications">The notifications.</param>
        public BaseController(IDomainNotificationHandler<DomainNotification> notifications) {
            _notifications = notifications;
        }

        /// <summary>
        /// Determines whether [is valid operation].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is valid operation]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValidOperation() {
            return (!_notifications.HasNotifications());
        }

        public override NotFoundResult NotFound()
        {
            return base.NotFound();
        }
    }
}