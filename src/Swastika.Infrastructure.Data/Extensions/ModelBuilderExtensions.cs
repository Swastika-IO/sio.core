using Microsoft.EntityFrameworkCore;

namespace Swastika.Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Adds the configuration.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}