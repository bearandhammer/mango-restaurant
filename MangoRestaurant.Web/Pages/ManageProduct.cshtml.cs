using MangoRestaurant.Web.Models.Dtos;
using MangoRestaurant.Web.Services.Interfaces;
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
                ResponseDto<ProductDto> getResponse = await productService.GetProductByIdAsync<ResponseDto<ProductDto>>(id);

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
                ResponseDto<ProductDto> response = Product.Id == 0 
                    ? await productService.CreateProductAsync<ResponseDto<ProductDto>>(Product)
                    : await productService.UpdateProductAsync<ResponseDto<ProductDto>>(Product);

                if (response != null && response.IsSuccess)
                {
                   return RedirectToPage("/Products");
                }
            }

            return Page();

        }
    }
}
