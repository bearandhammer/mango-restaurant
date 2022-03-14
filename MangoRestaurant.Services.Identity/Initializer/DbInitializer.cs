using IdentityModel;
using MangoRestaurant.Services.Identity.Data;
using MangoRestaurant.Services.Identity.Initializer.Interfaces;
using MangoRestaurant.Services.Identity.Models;
using MangoRestaurant.Services.Identity.Utilities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MangoRestaurant.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(ApplicationDbContext dbContextType, UserManager<ApplicationUser> userManagerType, RoleManager<IdentityRole> roleManagerType)
        {
            dbContext = dbContextType;
            userManager = userManagerType;
            roleManager = roleManagerType;
        }

        public void Initialize()
        {
            // Configure Roles
            IdentityRole adminRole = roleManager.FindByNameAsync(IdentityHelper.AdminRole).GetAwaiter().GetResult();
            if (adminRole == null)
            {
                roleManager.CreateAsync(new IdentityRole(IdentityHelper.AdminRole));
            }

            IdentityRole customerRole = roleManager.FindByNameAsync(IdentityHelper.CustomerRole).GetAwaiter().GetResult();
            if (customerRole == null)
            {
                roleManager.CreateAsync(new IdentityRole(IdentityHelper.CustomerRole));
            }

            // Configure Users
            string userEmail = "admin1@gmail.com";

            ApplicationUser adminUser = userManager.FindByNameAsync(userEmail).GetAwaiter().GetResult();
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true,
                    PhoneNumber = "01508574837",
                    FirstName = "Ben",
                    LastName = "Admin"
                };

                userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(adminUser, IdentityHelper.AdminRole).GetAwaiter().GetResult();
                userManager.AddClaimsAsync(adminUser, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, adminUser.FullName),
                    new Claim(JwtClaimTypes.GivenName, adminUser.FirstName ?? string.Empty),
                    new Claim(JwtClaimTypes.FamilyName, adminUser.LastName ?? string.Empty),
                    new Claim(JwtClaimTypes.Role, IdentityHelper.AdminRole)
                })
                .GetAwaiter()
                .GetResult();
            }

            userEmail = "customer1@gmail.com";

            ApplicationUser customerUser = userManager.FindByNameAsync(userEmail).GetAwaiter().GetResult();
            if (customerUser == null)
            {
                customerUser = new ApplicationUser()
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true,
                    PhoneNumber = "01508738574",
                    FirstName = "Ben",
                    LastName = "Cust"
                };

                userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(customerUser, IdentityHelper.CustomerRole).GetAwaiter().GetResult();
                userManager.AddClaimsAsync(customerUser, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, customerUser.FullName),
                    new Claim(JwtClaimTypes.GivenName, customerUser.FirstName ?? string.Empty),
                    new Claim(JwtClaimTypes.FamilyName, customerUser.LastName ?? string.Empty),
                    new Claim(JwtClaimTypes.Role, IdentityHelper.CustomerRole)
                })
                .GetAwaiter()
                .GetResult();
            }
        }
    }
}
