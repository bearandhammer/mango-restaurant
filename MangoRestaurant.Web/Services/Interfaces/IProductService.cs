using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Base.Interfaces;

namespace MangoRestaurant.Web.Services.Interfaces
{
    // TODO - Follow materials here, need to readjust all of this, however
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
