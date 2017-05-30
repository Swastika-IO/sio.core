using System.IO;
using Swastika.Infrastructure.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Swastika.Infrastructure.CrossCutting.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// The constant file appsetting{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_FILE_APPSETTING = "appsettings.json";
        /// <summary>
        /// The constant default connection{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_DEFAULT_CONNECTION = "DefaultConnection";

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        public ApplicationDbContext()
        {

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
                .AddJsonFile(CONST_FILE_APPSETTING)
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString(CONST_DEFAULT_CONNECTION));
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
