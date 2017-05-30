using AutoMapper;
using Swastika.Extension.Customer.Application.ViewModels;

namespace Swastika.Extension.Customer.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToViewModelMappingProfile" /> class.
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Models.Customer, CustomerViewModel>();
        }
    }
}
