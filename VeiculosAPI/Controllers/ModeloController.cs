using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public ModeloController(IModeloService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            base.usuarioId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            base.slugPermissao = "modelos";
        }
    }
}
