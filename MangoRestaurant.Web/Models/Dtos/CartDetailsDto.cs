using MangoRestaurant.Web.Models.Dtos.Base;

namespace MangoRestaurant.Web.Models.Dtos
{
    public class CartDetailsDto : BaseDto
    {
        public int CartHeaderId { get; set; }

        public CartHeaderDto CartHeader { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int Count { get; set; }
    }
}
