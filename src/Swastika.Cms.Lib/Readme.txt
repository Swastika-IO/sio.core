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

Scaffold-DbContext "Server=115.77.190.113,4444;Database=Stag_swastika_io;UID=sa;Pwd=sqlP@ssw0rd;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force

swastika.io:3333
smileway\hoang.nguyen
1234qwe@