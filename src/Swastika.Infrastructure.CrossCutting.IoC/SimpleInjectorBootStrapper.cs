using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Events;
using Swastika.Domain.Core.Notifications;
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
using Swastika.Extension.Customer.Infrastructure.Data.UoW;
using Swastika.Infrastructure.CrossCutting.Bus;
using Swastika.Infrastructure.CrossCutting.Identity.Authorization;
using Swastika.Infrastructure.CrossCutting.Identity.Models;
using Swastika.Infrastructure.CrossCutting.Identity.Services;
using Swastika.Infrastructure.Data.Context;
using Swastika.Infrastructure.Data.EventSourcing;
using Swastika.Infrastructure.Data.Repository.EventSourcing;

namespace Swastika.Infrastructure.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="serviceCollection">The services.</param>
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            // ASP.NET HttpContext dependency
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            serviceCollection.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            serviceCollection.AddSingleton(Mapper.Configuration);
            serviceCollection.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            
            // Blog
            serviceCollection.AddScoped<IBlogAppService, BlogAppService>();
            // Domain - Events
            serviceCollection.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
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

            // Infra - Data EventSourcing
            serviceCollection.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            serviceCollection.AddScoped<IEventStore, SqlEventStore>();
            serviceCollection.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            serviceCollection.AddTransient<IEmailSender, AuthEmailMessageSender>();
            serviceCollection.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            serviceCollection.AddScoped<IUser, AspNetUser>();

            // Infra - Bus
            serviceCollection.AddScoped<IBus, InMemoryBus>();
        }
    }
}