using MongoRestaurant.ShoppingCart.API.Models.Entity;

namespace MongoRestaurant.ShoppingCart.API.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<bool> ClearCart(string userId);

        Task<CartDto> GetCartByUserId(string userId);

        Task<bool> RemoveFromCart(int cartDetailsId);

        Task<CartDto> UpsertCart(CartDto cartDto);
    }
}
