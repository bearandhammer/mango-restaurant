using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Services.Identity.Pages.Account.Register
{
    public class RegistercshtmlModel : PageModel
    {
        private readonly IIdentityServerInteractionService interaction;

        public RegistercshtmlModel(
            IIdentityServerInteractionService interactionType)
        {
            interaction = interactionType;
        }

        public async void OnGet()
        {
            
        }
    }
}
