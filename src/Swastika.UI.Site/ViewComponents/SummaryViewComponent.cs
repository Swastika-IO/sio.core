using System.Threading.Tasks;
using Swastika.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Swastika.UI.Site.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        /// <summary>
        /// The notifications{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryViewComponent" /> class.
        /// </summary>
        /// <param name="notifications">The notifications.</param>
        public SummaryViewComponent(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult((_notifications.GetNotifications()));
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}