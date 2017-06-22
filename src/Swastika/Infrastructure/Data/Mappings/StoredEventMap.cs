using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swastika.Infrastructure.Data.Extensions;
using Swastika.Domain.Core.Events;


namespace Swastika.Infrastructure.Data.Mappings
{    
    public class StoredEventMap : EntityTypeConfiguration<StoredEvent>
    {
        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Map(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");

        }
    }
}