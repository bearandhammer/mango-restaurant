using MangoRestaurant.Product.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using MongoRestaurant.ShoppingCart.API.Models.Entity;
using MongoRestaurant.ShoppingCart.API.Repositories.Interfaces;

namespace MongoRestaurant.ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;

        public CartController(ICartRepository cartRepositoryType)
        {
            cartRepository = cartRepositoryType;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ResponseDto<CartDto>>> GetCart(string userId)
        {
            ResponseDto<CartDto> response = new ResponseDto<CartDto>();

            try
            {
                response.Result = await cartRepository.GetCartByUserId(userId);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<CartDto>>> AddCart(CartDto cartDto) => await UpsertCart(cartDto);

        [HttpPut]
        public async Task<ActionResult<ResponseDto<CartDto>>> UpdateCart(CartDto cartDto) => await UpsertCart(cartDto);

        private async Task<ActionResult<ResponseDto<CartDto>>> UpsertCart(CartDto cartDto)
        {
            ResponseDto<CartDto> response = new ResponseDto<CartDto>();

            try
            {
                response.Result = await cartRepository.UpsertCart(cartDto);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return response;
        }
    }
}
