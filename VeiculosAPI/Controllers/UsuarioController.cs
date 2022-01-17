using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public UsuarioController(IUsuarioService _service) : base(_service)
        {
            usuarioService = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}/verificar-email")]
        [Produces("application/json")]
        public ActionResult VerificarEmail([FromRoute] int id)
        {
            return Ok(usuarioService.VerificarEmail(id));
        }

        [HttpPost]
        [Route("{id:int}/permissoes")]
        [Produces("application/json")]
        public ActionResult SetPermissoes([FromRoute] int id, [FromBody] int[] permissoes)
        {
            if (!base.service.Exists(id))
                return NotFound();

            usuarioService.SetPermissoes(id, permissoes);

            return Ok("Permissões atualizadas com sucesso!");
        }
    }
}
