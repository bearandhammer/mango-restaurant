using MangoRestaurant.Product.API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MangoRestaurant.Product.API.Models
{
    /// <summary>
    /// Represents a Mango Restaurant Product.
    /// </summary>
    public class Product : BaseDbEntity
    {
        /// <summary>
        /// Gets or sets the Product Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Product Price.
        /// </summary>
        [Range(1, 1000)]
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
