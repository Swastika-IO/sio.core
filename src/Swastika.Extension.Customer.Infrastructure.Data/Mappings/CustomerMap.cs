using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swastika.Extension.Customer.Domain.Models;
//using Swastika.Extension.Customer.Infrastructure.Data.Extensions;
using Swastika.Infrastructure.Data.Extensions;

namespace Swastika.Extension.Customer.Infrastructure.Data.Mappings
{    
    public class CustomerMap : EntityTypeConfiguration<Domain.Models.Customer>
    {
        /// <summary>
        /// Maps the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Map(EntityTypeBuilder<Domain.Models.Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}