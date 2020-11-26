using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "My API"),
                new ApiScope
                {
                    Name = "read",
                    DisplayName = "Read",
                    Description = "Read information"
                },
                new ApiScope
                {
                    Name = "write",
                    DisplayName = "Write",
                    Description = "Write information"
                }
            };

        public static ICollection<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "Default API",
                    Scopes = new [] {"read","write"},
                    UserClaims = new [] { ClaimTypes.NameIdentifier, ClaimTypes.Email, ClaimTypes.Name }
                }
            };
        
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {                
                // interactive ASP.NET Core MVC client
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientSecrets = { new Secret("secret".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,
                    
                //    // where to redirect to after login
                //    RedirectUris = { "https://localhost:5002/signin-oidc" },

                //    // where to redirect to after logout
                //    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "api1"
                //    }
                //},

                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { "https://localhost:5000/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5000/index.html" },
                    AllowedCorsOrigins =     { "https://localhost:5000" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
            };
    }
}
