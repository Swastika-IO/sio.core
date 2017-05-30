using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swastika.Infrastructure.Data.Extensions
{

    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}