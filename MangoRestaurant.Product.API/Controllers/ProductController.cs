using MangoRestaurant.Product.API.Models.Dtos;
using MangoRestaurant.Product.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MangoRestaurant.Product.API.Controllers
{
    // TODO - Tidy implementation, would prefer to split into services (clean this down)
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepo)
        {
            productRepository = productRepo;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto<bool>> Delete(int id)
        {
            // TODO: ICollection?
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                bool isOperationSuccessful = await productRepository.DeleteProduct(id);
                response.Result = isOperationSuccessful;
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

        // TODO: Course Upserts (to revisit is the Post/Put mechanic, not sure I like it)
        [HttpPost]
        public async Task<ResponseDto<ProductDto>> Post([FromBody] ProductDto productDto)
        {
            // TODO: ICollection?
            ResponseDto<ProductDto> response = new ResponseDto<ProductDto>();

            try
            {
                ProductDto productUpsertResult = await productRepository.UpsertProduct(productDto);
                response.Result = productUpsertResult;
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

        [HttpPut]
        public async Task<ResponseDto<ProductDto>> Put([FromBody] ProductDto productDto)
        {
            // TODO: ICollection?
            ResponseDto<ProductDto> response = new ResponseDto<ProductDto>();

            try
            {
                ProductDto productUpsertResult = await productRepository.UpsertProduct(productDto);
                response.Result = productUpsertResult;
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
