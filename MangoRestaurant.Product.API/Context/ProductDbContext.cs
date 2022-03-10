using Microsoft.EntityFrameworkCore;

namespace MangoRestaurant.Product.API.Context
{
    /// <summary>
    /// Represents the Mango Restaurant Product database context.
    /// </summary>
    /// <seealso cref="DbContext" />
    public class ProductDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDbContext"/> class.
        /// </summary>
        /// <param name="options">Options to customise the creation of the context.</param>
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Mango Restaurant Product entities.
        /// </summary>
        public DbSet<Models.Product> Products { get; set; }
    }
}
