https://fullstackmark.com/post/10/user-authentication-with-angular-and-asp-net-core

dotnet add package Automapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.AspNetCore.Mvc
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.sqlserver.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package FluentValidation.AspNetCore
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package System.IdentityModel.Tokens.Jwt

Add-Migration AddFirstName -Context ApplicationDbContext

Update-database -Context SiocCmsContext

Scaffold-DbContext "Server=115.77.190.113,4444;Database=sw_cms_structure;UID=tinku;Pwd=1234qwe@;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models\Cms -force
Scaffold-DbContext "Server=.\sqlexpress;Database=sw_cms;UID=sa;Pwd=1234qwe@;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force

/// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SiocCmsContext(DbContextOptions<SiocCmsContext> options)
                    : base(options)
        {
        }

        public SiocCmsContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile(Common.Utility.Const.CONST_FILE_APPSETTING)
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString(SWCmsConstants.CONST_DEFAULT_CONNECTION));
        }

Swastika.:3333
smileway\hoang.nguyen
1234qwe@