using MangoRestaurant.ShoppingCart.API.Models.Dtos.Base;

namespace MangoRestaurant.ShoppingCart.API.Models.Dtos
{
    /// <summary>
    /// Represents a user facing Product result (from the API).
    /// </summary>
    /// <seealso cref="BaseDto" />
    public class ProductDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the Product Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Product Price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the Product Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the Product Category Name.
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the Product Image URL.
        /// </summary>
        public string? ImageUrl { get; set; }
    }
}
