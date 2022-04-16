using MangoRestaurant.ShoppingCart.API.Models.Dtos.Base;

namespace MongoRestaurant.ShoppingCart.API.Models.Entity
{
    public class CartDto : BaseDto
    {
        public CartHeaderDto CartHeader { get; set; }

        public ICollection<CartDetailsDto> CartDetails { get; set; }
    }
}
