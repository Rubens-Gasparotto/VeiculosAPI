using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public ModeloController(IModeloService service) : base(service) { }
    }
}
