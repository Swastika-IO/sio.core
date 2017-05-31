using Microsoft.Extensions.DependencyInjection;
using Swastika.Domain.Core.Events;
using Swastika.Domain.Interfaces;
using Swastika.Extension.Blog.Application.Interfaces;
using Swastika.Extension.Blog.Application.Services;
using Swastika.Extension.Blog.Domain.CommandHandlers;
using Swastika.Extension.Blog.Domain.Commands;
using Swastika.Extension.Blog.Domain.EventHandlers;
using Swastika.Extension.Blog.Domain.Events;
using Swastika.Extension.Blog.Domain.Interfaces;
using Swastika.Extension.Blog.Infrastructure.Data.Context;
using Swastika.Extension.Blog.Infrastructure.Data.Repository;
using Swastika.Extension.Blog.Infrastructure.Data.UoW;
using Swastika.UI.Base.Extensions;

namespace Swastika.Extension.Blog.UI.Site
{
    public class Startup : IExtensionStartup
    {
        public void ExtensionStartup(IServiceCollection serviceCollection)
        {
            ConfigureServices(serviceCollection);
        }
        public void ConfigureServices(IServiceCollection serviceCollection)
        {

            // Blog
            serviceCollection.AddScoped<IBlogAppService, BlogAppService>();

            // Domain - Events
            serviceCollection.AddScoped<IHandler<BlogRegisteredEvent>, BlogEventHandler>();
            serviceCollection.AddScoped<IHandler<BlogUpdatedEvent>, BlogEventHandler>();
            serviceCollection.AddScoped<IHandler<BlogRemovedEvent>, BlogEventHandler>();

            // Domain - Commands
            serviceCollection.AddScoped<IHandler<RegisterNewBlogCommand>, BlogCommandHandler>();
            serviceCollection.AddScoped<IHandler<UpdateBlogCommand>, BlogCommandHandler>();
            serviceCollection.AddScoped<IHandler<RemoveBlogCommand>, BlogCommandHandler>();

            // Infra - Data
            serviceCollection.AddScoped<IBlogRepository, BlogRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<SwastikaExtensionBlogContext>();
        }
    }
}
