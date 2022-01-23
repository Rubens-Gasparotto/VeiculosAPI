﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public MarcaController(IMarcaService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            base.usuarioId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            base.slugPermissao = "marcas";
        }
    }
}
