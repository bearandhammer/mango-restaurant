using MangoRestaurant.Services.Identity.Data;
using MangoRestaurant.Services.Identity.Initializer.Interfaces;
using MangoRestaurant.Services.Identity.Models;
using MangoRestaurant.Services.Identity.Utilities;
using Microsoft.AspNetCore.Identity;

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
            if (adminRole == null)
            {
                roleManager.CreateAsync(new IdentityRole(IdentityHelper.CustomerRole));
            }

            // Configure Users
            ApplicationUser adminUser = userManager.FindByNameAsync("admin1@gmail.com").GetAwaiter().GetResult();
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = "admin1@gmail.com",
                    Email = "admin1@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "01508574837",
                    FirstName = "Ben",
                    LastName = "Admin"
                };

                userManager.CreateAsync(adminUser, "Admin123").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(adminUser, IdentityHelper.AdminRole).GetAwaiter().GetResult();
            }
        }
    }
}
