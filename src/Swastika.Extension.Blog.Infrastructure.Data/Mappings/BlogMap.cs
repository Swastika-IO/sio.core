using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swastika.Extension.Blog.Domain.Models;
//using Swastika.Extension.Blog.Infrastructure.Data.Extensions;
using Swastika.Infrastructure.Data.Extensions;

namespace Swastika.Extension.Blog.Infrastructure.Data.Mappings
{    
    public class BlogMap : EntityTypeConfiguration<Domain.Models.Blog>
    {
        public override void Map(EntityTypeBuilder<Domain.Models.Blog> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
            builder.Property(c => c.Name)
                            .HasColumnName("Name");
            builder.Property(c => c.Title)
                            .HasColumnName("Title");
            builder.Property(c => c.Slug)
                            .HasColumnName("Slug");
            builder.Property(c => c.Description)
                            .HasColumnName("Description");
            builder.Property(c => c.CreatedUtc)
                            .HasColumnName("CreatedUtc");
            builder.Property(c => c.ModifiedUtc)
                            .HasColumnName("ModifiedUtc");
            builder.Property(c => c.PublishedUtc)
                            .HasColumnName("PublishedUtc");
            builder.Property(c => c.CreatedByUserId)
                            .HasColumnName("CreatedByUserId");
            builder.Property(c => c.CommonStatusId)
                            .HasColumnName("CommonStatusId");

        }
    }
}