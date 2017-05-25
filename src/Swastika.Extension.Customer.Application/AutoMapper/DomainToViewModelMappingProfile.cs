using AutoMapper;
using Swastika.Extension.Customer.Application.ViewModels;

namespace Swastika.Extension.Customer.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Models.Customer, CustomerViewModel>();
        }
    }
}
