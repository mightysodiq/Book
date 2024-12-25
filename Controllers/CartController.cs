using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IcartServices _cartServices;
        public CartController(IcartServices cartServices ) 
        {
            _cartServices = cartServices;
        }
        [HttpPost("{cartId}/items")]
        public async Task <IActionResult> AddToCart(int cartId, [FromBody] AddToCartDto addToCartDto)
        {
            if (addToCartDto == null)
                return BadRequest("Invalid cart item data.");
            await _cartServices.AddToCartAsync(cartId, addToCartDto.BookId, addToCartDto.Quantity);
            return Ok("Item added to cart successfully.");
        }
    }
}
