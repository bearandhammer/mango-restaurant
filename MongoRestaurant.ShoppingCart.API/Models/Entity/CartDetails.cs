using MangoRestaurant.ShoppingCart.API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MongoRestaurant.ShoppingCart.API.Models.Entity
{
    public class CartDetails : BaseDbEntity
    {
        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Count { get; set; }
    }
}
