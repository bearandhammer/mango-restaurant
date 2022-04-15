using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Web.Pages
{
    [Authorize]
    public class ProductDetailModel : PageModel
    {
        private readonly ILogger<ProductDetailModel> _logger;

        private readonly IProductService productService;

        public ProductDto Product { get; set; }

        public ProductDetailModel(ILogger<ProductDetailModel> logger, IProductService productServiceType)
        {
            _logger = logger;
            productService = productServiceType;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            ResponseDto<ProductDto> productResponse = await productService.GetProductByIdAsync<ResponseDto<ProductDto>>(id, accessToken);

            if (productResponse?.Result != null && productResponse.IsSuccess)
            {
                Product = productResponse.Result;
            }

            return Page();
        }
    }
}
