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

        public async void OnGet()
        {
            
        }
    }
}
