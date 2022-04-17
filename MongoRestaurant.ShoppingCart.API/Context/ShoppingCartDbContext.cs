using Microsoft.EntityFrameworkCore;
using MongoRestaurant.ShoppingCart.API.Models.Entity;

namespace MongoRestaurant.ShoppingCart.API.Context
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<CartHeader> CartHeaders { get; set; }

        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
