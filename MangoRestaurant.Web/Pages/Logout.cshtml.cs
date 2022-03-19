using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Web.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
