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
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = productDto,
                Url = $"{ ApiHelper.ProductApiBase }api/products",
                Token = string.Empty
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.DELETE,
                Url = $"{ ApiHelper.ProductApiBase }api/products/{ id }",
                Token = string.Empty
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = $"{ ApiHelper.ProductApiBase }api/products",
                Token = string.Empty
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = $"{ ApiHelper.ProductApiBase }api/products/{ id }",
                Token = string.Empty
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiHelper.ApiType.PUT,
                Data = productDto,
                Url = $"{ ApiHelper.ProductApiBase }api/products",
                Token = string.Empty
            });
        }
    }
}
