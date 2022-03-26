using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Models.Requests;
using MangoRestaurant.Web.Services.Base;
using MangoRestaurant.Web.Utility;
using MangoRestaurant.Web.Services.Interfaces;

namespace MangoRestaurant.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory clientFactoryType) :
            base(clientFactoryType)
        {
        }

        // Can just return tasks here, to adjust
        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = productDto,
                Url = $"{ ApiHelper.ProductApiBase }api/products",
                Token = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.DELETE,
                Url = $"{ ApiHelper.ProductApiBase }api/products/{ id }",
                Token = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = $"{ ApiHelper.ProductApiBase }api/products",
                Token = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = $"{ ApiHelper.ProductApiBase }api/products/{ id }",
                Token = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.PUT,
                Data = productDto,
                Url = $"{ ApiHelper.ProductApiBase }api/products",
                Token = token
            });
        }
    }
}
