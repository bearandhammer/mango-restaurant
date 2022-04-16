using MangoRestaurant.ShoppingCart.API.Models.Dtos.Base;

namespace MongoRestaurant.ShoppingCart.API.Models.Entity
{
    public class CartHeaderDto : BaseDto
    {
        public string UserId { get; set; }

        public string CouponCode { get; set; }
    }
}
