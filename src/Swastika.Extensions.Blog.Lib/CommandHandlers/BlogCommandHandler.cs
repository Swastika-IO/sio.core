using Swastika.Domain.Core.CommandHandlers;
using Swastika.Domain.Core.Events;
using System;
using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Notifications;
using Swastika.Domain.Core.Interfaces;

namespace Swastika.Extension.Blog.CommandHandlers
{
    public class BlogCommandHandler : CommandHandler
    {
        //    IHandler<RegisterNewBlogCommand>,
        //    IHandler<UpdateBlogCommand>,
        //    IHandler<RemoveBlogCommand>
        //{
        //    private readonly IBlogRepository _blogRepository;
        //    private readonly IBus Bus;

        //    public BlogCommandHandler(IBlogRepository blogRepository,
        //                                  IUnitOfWork uow,
        //                                  IBus bus,
        //                                  IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        //    {
        //        _blogRepository = blogRepository;
        //        Bus = bus;
        //    }

        //    public void Handle(RegisterNewBlogCommand message)
        //    {
        //        if (!message.IsValid())
        //        {
        //            NotifyValidationErrors(message);
        //            return;
        //        }

        //        Models.Blog blog = new Models.Blog(Guid.NewGuid(), message.Name, message.Title, message.Slug, message.Description, message.CreatedUtc, message.ModifiedUtc, message.PublishedUtc, message.CreatedByUserId, message.CommonStatusId);

        //        if (_blogRepository.GetByName(blog.Name) != null)
        //        {
        //            Bus.RaiseEvent(new DomainNotification(message.MessageType, "The blog name has already been taken."));
        //            return;
        //        }

        //        _blogRepository.Add(blog);

        //        if (Commit())
        //        {
        //            Bus.RaiseEvent(new BlogRegisteredEvent(blog.Id, blog.Name, blog.Title, blog.Slug, blog.Description, blog.CreatedUtc, blog.ModifiedUtc, blog.PublishedUtc, blog.CreatedByUserId, blog.CommonStatusId));
        //        }
        //    }

        //    public void Handle(UpdateBlogCommand message)
        //    {
        //        if (!message.IsValid())
        //        {
        //            NotifyValidationErrors(message);
        //            return;
        //        }

        //        var blog = new Models.Blog(message.Id, message.Name, message.Title, message.Slug, message.Description, message.CreatedUtc, message.ModifiedUtc, message.PublishedUtc, message.CreatedByUserId, message.CommonStatusId);
        //        var existingBlog = _blogRepository.GetByName(blog.Name);

        //        if (existingBlog != null)
        //        {
        //            if (!existingBlog.Equals(blog))
        //            {
        //                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The blog name has already been taken."));
        //                return;
        //            }
        //        }

        //        _blogRepository.Update(blog);

        //        if (Commit())
        //        {
        //            Bus.RaiseEvent(new BlogUpdatedEvent(blog.Id, blog.Name, blog.Title, blog.Slug, blog.Description, blog.CreatedUtc, blog.ModifiedUtc, blog.PublishedUtc, blog.CreatedByUserId, blog.CommonStatusId));
        //        }
        //    }

        //    public void Handle(RemoveBlogCommand message)
        //    {
        //        if (!message.IsValid())
        //        {
        //            NotifyValidationErrors(message);
        //            return;
        //        }

        //        _blogRepository.Remove(message.Id);

        //        if (Commit())
        //        {
        //            Bus.RaiseEvent(new BlogRemovedEvent(message.Id));
        //        }
        //    }

        //    public void Dispose()
        //    {
        //        _blogRepository.Dispose();
        //    }
        public BlogCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }
    }
}
