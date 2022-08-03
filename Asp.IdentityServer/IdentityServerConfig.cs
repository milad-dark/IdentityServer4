using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Asp.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("roles","role list", new List<string>(){"role"})
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("yourcustomapi", "Your Custom Api"),
                new ApiScope("yourotherapi", "Your Other Api"),

            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("yourcustomapi", "Your Custom Api"),
                new ApiResource("yourotherapi", "Your Other Api"),

            };
        }

        public static IEnumerable<Client> GetClients()
        {
            //client credential client
            return new List<Client>
            {
                //resource owner password grant client
                new Client
                {
                    ClientId="YourCustomApi",
                    AllowedGrantTypes = GrantTypes.Code, //Code for OpenId, ClientCredentials for JWT
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris = new List<string>{"http://localhost:44386/"}, //For Facebook OpenId
                    AllowedScopes = new List<string>()
                    {
                        "yourcustomapi",
                        StandardScopes.OfflineAccess,
                        "yourotherapi",
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        "roles"
                    },
                }
            };
        }
    }

    
}
