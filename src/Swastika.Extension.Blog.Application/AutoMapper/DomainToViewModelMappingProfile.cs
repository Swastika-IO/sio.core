using AutoMapper;
using Swastika.Extension.Blog.Application.ViewModels;

namespace Swastika.Extension.Blog.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Models.Blog, BlogViewModel>();
        }
    }
}
