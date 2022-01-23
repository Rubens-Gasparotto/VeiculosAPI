using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeiculosAPI.Repository.DTOs.Permissao;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.PermissaoService.Interfaces;

namespace VeiculosAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("v{version:apiVersion}/permissoes")]
    public class PermissaoController : BaseController<Permissao, PermissaoDTO, PermissaoCreateDTO, PermissaoEditDTO>
    {
        public PermissaoController(IPermissaoService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            base.usuarioId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            base.slugPermissao = "permissoes";
        }

        [HttpPost]
        [NonAction]
        public override ActionResult<PermissaoDTO> Create([FromBody] PermissaoCreateDTO dados)
        {
            if (!HasPermissao("criar:permissoes"))
                return Forbid();

            return base.Create(dados);
        }

        [HttpPut]
        [Route("{id:int}")]
        [NonAction]
        public override ActionResult<PermissaoDTO> Update([FromRoute] int id, [FromBody] PermissaoEditDTO dados)
        {
            if (!HasPermissao("editar:permissoes"))
                return Forbid();

            return base.Update(id, dados);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [NonAction]
        public override ActionResult<bool> Delete([FromRoute] int id)
        {
            if (!HasPermissao("remover:permissoes"))
                return Forbid();

            return base.service.Delete(id);
        }
    }
}
