
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeiculosAPI.Repository.DTOs.Auth;
using VeiculosAPI.Services.AuthService;

namespace VeiculosAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpPost]
        [Route("login")]
        [Produces("application/json")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginDTO dados)
        {
            LoginResponseDTO login = await authService.Login(dados);

            if (login == null)
            {
                return BadRequest("E-mail/senha incorretos");
            }
            else
            {
                return Ok(login);
            }
        }

        [HttpPost]
        [Route("refresh")]
        [Produces("application/json")]
        public async Task<ActionResult<LoginResponseDTO>> RefreshToken([FromBody] RefreshDTO dados)
        {
            LoginResponseDTO refresh = await authService.RefreshToken(dados.Token);

            if (refresh == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(refresh);
            }
        }
    }
}
