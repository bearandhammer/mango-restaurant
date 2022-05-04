using MangoRestaurant.Web.Models.Dtos;

namespace MangoRestaurant.Web.Services.Interfaces
{
    public interface ICartService
    {
        Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null);

        Task<T> GetCartByUserIdAsync<T>(string userId, string token = null);

        Task<T> RemoveFromCartAsync<T>(int cartDetailsId, string token = null);

        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null);
    }
}
