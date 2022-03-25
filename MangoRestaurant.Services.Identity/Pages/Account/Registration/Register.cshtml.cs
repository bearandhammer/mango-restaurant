using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Services.Identity.Pages.Account.Registration
{
    public class RegisterModel : PageModel
    {
        private readonly IIdentityServerInteractionService interaction;

        private readonly IAuthenticationSchemeProvider schemeProvider;

        private readonly IClientStore clientStore;

        public RegisterModel(
            IIdentityServerInteractionService interactionType,
            IAuthenticationSchemeProvider schemeProviderType
            IClientStore clientStoreType)
        {
            interaction = interactionType;
            schemeProvider = schemeProviderType;
            clientStore = clientStoreType;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        public async Task<IActionResult> OnGet(string returnUrl)
        {
            RegisterViewModel = new RegisterViewModel();
            RegisterViewModel.Roles = GetPredefinedApplicationRoles();       
            
            AuthorizationRequest context = await interaction.GetAuthorizationContextAsync(returnUrl);

            if (context?.IdP != null && await schemeProvider.GetSchemeAsync(context.IdP) != null)
            {
                bool isLocal = context.IdP == Duende.IdentityServer.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                RegisterViewModel.EnableLocalLogin = isLocal;
                RegisterViewModel.ReturnUrl = returnUrl;
                RegisterViewModel.Username = context?.LoginHint;

                // TODO - Setup External Providers
                //if (!local)
                //{
                //    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
                //}

                return Page();
            }

            IEnumerable<AuthenticationScheme> schemes = await schemeProvider.GetAllSchemesAsync();

            // TODO - Allow External Providers
            //var providers = schemes
            //    .Where(x => x.DisplayName != null)
            //    .Select(x => new ExternalProvider
            //    {
            //        DisplayName = x.DisplayName ?? x.Name,
            //        AuthenticationScheme = x.Name
            //    }).ToList();

            bool allowLocal = true;
            if (context?.Client.ClientId != null)
            {
                Client client = await clientStore.FindEnabledClientByIdAsync(context.Client.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        // TODO: Allow providers
                        //providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return Page();
        }

        private static List<string> GetPredefinedApplicationRoles() =>
            new List<string>
            {
                "Admin"
                , "Customer"
            };

        // TODO: Lift of register code from quick start templates (for MVC) - to reverse engineer
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    if (ModelState.IsValid)
        //    {

        //        var user = new ApplicationUser
        //        {
        //            UserName = model.Username,
        //            Email = model.Email,
        //            EmailConfirmed = true,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName
        //        };

        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            if (!_roleManager.RoleExistsAsync(model.RoleName).GetAwaiter().GetResult())
        //            {
        //                var userRole = new IdentityRole
        //                {
        //                    Name = model.RoleName,
        //                    NormalizedName = model.RoleName,

        //                };
        //                await _roleManager.CreateAsync(userRole);
        //            }

        //            await _userManager.AddToRoleAsync(user, model.RoleName);

        //            await _userManager.AddClaimsAsync(user, new Claim[]{
        //                    new Claim(JwtClaimTypes.Name, model.Username),
        //                    new Claim(JwtClaimTypes.Email, model.Email),
        //                    new Claim(JwtClaimTypes.FamilyName, model.FirstName),
        //                    new Claim(JwtClaimTypes.GivenName, model.LastName),
        //                    new Claim(JwtClaimTypes.WebSite, "http://"+model.Username+".com"),
        //                    new Claim(JwtClaimTypes.Role,"User") });

        //            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
        //            var loginresult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: true);
        //            if (loginresult.Succeeded)
        //            {
        //                var checkuser = await _userManager.FindByNameAsync(model.Username);
        //                await _events.RaiseAsync(new UserLoginSuccessEvent(checkuser.UserName, checkuser.Id, checkuser.UserName, clientId: context?.Client.ClientId));

        //                if (context != null)
        //                {
        //                    if (context.IsNativeClient())
        //                    {
        //                        // The client is native, so this change in how to
        //                        // return the response is for better UX for the end user.
        //                        return this.LoadingPage("Redirect", model.ReturnUrl);
        //                    }

        //                    // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
        //                    return Redirect(model.ReturnUrl);
        //                }

        //                // request for a local page
        //                if (Url.IsLocalUrl(model.ReturnUrl))
        //                {
        //                    return Redirect(model.ReturnUrl);
        //                }
        //                else if (string.IsNullOrEmpty(model.ReturnUrl))
        //                {
        //                    return Redirect("~/");
        //                }
        //                else
        //                {
        //                    // user might have clicked on a malicious link - should be logged
        //                    throw new Exception("invalid return URL");
        //                }
        //            }

        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}
        //private async Task<RegisterViewModel> BuildRegisterViewModelAsync(string returnUrl)
        //{
        //    var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
        //    List<string> roles = new List<string>();
        //    roles.Add("Admin");
        //    roles.Add("Customer");
        //    ViewBag.message = roles;
        //    if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
        //    {
        //        var local = context.IdP == Duende.IdentityServer.IdentityServerConstants.LocalIdentityProvider;

        //        // this is meant to short circuit the UI and only trigger the one external IdP
        //        var vm = new RegisterViewModel
        //        {
        //            EnableLocalLogin = local,
        //            ReturnUrl = returnUrl,
        //            Username = context?.LoginHint,
        //        };

        //        if (!local)
        //        {
        //            vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
        //        }

        //        return vm;
        //    }

        //    var schemes = await _schemeProvider.GetAllSchemesAsync();

        //    var providers = schemes
        //        .Where(x => x.DisplayName != null)
        //        .Select(x => new ExternalProvider
        //        {
        //            DisplayName = x.DisplayName ?? x.Name,
        //            AuthenticationScheme = x.Name
        //        }).ToList();

        //    var allowLocal = true;
        //    if (context?.Client.ClientId != null)
        //    {
        //        var client = await _clientStore.FindEnabledClientByIdAsync(context.Client.ClientId);
        //        if (client != null)
        //        {
        //            allowLocal = client.EnableLocalLogin;

        //            if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
        //            {
        //                providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
        //            }
        //        }
        //    }

        //    return new RegisterViewModel
        //    {
        //        AllowRememberLogin = AccountOptions.AllowRememberLogin,
        //        EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
        //        ReturnUrl = returnUrl,
        //        Username = context?.LoginHint,
        //        ExternalProviders = providers.ToArray()
        //    };
        //}
    }
}
