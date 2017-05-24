using System.IO;
using Swastika.Domain.Models;
using Swastika.Infrastructure.Data.Mappings;
using Swastika.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Swastika.Infrastructure.Data.Context
{
    public class SwastikaContext : DbContext
    {
        private const string CONST_DEFAULT_CONNECTION = "DefaultConnection";
        private const string CONST_FILE_APPSETTING = "appsettings.json";
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CustomerMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(CONST_FILE_APPSETTING)
                .Build();
            
            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString(CONST_DEFAULT_CONNECTION));
        }
    }
}
