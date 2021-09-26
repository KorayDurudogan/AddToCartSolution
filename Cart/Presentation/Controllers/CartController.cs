using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) => _cartService = cartService;

        [HttpPost]
        public async Task<AddCartResponseDto> AddCart(AddCartRequest addCartDto) => await _cartService.AddToCart(addCartDto);
    }
}
