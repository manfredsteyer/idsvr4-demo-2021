using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4Demo
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "Demo API")
                {
                    Enabled = true,
                    ApiSecrets = { new Secret("secret".Sha256()) }
                },

                // PolicyServer demo
                new ApiResource("policyserver.runtime"),
                new ApiResource("policyserver.management")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    Enabled = true,
                    ClientId = "spa",
                    ClientName = "SPA (Code + PKCE)",

                    RequireClientSecret = false,
                    RequireConsent = true,

                    RedirectUris = { 
                        "http://localhost:4200/index.html",
                        "http://localhost:4201/index.html",
                        "http://localhost:4202/index.html",
                        "http://localhost:4203/index.html",
                        "http://localhost:4204/index.html",
                        "http://localhost:8080/index.html",
                        "http://localhost:8081/index.html"

                    },
                    PostLogoutRedirectUris = { 
                        "http://localhost:4200/index.html",
                        "http://localhost:4201/index.html",
                        "http://localhost:4202/index.html",
                        "http://localhost:4203/index.html",
                        "http://localhost:4204/index.html",
                        "http://localhost:8080/index.html",
                        "http://localhost:8081/index.html"
                    },

                    RequirePkce = true,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "email", "api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    
                    // For testing purpose we are using different life times
                    AccessTokenLifetime = 60 * 10,
                    IdentityTokenLifetime = 60 * 20,
                },

                new Client
                {
                    Enabled = true,

                    ClientId = "code",
                    ClientName = "Code Flow + PKCE",

                    ClientSecrets = {
                        new Secret("123456".Sha256(), new System.DateTime(2400, 1, 1))
                    },

                    RequireConsent = true,

                    RedirectUris = { 
                        "http://localhost:8080",
                        "http://localhost:8081",
                        "http://localhost:8082",
                        "http://localhost:8083",
                        "http://localhost:8084",

                    },
                    PostLogoutRedirectUris = { 
                        "http://localhost:8080",
                        "http://localhost:8081",
                        "http://localhost:8082",
                        "http://localhost:8083",
                        "http://localhost:8084",
                    },

                    RequirePkce = true,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "email", "api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    
                    // For testing purpose we are using different life times
                    AccessTokenLifetime = 60 * 10,
                    IdentityTokenLifetime = 60 * 20,
                },

                // implicit (e.g. SPA or OIDC authentication)
                new Client
                {
                        Enabled = true,

                    ClientId = "implicit",
                    ClientName = "Implicit Client",
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    // For testing purpose we are using different life times
                    AccessTokenLifetime = 60 * 10,
                    IdentityTokenLifetime = 60 * 20,

                    RedirectUris = { 
                        "http://localhost:4200/index.html",
                        "http://localhost:4201/index.html",
                        "http://localhost:4202/index.html",
                        "http://localhost:4203/index.html",
                        "http://localhost:4204/index.html",
                        "http://localhost:4200/silent-refresh.html",
                        "http://localhost:4201/silent-refresh.html",
                        "http://localhost:4202/silent-refresh.html",
                        "http://localhost:4203/silent-refresh.html",
                        "http://localhost:4204/silent-refresh.html",

                    },
                    PostLogoutRedirectUris = { 
                        "http://localhost:4200/index.html",
                        "http://localhost:4201/index.html",
                        "http://localhost:4202/index.html",
                        "http://localhost:4203/index.html",
                        "http://localhost:4204/index.html"
                    },
                    
                    FrontChannelLogoutUri = "http://localhost:5000/signout-idsrv", // for testing identityserver on localhost

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api" },
                },

            };
        }
    }
}
