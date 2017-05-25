using AutoMapper;
using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Events;
using Swastika.Domain.Core.Notifications;
using Swastika.Infrastructure.CrossCutting.Bus;
using Swastika.Infrastructure.CrossCutting.Identity.Authorization;
using Swastika.Infrastructure.CrossCutting.Identity.Models;
using Swastika.Infrastructure.CrossCutting.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swastika.Extension.Customer.Application.Interfaces;
using Swastika.Extension.Customer.Application.Services;
using Swastika.Extension.Customer.Domain.Events;
using Swastika.Extension.Customer.Domain.EventHandlers;
using Swastika.Extension.Customer.Domain.Commands;
using Swastika.Extension.Customer.Domain.CommandHandlers;
using Swastika.Extension.Customer.Domain.Interfaces;
using Swastika.Extension.Customer.Infrastructure.Data.Repository;
using Swastika.Extension.Customer.Infrastructure.Data.UoW;
using Swastika.Extension.Customer.Infrastructure.Data.Context;
using Swastika.Domain.Interfaces;
using Swastika.Infrastructure.Data.Repository.EventSourcing;
using Swastika.Infrastructure.Data.EventSourcing;
using Swastika.Infrastructure.Data.Context;

namespace Swastika.Infrastructure.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            // Customer
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // Customer
            services.AddScoped<IHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            // Customer
            services.AddScoped<IHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            // Customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SwastikaExtensionCustomerContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}