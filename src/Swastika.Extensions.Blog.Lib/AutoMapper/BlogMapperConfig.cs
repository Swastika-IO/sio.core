using AutoMapper;

namespace Swastika.Extension.Blog.AutoMapper {

    /// <summary>
    /// Auto Mapper Config Class
    /// </summary>
    public class AutoMapperConfig {

        /// <summary>
        /// Registers the mappings.
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMappings() {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}