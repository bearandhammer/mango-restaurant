using Duende.IdentityServer.Models;

namespace MangoRestaurant.Services.Identity.Utilities
{
    public static class IdentityHelper
    {
        public const string AdminRole = "Admin";

        public const string CustomerRole = "Customer";

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
                new ApiScope("Mango", "MangoServer"),
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
                }
            };
    }
}
