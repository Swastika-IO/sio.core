using System.IO;
using Swastika.Extension.Blog.Domain.Models;
using Swastika.Extension.Blog.Infrastructure.Data.Mappings;
using Swastika.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Swastika.Extension.Blog.Infrastructure.Data.Context
{
    public class SwastikaExtensionBlogContext : DbContext
    {
        private const string CONST_DEFAULT_CONNECTION = "DefaultConnection";
        private const string CONST_FILE_APPSETTING = "appsettings.json";
        public DbSet<Domain.Models.Blog> Blog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Ext");
            modelBuilder.AddConfiguration(new BlogMap());
                        
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
