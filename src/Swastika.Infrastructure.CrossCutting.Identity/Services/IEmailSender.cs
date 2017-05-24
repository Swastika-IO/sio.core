using System.Threading.Tasks;

namespace Swastika.Infrastructure.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
