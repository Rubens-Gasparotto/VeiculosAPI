using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public PermissaoController(IPermissaoService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
            slugPermissao = "permissoes";
        }

        [HttpPost]
        [NonAction]
        public async override Task<ActionResult<PermissaoDTO>> Create([FromBody] PermissaoCreateDTO dados)
        {
            if (!await HasPermissao($"criar:{slugPermissao}"))
                return Forbid();

            return await base.Create(dados);
        }

        [HttpPut]
        [Route("{id:int}")]
        [NonAction]
        public async override Task<ActionResult<PermissaoDTO>> Update([FromRoute] int id, [FromBody] PermissaoEditDTO dados)
        {
            if (!await HasPermissao($"editar:{slugPermissao}"))
                return Forbid();

            return await base.Update(id, dados);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [NonAction]
        public async override Task<ActionResult<bool>> Delete([FromRoute] int id)
        {
            if (!await HasPermissao($"remover:{slugPermissao}"))
                return Forbid();

            return await base.Delete(id);
        }
    }
}
