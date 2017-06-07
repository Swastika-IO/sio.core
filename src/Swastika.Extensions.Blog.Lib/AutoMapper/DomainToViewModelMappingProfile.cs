using AutoMapper;
using Swastika.Extension.Blog.ViewModels;

namespace Swastika.Extension.Blog.AutoMapper {

    /// <summary>
    /// Domain to View Model mapping profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class DomainToViewModelMappingProfile : Profile {

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToViewModelMappingProfile" /> class.
        /// </summary>
        public DomainToViewModelMappingProfile() {
            CreateMap<Models.Blog, BlogViewModel>();
        }
    }
}