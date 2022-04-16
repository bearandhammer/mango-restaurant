using MangoRestaurant.ShoppingCart.API.Models.Base;

namespace MongoRestaurant.ShoppingCart.API.Models.Entity
{
    public class Cart : BaseDbEntity
    {
        public CartHeader CartHeader { get; set; }

        public ICollection<CartDetails> CartDetails { get; set; }
    }
}
