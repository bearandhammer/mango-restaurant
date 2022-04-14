using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IProductService productService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productServiceType)
        {
            _logger = logger;
            productService = productServiceType;
        }

        public List<ProductDto> ProductResults { get; set; } = new List<ProductDto>();

        public async Task<IActionResult> OnGet()
        {
            ResponseDto<IEnumerable<ProductDto>> getAllProductsResponse =
                await productService.GetAllProductsAsync<ResponseDto<IEnumerable<ProductDto>>>(string.Empty);

            if (getAllProductsResponse?.IsSuccess ?? false && getAllProductsResponse?.Result != null)
            {
                ProductResults.AddRange(getAllProductsResponse.Result);
            }

            return Page();
        }
    }
}
