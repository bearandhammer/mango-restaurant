using System.ComponentModel.DataAnnotations;

namespace MangoRestaurant.ShoppingCart.API.Models.Base
{
    /// <summary>
    /// Represents a base class DB entity (containing properties shared by all DB entities).
    /// </summary>
    public class BaseDbEntity
    {
        /// <summary>
        /// Gets or sets the Id for the entity.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
