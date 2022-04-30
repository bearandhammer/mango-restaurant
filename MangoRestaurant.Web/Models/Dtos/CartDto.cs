using MangoRestaurant.Web.Models.Dtos.Base;

namespace MangoRestaurant.Web.Models.Dtos
{
    public class CartDto : BaseDto
    {
        public CartHeaderDto CartHeader { get; set; }

        public ICollection<CartDetailsDto> CartDetails { get; set; }
    }
}
