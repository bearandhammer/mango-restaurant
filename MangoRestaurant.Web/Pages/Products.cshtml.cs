using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductService productService;

        public List<ProductDto> Products { get; set; } = new List<ProductDto>();

        public ProductsModel(IProductService productServiceType)
        {
            productService = productServiceType;
        }

        public async Task<IActionResult> OnGet()
        {
            ResponseDto<IEnumerable<ProductDto>> getAllProductsResponse = await productService.GetAllProductsAsync<ResponseDto<IEnumerable<ProductDto>>>();

            if (getAllProductsResponse?.Result != null && getAllProductsResponse.IsSuccess)
            {
                Products.AddRange(getAllProductsResponse.Result);
            }

            return Page();
        }
    }
}
