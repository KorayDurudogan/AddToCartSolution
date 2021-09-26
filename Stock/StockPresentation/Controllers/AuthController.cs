using Infrastructure;
using Infrastructure.DtoModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StockPresentation.Controllers
{
    [ApiController]
    [Route("token")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost]
        public async Task<string> Post(GetTokenDto getTokenDto) => await _authService.CreateToken(getTokenDto.Password);
    }
}
