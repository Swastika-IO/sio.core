// Licensed to the Sio I/O Foundation under one or more agreements.
// The Sio I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sio.Cms.Lib.Services;
using Sio.Identity.Entities;
using Sio.Identity.Models;

namespace Sio.Cms.Lib.Models.Account
{
    public class SioDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SioDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SioDbContext(DbContextOptions<SioDbContext> options)
                    : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SioDbContext" /> class.
        /// </summary>
        public SioDbContext()
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string cnn = SioService.GetConnectionString(SioConstants.CONST_CMS_CONNECTION);
            if (!string.IsNullOrEmpty(cnn))
            {
                if (SioService.GetConfig<bool>("IsSqlite"))
                {
                    optionsBuilder.UseSqlite(cnn);
                }
                else
                {
                    optionsBuilder.UseSqlServer(cnn);
                }
            }
        }
    }
}
