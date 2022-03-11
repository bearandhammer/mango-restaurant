using MangoRestaurant.Product.API.Models.Dtos;
using MangoRestaurant.Product.API.Repositories.Interfaces;

namespace MangoRestaurant.Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpsertProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
