using MangoRestaurant.ShoppingCart.API.Models.Base;

namespace MongoRestaurant.ShoppingCart.API.Models.Entity
{
    public class CartHeader : BaseDbEntity
    {
        public string UserId { get; set; }

        public string CouponCode { get;set; }
    }
}
