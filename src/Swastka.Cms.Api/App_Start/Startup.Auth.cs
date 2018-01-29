using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swastka.Cms.Api
{
    public partial class Startup
    {
        public static void ConfigureApi(
            IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters =
                             new TokenValidationParameters
                             {
                                 ValidateIssuer = true,
                                 ValidateAudience = true,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,

                                 ValidIssuer = "Swastika.Security.Bearer",
                                 ValidAudience = "Swastika.Security.Bearer",
                                 IssuerSigningKey =
                                  JwtSecurityKey.Create("Swastikasecret")
                             };
                    });

            //services.AddMvc();
        }

        //public void Configure(
        //    IApplicationBuilder app,
        //    IHostingEnvironment env)
        //{
        //    app.UseAuthentication();

        //    app.UseMvcWithDefaultRoute();
        //}
    }
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
