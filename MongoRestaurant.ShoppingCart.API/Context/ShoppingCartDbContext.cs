using Microsoft.EntityFrameworkCore;

namespace MongoRestaurant.ShoppingCart.API.Context
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
            : base(options)
        {
        }
    }
}
