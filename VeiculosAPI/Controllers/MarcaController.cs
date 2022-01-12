using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
		public MarcaController(IMarcaService service) : base(service) { }

        [HttpGet]
        [AllowAnonymous]
        public override ActionResult<List<MarcaDTO>> GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public override ActionResult<MarcaDTO> Get([FromRoute] int id)
        {
            var item = service.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
