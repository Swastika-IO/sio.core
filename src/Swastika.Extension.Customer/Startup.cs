using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Swastika.Domain.Core.Events;
using Swastika.Domain.Interfaces;
using Swastika.Extension.Customer.Application.AutoMapper;
using Swastika.Extension.Customer.Application.Interfaces;
using Swastika.Extension.Customer.Application.Services;
using Swastika.Extension.Customer.Domain.CommandHandlers;
using Swastika.Extension.Customer.Domain.Commands;
using Swastika.Extension.Customer.Domain.EventHandlers;
using Swastika.Extension.Customer.Domain.Events;
using Swastika.Extension.Customer.Domain.Interfaces;
using Swastika.Extension.Customer.Infrastructure.Data.Context;
using Swastika.Extension.Customer.Infrastructure.Data.Repository;
using Swastika.Extension.Customer.Infrastructure.Data.UoW;
using Swastika.Infrastructure.CrossCutting.Identity.Authorization;
using Swastika.UI.Base.Extensions;

namespace Swastika.Extension.Customer
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Swastika.UI.Base.Extensions.IExtensionStartup" />
    public class Startup : IExtensionStartup
    {

        /// <summary>
        /// The constant authentication policy canwritecustomerdata
        /// </summary>
        public const string CONST_AUTH_POLICY_CANWRITECUSTOMERDATA = "CanWriteCustomerData";
        /// <summary>
        /// The constant authentication policy canremovecustomerdata
        /// </summary>
        public const string CONST_AUTH_POLICY_CANREMOVECUSTOMERDATA = "CanRemoveCustomerData";

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            // Do something on startup
        }

        /// <summary>
        /// Extensions the startup.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public void ExtensionStartup(IServiceCollection serviceCollection)
        {
            AddAuthorization(serviceCollection);
            ConfigureServices(serviceCollection);
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Customer
            serviceCollection.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            serviceCollection.AddScoped<IHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            serviceCollection.AddScoped<IHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            serviceCollection.AddScoped<IHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            serviceCollection.AddScoped<IHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            serviceCollection.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            serviceCollection.AddScoped<IHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<SwastikaExtensionCustomerContext>();
        }

        public void AddAuthorization(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy(CONST_AUTH_POLICY_CANWRITECUSTOMERDATA, policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Write")));
                options.AddPolicy(CONST_AUTH_POLICY_CANREMOVECUSTOMERDATA, policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
            });
        }
    }
}
