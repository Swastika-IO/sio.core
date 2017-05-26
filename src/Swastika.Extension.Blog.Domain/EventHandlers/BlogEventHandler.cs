using Swastika.Domain.Core.Events;
using Swastika.Extension.Blog.Domain.Events;

namespace Swastika.Extension.Blog.Domain.EventHandlers
{
    public class BlogEventHandler :
        IHandler<BlogRegisteredEvent>,
        IHandler<BlogUpdatedEvent>,
        IHandler<BlogRemovedEvent>
    {
        public void Handle(BlogUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(BlogRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(BlogRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}