using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Swastika.Cms.Lib.Services;
using Swastika.Identity.Data;

namespace Swastika.Cms.Lib.Models.Account
{
    public partial class SiocCmsAccountContext : ApplicationDbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile(Common.Utility.Const.CONST_FILE_APPSETTING)
                .Build();

            // define the database to use

            optionsBuilder.UseSqlServer(GlobalConfigurationService.Instance.GetConnectionString());
            //optionsBuilder.UseSqlServer(config.GetConnectionString("AccountConnection"));

        }
        
    }
}
