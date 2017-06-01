using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swastika.Infrastructure.Data.Extensions;

namespace Swastika.Extensions.BlogExt.Lib.AutoMapper
{
    public class BlogMap : EntityTypeConfiguration<Models.Blog>
    {
        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Map(EntityTypeBuilder<Models.Blog> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("BlogId");
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
