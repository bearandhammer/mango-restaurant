using MongoRestaurant.ShoppingCart.API.Models.Entity;
using MongoRestaurant.ShoppingCart.API.Repositories.Interfaces;

namespace MongoRestaurant.ShoppingCart.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> UpsertCart(CartDto cartDto)
        {
            throw new NotImplementedException();
        }
    }
}
