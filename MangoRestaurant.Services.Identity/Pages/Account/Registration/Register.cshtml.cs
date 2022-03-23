using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Services.Identity.Pages.Account.Registration
{
    public class RegisterModel : PageModel
    {
        private readonly IIdentityServerInteractionService interaction;

        public RegisterModel(
            IIdentityServerInteractionService interactionType)
        {
            interaction = interactionType;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        public async Task OnGet(string returnUrl)
        {
            AuthorizationRequest context = await interaction.GetAuthorizationContextAsync(returnUrl);

            List<string> roles = GetPredefinedApplicationRoles();
        }

        private static List<string> GetPredefinedApplicationRoles() =>
            new List<string>
            {
                "Admin"
                , "Customer"
            };
    }
}
