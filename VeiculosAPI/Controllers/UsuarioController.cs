using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeiculosAPI.Repository.DTOs.Usuario;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.UsuarioService.Interfaces;

namespace VeiculosAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("v{version:apiVersion}/usuarios")]
    public class UsuarioController : BaseController<Usuario, UsuarioDTO, UsuarioCreateDTO, UsuarioEditDTO>
    {
        private readonly IUsuarioService usuarioService;
        public UsuarioController(IUsuarioService _service, IHttpContextAccessor httpContextAccessor) : base(_service)
        {
            usuarioService = _service;
            base.usuarioId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            base.slugPermissao = "usuarios";
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}/verificar-email")]
        [Produces("application/json")]
        public ActionResult VerificarEmail([FromRoute] int id)
        {
            return Ok(usuarioService.VerificarEmail(id));
        }

        [HttpPut]
        [Route("{id:int}/permissoes")]
        [Produces("application/json")]
        public ActionResult SetPermissoes([FromRoute] int id, [FromBody] UsuarioEditPermissoesDTO dados)
        {
            if (!HasPermissao("editar:usuarios"))
                return Forbid();

            if (!base.service.Exists(id))
                return NotFound();

            usuarioService.SetPermissoes(id, dados).Wait();

            return Ok("Permissões atualizadas com sucesso!");
        }
    }
}
