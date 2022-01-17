using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
		public MarcaController(IMarcaService service) : base(service) { }
    }
}
