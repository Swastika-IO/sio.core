using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swastika.Infrastructure.Data.Extensions;

namespace Swastika.Extension.Blog.AutoMapper {

    /// <summary>
    /// Blog Map Class
    /// </summary>
    /// <seealso cref="Swastika.Infrastructure.Data.Extensions.EntityTypeConfiguration{Swastika.Extension.Blog.Models.Blog}" />
    public class BlogMap : EntityTypeConfiguration<Models.Blog> {

        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="entityTypeBuilder">The builder.</param>
        public override void Map(EntityTypeBuilder<Models.Blog> entityTypeBuilder) {
            entityTypeBuilder.Property(c => c.Id)
                .HasColumnName("BlogId");

            entityTypeBuilder.Property(c => c.Name)
                .HasColumnName("Name");

            entityTypeBuilder.Property(c => c.Title)
                .HasColumnName("Title");

            entityTypeBuilder.Property(c => c.Slug)
                .HasColumnName("Slug");

            entityTypeBuilder.Property(c => c.Description)
                .HasColumnName("Description");

            entityTypeBuilder.Property(c => c.CreatedUtc)
                .HasColumnName("CreatedUtc");

            entityTypeBuilder.Property(c => c.ModifiedUtc)
                .HasColumnName("ModifiedUtc");

            entityTypeBuilder.Property(c => c.PublishedUtc)
                .HasColumnName("PublishedUtc");

            entityTypeBuilder.Property(c => c.CreatedByUserId)
                .HasColumnName("CreatedByUserId");

            entityTypeBuilder.Property(c => c.CommonStatusId)
                .HasColumnName("CommonStatusId");
        }
    }
}