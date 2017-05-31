using System.IO;
using Swastika.Domain.Core.Events;
using Swastika.Infrastructure.Data.Mappings;
using Swastika.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Swastika.Common.Utility;

namespace Swastika.Infrastructure.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        /// <summary>
        /// Gets or sets the stored event.
        /// </summary>
        /// <value>
        /// The stored event.
        /// </value>
        public DbSet<StoredEvent> StoredEvent { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Called when [configuring].
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Const.CONST_FILE_APPSETTING)
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString(Const.CONST_DEFAULT_CONNECTION));
        }
    }
}