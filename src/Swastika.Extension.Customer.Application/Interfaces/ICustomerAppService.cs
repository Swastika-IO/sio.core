using System;
using System.Collections.Generic;
using Swastika.Extension.Customer.Application.EventSourcedNormalizers;
using Swastika.Extension.Customer.Application.ViewModels;

namespace Swastika.Extension.Customer.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
