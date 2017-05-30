using System;
using System.Collections.Generic;
using AutoMapper;
using Swastika.Extension.Customer.Application.EventSourcedNormalizers;
using Swastika.Extension.Customer.Application.Interfaces;
using Swastika.Extension.Customer.Application.ViewModels;
using Swastika.Domain.Core.Bus;
using Swastika.Extension.Customer.Domain.Interfaces;
using Swastika.Extension.Customer.Domain.Commands;
using Swastika.Infrastructure.Data.Repository.EventSourcing;

namespace Swastika.Extension.Customer.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        /// <summary>
        /// The mapper{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The customer repository{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly ICustomerRepository _customerRepository;
        /// <summary>
        /// The event store repository{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IEventStoreRepository _eventStoreRepository;
        /// <summary>
        /// The bus{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly IBus Bus;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAppService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="bus">The bus.</param>
        /// <param name="eventStoreRepository">The event store repository.</param>
        public CustomerAppService(IMapper mapper,
                                          ICustomerRepository customerRepository,
                                          IBus bus,
                                          IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.GetAll());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        /// <summary>
        /// Registers the specified customer view model.
        /// </summary>
        /// <param name="customerViewModel">The customer view model.</param>
        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        /// <summary>
        /// Updates the specified customer view model.
        /// </summary>
        /// <param name="customerViewModel">The customer view model.</param>
        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            Bus.SendCommand(removeCommand);
        }

        /// <summary>
        /// Gets all history.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<CustomerHistoryData> GetAllHistory(Guid id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
