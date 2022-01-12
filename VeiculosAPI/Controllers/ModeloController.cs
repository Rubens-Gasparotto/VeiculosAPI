using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public ModeloController(IModeloService service) : base(service) { }

        [HttpGet]
        [AllowAnonymous]
        public override ActionResult<List<ModeloDTO>> GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public override ActionResult<ModeloDTO> Get([FromRoute] int id)
        {
            var item = service.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
