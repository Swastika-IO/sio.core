using System.Threading.Tasks;

namespace Swastika.Infrastructure.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string message);
    }
}
