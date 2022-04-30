using Microsoft.AspNetCore.Mvc;

namespace MongoRestaurant.ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
