using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRestaurant.Web.Pages
{
    public class ManageProductModel : PageModel
    {
        private readonly IProductService productService;

        public ManageProductModel(IProductService productServiceType)
        {
            productService = productServiceType;
        }

        [BindProperty]
        public ProductDto Product { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == 0)
            {
                Product = new ProductDto();
            }
            else
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                ResponseDto<ProductDto> getResponse = await productService.GetProductByIdAsync<ResponseDto<ProductDto>>(id, accessToken);

                if (getResponse != null && getResponse.IsSuccess)
                {
                    Product = getResponse.Result;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                ResponseDto<ProductDto> response = Product.Id == 0 
                    ? await productService.CreateProductAsync<ResponseDto<ProductDto>>(Product, accessToken)
                    : await productService.UpdateProductAsync<ResponseDto<ProductDto>>(Product, accessToken);

                if (response != null && response.IsSuccess)
                {
                   return RedirectToPage("/Products");
                }
            }

            return Page();

        }
    }
}
