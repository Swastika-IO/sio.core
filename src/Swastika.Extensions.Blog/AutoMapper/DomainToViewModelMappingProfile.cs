using AutoMapper;
using Swastika.Extension.Blog.Models;
using Swastika.Extension.Blog.ViewModels;

namespace Swastika.Extension.Blog.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Models.Blog, BlogViewModel>();
        }
    }
}
