using MangoRestaurant.Product.API.Models.Dtos;
using MangoRestaurant.Product.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MangoRestaurant.Product.API.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepo)
        {
            productRepository = productRepo;
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<ProductDto>>> Get()
        {
            // TODO: ICollection?
            ResponseDto<IEnumerable<ProductDto>> response = new ResponseDto<IEnumerable<ProductDto>>();

            try
            {
                IEnumerable<ProductDto> productResults = await productRepository.GetAllProducts();
                response.Result = productResults;
            }
            catch (Exception ex)
            {
                // TODO: Log
                response.IsSuccess = false;

                // TODO: To improve (example from course)
                response.ErrorMessages = new List<string> { ex.Message };
            }

            return response;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto<ProductDto>> Get(int id)
        {
            // TODO: ICollection?
            ResponseDto<ProductDto> response = new ResponseDto<ProductDto>();

            try
            {
                ProductDto productResult = await productRepository.GetProductById(id);
                response.Result = productResult;
            }
            catch (Exception ex)
            {
                // TODO: Log
                response.IsSuccess = false;

                // TODO: To improve (example from course)
                response.ErrorMessages = new List<string> { ex.Message };
            }

            return response;
        }
    }
}
