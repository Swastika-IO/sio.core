using System;
using Swastika.Extension.Customer.Domain.Commands;
using Swastika.Domain.Core.Bus;
using Swastika.Domain.Core.Events;
using Swastika.Domain.Core.Notifications;
using Swastika.Extension.Customer.Domain.Events;
using Swastika.Extension.Customer.Domain.Interfaces;
using Swastika.Domain.Core.Interfaces;
using Swastika.Domain.Core.CommandHandlers;

namespace Swastika.Extension.Customer.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        IHandler<RegisterNewCustomerCommand>,
        IHandler<UpdateCustomerCommand>,
        IHandler<RemoveCustomerCommand>
    {
        /// <summary>
        /// The customer repository{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly ICustomerRepository _customerRepository;
        /// <summary>
        /// The bus{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IBus Bus;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandHandler" /> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="uow">The uow.</param>
        /// <param name="bus">The bus.</param>
        /// <param name="notifications">The notifications.</param>
        public CustomerCommandHandler(ICustomerRepository customerRepository,
                                              IUnitOfWork uow,
                                              IBus bus,
                                              IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(RegisterNewCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            Models.Customer customer = new Models.Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (_customerRepository.GetByEmail(customer.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                return;
            }

            _customerRepository.Add(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(UpdateCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Models.Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = _customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null)
            {
                if (!existingCustomer.Equals(customer))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                    return;
                }
            }

            _customerRepository.Update(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(RemoveCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}