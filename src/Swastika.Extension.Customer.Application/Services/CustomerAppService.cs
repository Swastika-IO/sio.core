using System;
using System.Collections.Generic;
using AutoMapper;
using Swastika.Extension.Customer.Application.EventSourcedNormalizers;
using Swastika.Extension.Customer.Application.Interfaces;
using Swastika.Extension.Customer.Application.ViewModels;
//using Swastika.Domain.Commands;
using Swastika.Domain.Core.Bus;
using Swastika.Extension.Customer.Domain.Interfaces;
//using Swastika.Extension.Customer.Infrastructure.Data.Repository.EventSourcing;
using Swastika.Extension.Customer.Domain.Commands;
using Swastika.Infrastructure.Data.Repository.EventSourcing;
//using Swastika.Domain.Interfaces;
//using Swastika.Infrastructure.Data.Repository.EventSourcing;

namespace Swastika.Extension.Customer.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

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

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.GetAll());
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<CustomerHistoryData> GetAllHistory(Guid id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
