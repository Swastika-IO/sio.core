using System.Threading.Tasks;

namespace Swastika.Infrastructure.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
