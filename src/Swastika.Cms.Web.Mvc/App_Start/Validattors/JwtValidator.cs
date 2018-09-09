using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.Cms.Web.Mvc.App_Start.Validattors
{
    public class JwtValidator
    {
        public static async Task ValidateAsync(TokenValidatedContext context)
        {
            // Do sth before process  request with current principal
            // context.RejectPrincipal();
            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
        }

        public static async Task ValidateFailAsync(AuthenticationFailedContext context)
        {
            // Do sth when validate failed request with current principal
            // context.RejectPrincipal();
            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
            
        }
    }
}
