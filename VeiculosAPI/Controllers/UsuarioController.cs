using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public UsuarioController(IUsuarioService _service, IHttpContextAccessor httpContextAccessor) : base(_service, httpContextAccessor)
        {
            usuarioService = _service;
            slugPermissao = "usuarios";
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}/verificar-email")]
        [Produces("application/json")]
        public async Task<ActionResult> VerificarEmail([FromRoute] int id)
        {
            return Ok(await usuarioService.VerificarEmail(id));
        }

        [HttpPut]
        [Route("{id:int}/permissoes")]
        [Produces("application/json")]
        public async Task<ActionResult> SetPermissoes([FromRoute] int id, [FromBody] UsuarioEditPermissoesDTO dados)
        {
            if (!await HasPermissao("editar:usuarios"))
                return Forbid();

            if (!await service.Exists(id))
                return NotFound();

            await usuarioService.SetPermissoes(id, dados);

            return Ok("Permissões atualizadas com sucesso!");
        }
    }
}
