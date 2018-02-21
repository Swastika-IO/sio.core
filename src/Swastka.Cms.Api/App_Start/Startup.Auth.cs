// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Swastka.Cms.Api
{
    public partial class Startup
    {
        public static void ConfigureApi(
            IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
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
