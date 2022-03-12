using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Base.Interfaces;

namespace MangoRestaurant.Web.Services.Interfaces
{
    // TODO - Follow materials here, need to readjust all of this, however
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
