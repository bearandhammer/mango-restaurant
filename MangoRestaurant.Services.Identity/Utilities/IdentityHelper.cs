using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MangoRestaurant.Services.Identity.Utilities
{
    public static class IdentityHelper
    {
        public const string AdminRole = "Admin";

        public const string CustomerRole = "Customer";

        private const string MangoScope = "mango";

        // TODO: Readjust this
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        // TODO Scopes. Again, to adjust
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope(MangoScope, "MangoServer"),
                new ApiScope("read", "Read your data."),
                new ApiScope("write", "Write your data"),
                new ApiScope("delete", "Delete your data")
            };

        // Clients - e.g. Web, Desktop or Mobile applications
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    // Not for production, of course
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "mango",
                    // Not for production, of course
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:25549/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:25549/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        MangoScope
                    }
                }
            };
    }
}
