using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeiculosAPI.Repository.DTOs.Marca;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.MarcaService.Interfaces;

namespace VeiculosAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("v{version:apiVersion}/marcas")]
    public class MarcaController : BaseController<Marca, MarcaDTO, MarcaCreateDTO, MarcaEditDTO>
    {
        public MarcaController(IMarcaService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
            slugPermissao = "marcas";
        }

        [HttpPost]
        [Produces("application/json")]
        public override async Task<ActionResult<MarcaDTO>> Create([FromForm] MarcaCreateDTO dados)
        {
            if (!await HasPermissao($"criar:{slugPermissao}"))
                return Forbid();

            return Created("", await service.Create(dados));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public override async Task<ActionResult<MarcaDTO>> Update([FromRoute] int id, [FromForm] MarcaEditDTO dados)
        {
            if (!await HasPermissao($"editar:{slugPermissao}"))
                return Forbid();

            if (!await service.Exists(id))
                return NotFound();

            return Ok(await service.Update(id, dados));
        }
    }
}
