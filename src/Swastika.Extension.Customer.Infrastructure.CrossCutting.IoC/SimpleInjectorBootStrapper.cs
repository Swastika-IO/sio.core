//using Microsoft.Extensions.DependencyInjection;
//using Swastika.Domain.Interfaces;
//using Swastika.Extension.Customer.Application.Interfaces;
//using Swastika.Extension.Customer.Application.Services;
//using Swastika.Extension.Customer.Domain.CommandHandlers;
//using Swastika.Extension.Customer.Domain.Commands;
//using Swastika.Extension.Customer.Domain.EventHandlers;
//using Swastika.Extension.Customer.Domain.Events;
//using Swastika.Extension.Customer.Domain.Interfaces;
//using Swastika.Extension.Customer.Infrastructure.Data.Context;
//using Swastika.Extension.Customer.Infrastructure.Data.Repository;
//using Swastika.Extension.Customer.Infrastructure.Data.UoW;
//using Swastika.Domain.Core.Events;

//namespace Swastika.Extension.Customer.Infrastructure.CrossCutting.IoC
//{
//    public class SimpleInjectorBootStrapper
//    {
//        /// <summary>
//        /// Registers the services.
//        /// </summary>
//        /// <param name="services">The services.</param>
//        public static void RegisterServices(IServiceCollection services)
//        {
//            // Customer
//            services.AddScoped<ICustomerAppService, CustomerAppService>();
//            // Domain - Events
//            services.AddScoped<IHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
//            services.AddScoped<IHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
//            services.AddScoped<IHandler<CustomerRemovedEvent>, CustomerEventHandler>();
//            // Domain - Commands
//            services.AddScoped<IHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
//            services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
//            services.AddScoped<IHandler<RemoveCustomerCommand>, CustomerCommandHandler>();
//            // Infra - Data
//            services.AddScoped<ICustomerRepository, CustomerRepository>();
//            services.AddScoped<IUnitOfWork, UnitOfWork>();
//            services.AddScoped<SwastikaExtensionCustomerContext>();

//        }
//    }
//}