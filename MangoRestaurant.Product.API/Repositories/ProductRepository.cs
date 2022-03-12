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

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Models.Entities.Product productToDelete = await dbContext.Products.FirstOrDefaultAsync(product => product.Id == productId);

                if (productToDelete == null)
                {
                    return false;
                }

                dbContext.Products.Remove(productToDelete);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // TODO - Log
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<Models.Entities.Product> allProducts = await dbContext.Products.ToListAsync();

            return mapper.Map<IEnumerable<ProductDto>>(allProducts);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            // TODO - handle the possibility of 'no match'
            Models.Entities.Product discoveredProduct = await dbContext.Products.FirstOrDefaultAsync(product => product.Id == productId);

            return mapper.Map<ProductDto>(discoveredProduct);
        }

        public async Task<ProductDto> UpsertProduct(ProductDto productDto)
        {
            Models.Entities.Product productToSave = mapper.Map<Models.Entities.Product>(productDto);

            if (productToSave.Id > 0)
            {
                // Update
                dbContext.Products.Update(productToSave);
            }
            else
            {
                // Insert
                dbContext.Products.Add(productToSave);
            }

            await dbContext.SaveChangesAsync();

            return mapper.Map<ProductDto>(productToSave);
        }
    }
}
