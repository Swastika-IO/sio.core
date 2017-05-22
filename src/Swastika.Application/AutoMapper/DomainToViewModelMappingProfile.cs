using AutoMapper;
using Swastika.Application.ViewModels;
using Swastika.Domain.Models;

namespace Swastika.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
