using Swastika.Domain.Core.Commands;
using Swastika.Domain.Core.Events;

namespace Swastika.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}