using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Models.Requests;
using MangoRestaurant.Web.Services.Base;
using MangoRestaurant.Web.Services.Interfaces;
using MangoRestaurant.Web.Utility;

namespace MangoRestaurant.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        public CartService(IHttpClientFactory clientFactoryType)
            : base(clientFactoryType)
        {
        }

        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = cartDto,
                Url = $"{ ApiHelper.ShoppingCartApiBase }api/cart",
                Token = token
            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = $"{ ApiHelper.ShoppingCartApiBase }api/cart/{ userId }",
                Token = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartDetailsId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.DELETE,
                Url = $"{ ApiHelper.ShoppingCartApiBase }api/cart/{ cartDetailsId }",
                Token = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.PUT,
                Data = cartDto,
                Url = $"{ ApiHelper.ShoppingCartApiBase }api/cart",
                Token = token
            });
        }
    }
}
