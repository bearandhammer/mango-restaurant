using AutoMapper;
using MangoRestaurant.Product.API.Context;
using MangoRestaurant.Product.API.Models.Dtos;
using MangoRestaurant.Product.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MangoRestaurant.Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext dbContext;

        private readonly IMapper mapper;

        public ProductRepository(ProductDbContext dbContextType, IMapper mapperType)
        {
            dbContext = dbContextType;
            mapper = mapperType;
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<Models.Entities.Product> allProducts = await dbContext.Products.ToListAsync();

            return mapper.Map<IEnumerable<ProductDto>>(allProducts);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Models.Entities.Product discoveredProduct = await dbContext.Products.FirstOrDefaultAsync(product => product.Id == productId);

            return mapper.Map<ProductDto>(discoveredProduct);
        }

        public Task<ProductDto> UpsertProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
