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
            RegisterViewModel = new RegisterViewModel();
            
            AuthorizationRequest context = await interaction.GetAuthorizationContextAsync(returnUrl);

            RegisterViewModel.Roles = GetPredefinedApplicationRoles();       
        }

        private static List<string> GetPredefinedApplicationRoles() =>
            new List<string>
            {
                "Admin"
                , "Customer"
            };
    }
}
