
using Microsoft.AspNetCore.Mvc;
using VeiculosAPI.Services.LoginService;
using VeiculosAPI.Services.LoginService.Dtos;

namespace VeiculosAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/login")]
    public class LoginController : ControllerBase
    {
        private ILoginService loginService;
        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] ILogin dados)
        {
            var login = loginService.Login(dados);

            if (login == null)
            {
                return BadRequest("E-mail/senha incorretos");
            }
            else
            {
                return Ok(login);
            }
        }
    }
}
