using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Web.Pages
{
    [Authorize(Roles = "Admin")]
    public class DeleteProductModel : PageModel
    {
        private readonly IProductService productService;

        public DeleteProductModel(IProductService productServiceType)
        {
            productService = productServiceType;
        }

        [BindProperty]
        public ProductDto Product { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            ResponseDto<ProductDto> getResponse = await productService.GetProductByIdAsync<ResponseDto<ProductDto>>(id, accessToken);

            if (getResponse != null && getResponse.IsSuccess)
            {
                Product = getResponse.Result;
            }

            return Page();
        }

        // Yuck - use correct verb going forward
        public async Task<IActionResult> OnPost()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            ResponseDto<bool> response = await productService.DeleteProductAsync<ResponseDto<bool>>(Product.Id, accessToken);

            if (response != null && response.IsSuccess)
            {
                return RedirectToPage("/Products");
            }

            return Page();
        }
    }
}
