using AutoMapper;
using Swastika.Extensions.BlogExt.Lib.Models;
using Swastika.Extensions.BlogExt.Lib.ViewModels;

namespace Swastika.Extensions.BlogExt.Lib.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Blog, BlogViewModel>();
        }
    }
}
