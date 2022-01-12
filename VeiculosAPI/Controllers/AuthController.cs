
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<LoginResponseDTO> Login([FromBody] LoginDTO dados)
        {
            LoginResponseDTO login = authService.Login(dados);

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
        public ActionResult<LoginResponseDTO> RefreshToken([FromBody] RefreshDTO dados)
        {
            LoginResponseDTO refresh = authService.RefreshToken(dados.Token);

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
