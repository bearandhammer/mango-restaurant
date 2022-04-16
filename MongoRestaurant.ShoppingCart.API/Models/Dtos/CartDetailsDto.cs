using MangoRestaurant.ShoppingCart.API.Models.Dtos.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MongoRestaurant.ShoppingCart.API.Models.Entity
{
    public class CartDetailsDto : BaseDto
    {
        public int CartHeaderId { get; set; }

        public CartHeaderDto CartHeader { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
