using AutoMapper;
using Swastika.Extension.Blog.ViewModels;

namespace Swastika.Extension.Blog.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<BlogViewModel, RegisterNewBlogCommand>()
            //    .ConstructUsing(c => new RegisterNewBlogCommand(c.Name, c.Title, c.Slug, c.Description, c.CreatedUtc, c.ModifiedUtc, c.PublishedUtc, c.CreatedByUserId, c.CommonStatusId));
            //CreateMap<BlogViewModel, UpdateBlogCommand>()
            //    .ConstructUsing(c => new UpdateBlogCommand(c.Id, c.Name, c.Title, c.Slug, c.Description, c.CreatedUtc, c.ModifiedUtc, c.PublishedUtc, c.CreatedByUserId, c.CommonStatusId));
        }
    }
}
