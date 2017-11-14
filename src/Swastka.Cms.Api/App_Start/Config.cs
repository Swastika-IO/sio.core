using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swastka.Cms.Api
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
        {
            new ApiResource("apiApp", "API Application")
        };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "clientApp",
 
                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,
 
                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
 
                // scopes that client has access to
                AllowedScopes = { "apiApp" }
            }
        };
        }
    }
}
