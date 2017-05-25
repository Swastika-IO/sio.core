using System.Threading.Tasks;
using Swastika.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Swastika.Extension.Customer.UI.Site.ViewComponents
{
    public class CustomerSummaryViewComponent : ViewComponent
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CustomerSummaryViewComponent(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult((_notifications.GetNotifications()));
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}