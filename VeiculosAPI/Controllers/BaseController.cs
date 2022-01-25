using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Controllers
{
    public class BaseController<TModel, TDTO, TCreateDTO, TEditDTO> : ControllerBase
    {
        public IBaseService<TModel, TDTO, TCreateDTO, TEditDTO> service;
        public int usuarioId;
        public string slugPermissao;

        public BaseController(IBaseService<TModel, TDTO, TCreateDTO, TEditDTO> baseService, IHttpContextAccessor httpContextAccessor)
        {
            service = baseService;
            usuarioId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        [Produces("application/json")]
        public async virtual Task<ActionResult<List<TDTO>>> GetAll()
        {
            if (!await HasPermissao($"listar:{slugPermissao}"))
                return Forbid();

            return Ok(await service.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async virtual Task<ActionResult<TDTO>> Get([FromRoute] int id)
        {
            if (!await HasPermissao($"visualizar:{slugPermissao}"))
                return Forbid();

            var item = await service.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        [Produces("application/json")]
        public async virtual Task<ActionResult<TDTO>> Create([FromBody] TCreateDTO dados)
        {
            if (!await HasPermissao($"criar:{slugPermissao}"))
                return Forbid();

            return Created("", await service.Create(dados));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async virtual Task<ActionResult<TDTO>> Update([FromRoute] int id, [FromBody] TEditDTO dados)
        {
            if (!await HasPermissao($"editar:{slugPermissao}"))
                return Forbid();

            if (!await service.Exists(id))
                return NotFound();

            return Ok(service.Update(id, dados));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async virtual Task<ActionResult<bool>> Delete([FromRoute] int id)
        {
            if (!await HasPermissao($"remover:{slugPermissao}"))
                return Forbid();

            if (!await service.Exists(id))
                return NotFound();

            return Ok(await service.Delete(id));
        }

        internal async virtual Task<bool> HasPermissao(string slug)
        {
            var permissoes = await service.GetPermissoes(usuarioId);

            return permissoes.Any(permissao => permissao.Slug == slug);
        }
    }
}
