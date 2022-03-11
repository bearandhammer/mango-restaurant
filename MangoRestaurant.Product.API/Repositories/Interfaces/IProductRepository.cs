using MangoRestaurant.Product.API.Models.Dtos;

namespace MangoRestaurant.Product.API.Repositories.Interfaces
{
    /// <summary>
    /// Contract for a type that wants to serve as a Product Repository.
    /// </summary>
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> UpsertProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
