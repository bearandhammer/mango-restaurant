using MangoRestaurant.Web.Models.Dtos.Base;

namespace MangoRestaurant.Web.Models.Dtos
{
    public class CartHeaderDto : BaseDto
    {
        public string UserId { get; set; }

        public string CouponCode { get; set; }

        public double OrderTotal { get; set; }
    }
}
