using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.ModeloService.Interfaces;

namespace VeiculosAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("v{version:apiVersion}/modelos")]
    public class ModeloController : BaseController<Modelo, ModeloDTO, ModeloCreateDTO, ModeloEditDTO>
    {
        public ModeloController(IModeloService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
            slugPermissao = "modelos";
        }

        [HttpPost]
        [Produces("application/json")]
        public override async Task<ActionResult<ModeloDTO>> Create([FromForm] ModeloCreateDTO dados)
        {
            if (!await HasPermissao($"criar:{slugPermissao}"))
                return Forbid();

            return Created("", await service.Create(dados));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public override async Task<ActionResult<ModeloDTO>> Update([FromRoute] int id, [FromForm] ModeloEditDTO dados)
        {
            if (!await HasPermissao($"editar:{slugPermissao}"))
                return Forbid();

            if (!await service.Exists(id))
                return NotFound();

            return Ok(await service.Update(id, dados));
        }
    }
}
