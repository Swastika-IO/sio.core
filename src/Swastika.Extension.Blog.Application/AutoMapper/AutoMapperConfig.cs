using AutoMapper;

namespace Swastika.Extension.Blog.Application.AutoMapper
{
    public class AutoMapperConfig
    {
               
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
