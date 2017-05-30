using System.Threading.Tasks;

namespace Swastika.Infrastructure.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        /// <summary>
        /// Sends the SMS asynchronous.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task SendSmsAsync(string number, string message);
    }
}
